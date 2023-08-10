using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class CompanyMapper
{
    public static void UpdateCompany(this Company company, UpdateCompanyRequest request)
    {
        company.Name = request.Name;
        company.ClosedDate = request.ClosedDate;
        company.UpperId = request.UpperId;
    }

    public static GetCompanyResponse ResponseCompany(this Company company)
    => new GetCompanyResponse
    {
        Id = company.Id,
        Name = company.Name,
        ClosedDate = company.ClosedDate,
        UpperId = company.UpperId,
        CreatedDate = company.CreatedDate,
        UpdatedDate = company.UpdatedDate,
        Branches = company.Branches
    };

    public static Company CreateCompany(this CreateCompanyRequest company)
    => new Company
    {
        Name = company.Name,
        ClosedDate = company.ClosedDate,
        UpperId = company.UpperId
    };
}