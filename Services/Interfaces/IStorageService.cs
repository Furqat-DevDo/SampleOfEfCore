using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface IStorageService
    {
    Task<GetStorageResponse> CreateStorageAsync(CreateStorageRequest request);
    Task<GetStorageResponse?> UpdateStorageAsync(int id,UpdateStorageRequest request);
    Task<bool> DeleteAsync(int id);
    Task<GetStorageResponse?> GetStorageByIdAsync(int id);
    Task<IEnumerable<GetStorageResponse>> GetAllStorageAsync();
   
    }
}
