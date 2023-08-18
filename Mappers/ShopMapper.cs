using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class ShopMapper
{
    public static void UpdateShop(this Shop shop, UpdateShopRequest request)
    {
        shop.Name = request.Name;
        shop.Adrress = request.Adrress;
        shop.Phone = request.Phone;
        shop.UpperId = request.UpperId;
        shop.UpdatedDate = DateTime.UtcNow;
    }

    public static GetShopResponse ResponseShop(this Shop shop)
        => new GetShopResponse
        {
            Id = shop.Id,
            Name = shop.Name,
            Adrress = shop.Adrress,
            Phone = shop.Phone,
            UpperId = shop.UpperId,
            CreatedDate = shop.CreatedDate,
            UpdatedDate = shop.UpdatedDate
        };

    public static Shop CreateShop(this CreateShopRequest shop)
        => new Shop
        {
            Name = shop.Name,
            Adrress = shop.Adrress,
            Phone = shop.Phone,
            UpperId = shop.UpperId
        };
}
