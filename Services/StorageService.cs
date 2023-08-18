using EfCore.Data;
using EfCore.Exceptions;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class StorageService : IStorageService
{
    private ILogger<StorageService> _logger;
    private readonly ShopDbContext _shopDbContext;
    public StorageService(ShopDbContext shopDbContext, ILogger<StorageService> logger)
    {
        _shopDbContext = shopDbContext;
        _logger = logger;
    }

    public async Task<GetStorageResponse> CreateStorageAsync(CreateStorageRequest request)
    {
        var storage = request.ToCreateStorage();
        
        var newStorage = await _shopDbContext.Storages.AddAsync(storage);

        if (await _shopDbContext.SaveChangesAsync() <= 0)
        {
            _logger.LogError($"storage was not created");
            throw new UnableToSaveStorageChangesException();
        }
            
        return newStorage.Entity.ToResponseStorage();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var storage = await _shopDbContext.Storages
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (storage is null)
        {
            _logger.LogError($"Unable to delete storage");
            throw new StorageNotFoundException();
        }

        storage.IsDeleted = true;

        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveStorageChangesException();
        
        return true;
    }

    public async Task<IEnumerable<GetStorageResponse>> GetAllStoragesAsync()
    {
        var storages = await _shopDbContext.Storages.ToListAsync();

        return storages.Any() ?
            storages.Select(p => p.ToResponseStorage())
            : new List<GetStorageResponse>();
    }

    public async Task<GetStorageResponse?> GetStorageByIdAsync(int id)
    {
        var storage = await _shopDbContext.Storages
            .FirstOrDefaultAsync(s => s.Id == id);

        if(storage is null)
        {
            _logger.LogError($"this {id} does not exist");
            throw new StorageNotFoundException();
        }
        
        return storage.ToResponseStorage();
    }

    public async Task<GetStorageResponse?> UpdateStorageAsync(int id, UpdateStorageRequest request)
    {
        var storage = await _shopDbContext.Storages
            .FirstOrDefaultAsync(s => s.Id == id);

        if (storage is null)
        {
            _logger.LogError($"this {id} does not exist");
            throw new StorageNotFoundException();
        }

        storage.UpdateStorage(request);

        _shopDbContext.Storages.Update(storage);

        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveStorageChangesException();

        return storage.ToResponseStorage();
    }
}
