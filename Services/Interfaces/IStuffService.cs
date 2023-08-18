using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface IStuffService
{
    Task<GetStuffResponse> CreateStuffAsync(CreateStuffRequest request);
    Task<IEnumerable<GetStuffResponse>> GetAllStuffAsync();
    Task<GetStuffResponse?> GetStuffByIdAsync(int id);
    Task<GetStuffResponse?> UpdateStuffAsync(int id,UpdateStuffRequest request);
    Task<bool> DeleteStuffAsync(int id); 
}
