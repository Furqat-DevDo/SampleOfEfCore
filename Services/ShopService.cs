using EfCore.Data;
using EfCore.Exceptions;
using EfCore.Mappers;
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
        var shop = request.CreateShop();

        var newShop = await _context.Shops.AddAsync(shop);

        if (await _context.SaveChangesAsync() <= 0)
            throw new UnableToSaveShopChangesException();

        return newShop.Entity.ResponseShop();   
    }

    public async  Task<bool> DeleteAsync(int id)
    {
        var shop = await _context.Shops.FirstOrDefaultAsync(sh => sh.Id == id);
        
        if (shop is null) throw new ShopNotFoundException();

        shop.IsDeleted = true;

        if (await _context.SaveChangesAsync() <= 0)
            throw new UnableToSaveShopChangesException();

        return true;
    }

    public async Task<IEnumerable<GetShopResponse>> GetAllShopsAsync()
    {
        var shops = await  _context.Shops.ToListAsync();
        return shops.Any() ? 
            shops.Select(sh => sh.ResponseShop()) 
            : new List<GetShopResponse>(); 
    }

    public async Task<GetShopResponse?> GetShopByIdAsync(int id)
    {
        var shop = await _context.Shops
            .Include(x => x.Branches)
            .FirstOrDefaultAsync(sh => sh.Id == id);

        return shop is null ? throw new ShopNotFoundException() : shop.ResponseShop();
    }

    public async  Task<GetShopResponse?> UpdateShopAsync(int id, UpdateShopRequest request)
    {
        var shop = await _context.Shops.FirstOrDefaultAsync(sh => sh.Id == id);

        if (shop is null) throw new ShopNotFoundException();

        _context.Shops.Update(shop);

        if (await _context.SaveChangesAsync() <= 0)
            throw new UnableToSaveShopChangesException();

        return shop.ResponseShop();
    }
}
