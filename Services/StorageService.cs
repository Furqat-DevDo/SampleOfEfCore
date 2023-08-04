using EfCore.Data;
using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;
    
public class StorageService : IStorageService
{
    private readonly ShopDbContext _context;
    public StorageService(ShopDbContext context)
    {
        _context = context;
    }

    public async  Task<GetStorageResponse> CreateStorageAsync(CreateStorageRequest request)
    {
        var storage = new Storage 
        { 
            Address = request.Address,
            Name = request.Name,
            
        };

        var newStorage = await _context.Storages.AddAsync(storage);
        await _context.SaveChangesAsync();

        return new GetStorageResponse(newStorage.Entity);
        
    }



    public async  Task<bool> DeleteAsync(int id)
    {
        var storage = await _context.Storages.FirstOrDefaultAsync(sh => sh.Id == id);
        if (storage is null) return false;

        storage.IsDeleted = true;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<GetStorageResponse>> GetAllStorageAsync()
    {
        var storages = await  _context.Storages.ToListAsync();
        return storages.Any() ? 
            storages.Select(sh => new GetStorageResponse(sh)) 
            : new List<GetStorageResponse>(); 
    }

    public async Task<GetStorageResponse?> GetStorageByIdAsync(int id)
    {
        var storage = await _context.Storages
            .Include(x => x.ProductIds)
            .FirstOrDefaultAsync(sh => sh.Id== id);

        return storage is null ? null : new GetStorageResponse(storage);
    }

    public async  Task<GetStorageResponse?> UpdateStorageAsync(int id, UpdateStorageRequest request)
    {
        var storage = await _context.Storages.FirstOrDefaultAsync(sh => sh.Id == id);
        if (storage is null) return null;

        storage.Name = request.Name;
        storage.UpdatedDate = DateTime.UtcNow;
        storage.Address = request.Address;
        
        _context.Storages.Update(storage);
        _context.SaveChanges();
        return new GetStorageResponse(storage);
    }
}

