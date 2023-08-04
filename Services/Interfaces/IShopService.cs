using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface IShopService
{
    Task<GetShopResponse> CreateAsync(GetShopRequest reques);
    Task<GetShopResponse> UpdateAsync(GetShopRequest request);
    Task<GetShopResponse> DeleteAsync(int id);
    Task<GetShopResponse> GetShopByIdAsync(int id);
    Task<GetShopResponse> GetAllShopAsync();

}
