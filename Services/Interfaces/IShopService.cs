using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface IShopService
{
    Task<GetShopResponse> CreateShopAsync(CreateShopRequest request);
    Task<GetShopResponse?> UpdateShopAsync(int id,UpdateShopRequest request);
    Task<bool> DeleteAsync(int id);
    Task<GetShopResponse?> GetShopByIdAsync(int id);
    Task<IEnumerable<GetShopResponse>> GetAllShopsAsync();
}
