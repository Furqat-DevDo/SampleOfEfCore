using EfCore.Data;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class CompanyService : ICompanyService
{
    private readonly ShopDbContext _shopDbContext;
    public CompanyService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<GetCompanyResponse?> CreateCompanyAsync(CreateCompanyRequest request)
    {
        var company = request.CreateCompany();

        var newCompany = await _shopDbContext.Companies
            .AddAsync(company);
        int saveChangesResult = await _shopDbContext.SaveChangesAsync();

        return saveChangesResult > 0 ? newCompany.Entity.ResponseCompany() : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var company = await _shopDbContext.Companies
            .FirstOrDefaultAsync(p => p.Id == id);

        if (company is null)
            return false;

        company.IsDeleted = true;
        return _shopDbContext.SaveChanges() > 0;
    }

    public async Task<IEnumerable<GetCompanyResponse>> GetAllCompanysAsync()
    {
        var companies = await _shopDbContext
            .Companies
            .Include(sh => sh.Branches)
            .ToListAsync();

        return companies.Any() ? companies.Select(c => c.ResponseCompany())
            : new List<GetCompanyResponse>();
    }

    public async Task<GetCompanyResponse?> GetCompanyByIdAsync(int id)
    {
        var company = await _shopDbContext
            .Companies
            .Include (sh => sh.Branches)
            .FirstOrDefaultAsync(p => p.Id == id);

        return company is null ? null : company.ResponseCompany();
    }

    public async Task<GetCompanyResponse?> UpdateCompanyAsync(int id, UpdateCompanyRequest request)
    {
        var company = await _shopDbContext.Companies.FirstOrDefaultAsync(p => p.Id == id);

        if (company is null)
            return null;

        company.UpdateCompany(request);
        _shopDbContext.SaveChanges();

        return company.ResponseCompany();
    }
}