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
        company.UpdatedDate = DateTime.UtcNow;
    }

    public static GetCompanyResponse ResponseCompany(this Company company)
    {
        return new GetCompanyResponse
        {
            Id = company.Id,
            Name = company.Name,
            ClosedDate = company.ClosedDate,
            UpperId = company.UpperId,
            CreatedDate = company.CreatedDate,
            UpdatedDate = company.UpdatedDate,
            Branches = company.Branches?.Select(s => new GetCompanyResponse
            {
                Id = s.Id,
                CreatedDate = s.CreatedDate,
                UpdatedDate = s.UpdatedDate,
                Name = s.Name,
                ClosedDate = s.ClosedDate,
                UpperId = s.UpperId,
            }).ToList(),
        };
    }

    public static Company CreateCompany(this CreateCompanyRequest company)
    => new Company
    {
        Name = company.Name,
        ClosedDate = company.ClosedDate,
        UpperId = company.UpperId
    };
}