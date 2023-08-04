using EfCore.Data;
using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class ShopService : IShopService
{
    private readonly ShopDbContext _context;
    public ShopService(ShopDbContext context)
    {
        _context = context;
    }

    public async  Task<GetShopResponse> CreateShopAsync(CreateShopRequest request)
    {
        var shop = new Shop 
        { 
            Adrress = request.Adrress,
            Name = request.Name,
            Phone = request.Phone,
            UpperId = request.UpperId
        };

        var newShop = await _context.Shops.AddAsync(shop);
        await _context.SaveChangesAsync();

        return new GetShopResponse(newShop.Entity);
        
    }

    public async  Task<bool> DeleteAsync(int id)
    {
        var shop = await _context.Shops.FirstOrDefaultAsync(sh => sh.Id == id);
        if (shop is null) return false;

        shop.IsDeleted = true;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<GetShopResponse>> GetAllShopsAsync()
    {
        var shops = await  _context.Shops.ToListAsync();
        return shops.Any() ? 
            shops.Select(sh => new GetShopResponse(sh)) 
            : new List<GetShopResponse>(); 
    }

    public async Task<GetShopResponse?> GetShopByIdAsync(int id)
    {
        var shop = await _context.Shops
            .Include(x => x.Branches)
            .FirstOrDefaultAsync(sh => sh.Id == id);

        return shop is null ? null : new GetShopResponse(shop);
    }

    public async  Task<GetShopResponse?> UpdateShopAsync(int id, UpdateShopRequest request)
    {
        var shop = await _context.Shops.FirstOrDefaultAsync(sh => sh.Id == id);
        if (shop is null) return null;

        shop.Name = request.Name;
        shop.UpdatedDate = DateTime.UtcNow;
        shop.Adrress = request.Adrress;
        shop.Phone = request.Phone;
        shop.UpperId = request.UpperId;

        _context.Shops.Update(shop);
        _context.SaveChanges();
        return new GetShopResponse(shop);
    }
}
