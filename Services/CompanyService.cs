using EfCore.Data;
using EfCore.Exceptions;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class CompanyService : ICompanyService
{
    private readonly ShopDbContext _shopDbContext;
    private ILogger<CompanyService> _logger;
    public CompanyService(ShopDbContext shopDbContext, 
        ILogger<CompanyService> logger)
    {
        _shopDbContext = shopDbContext;
        _logger = logger;
    }

    public async Task<GetCompanyResponse?> CreateCompanyAsync(CreateCompanyRequest request)
    {
        var company = request.CreateCompany();

        var newCompany = await _shopDbContext.Companies
            .AddAsync(company);

        if (await _shopDbContext.SaveChangesAsync() <= 0)        
                throw new UnableToSaveCompanyChangesException();
        
        return newCompany.Entity.ResponseCompany();
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var company = await _shopDbContext.Companies.FirstOrDefaultAsync(p => p.Id == id) ?? throw new CompanyNotFoundException();

        company.IsDeleted = true;

        if (await _shopDbContext.SaveChangesAsync() <= 0)
                throw new UnableToSaveCompanyChangesException();

        return true;
    }

    public async Task<IEnumerable<GetCompanyResponse>> GetAllCompanysAsync()
    {
        var companies = await _shopDbContext
            .Companies
            .AsNoTracking()
            .Include(sh => sh.Branches)
            .ToListAsync();

        return companies.Any() ? companies.Select(c => c.ResponseCompany())
            : Enumerable.Empty<GetCompanyResponse>();
    }

    public async Task<GetCompanyResponse?> GetCompanyByIdAsync(int id)
    {
        var company = await _shopDbContext
            .Companies
            .Include (sh => sh.Branches)
            .FirstOrDefaultAsync(p => p.Id == id) 
            ?? throw new CompanyNotFoundException();

        return company.ResponseCompany();
    }

    public async Task<GetCompanyResponse?> UpdateCompanyAsync(int id, UpdateCompanyRequest request)
    {
        var company = await _shopDbContext.Companies
        .FirstOrDefaultAsync(p => p.Id == id)
        ?? throw new CompanyNotFoundException();

        company.UpdateCompany(request);

        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveCompanyChangesException();

        return company.ResponseCompany();
    }
}