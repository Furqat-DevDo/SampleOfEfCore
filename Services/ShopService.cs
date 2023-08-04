using EfCore.Entities;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;

namespace EfCore.Services;

public class ShopService : IShopService
{
    private readonly IShopService _shopService;

    public ShopService(IShopService shopService)
    {
        _shopService = shopService;
    }
    public async Task<GetShopResponse> CreateAsync(GetShopResponse response)
    {
        var shop = new Shop
        {
            Address = re
        };

        var newShop = await _shopService.
    }

    public Task<GetShopResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GetShopResponse> GetAllShopAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetShopResponse> GetShopByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GetShopResponse> UpdateAsync(GetShopResponse response)
    {
        throw new NotImplementedException();
    }
}
