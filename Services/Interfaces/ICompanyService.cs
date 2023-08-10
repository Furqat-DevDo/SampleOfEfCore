using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface ICompanyService
{
    Task<GetCompanyResponse> CreateCompanyAsync(CreateCompanyRequest request);
    Task<GetCompanyResponse?> UpdateCompanyAsync(int id, UpdateCompanyRequest request);
    Task<bool> DeleteAsync(int id);
    Task<GetCompanyResponse?> GetCompanyByIdAsync(int id);
    Task<IEnumerable<GetCompanyResponse>> GetAllCompanysAsync();
}