using EfCore.Data;
using EfCore.Helpers;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EfCore.Services;

public class CategoryImageService : ICategoryImageService
{
    private readonly ShopDbContext _shopContext;
    public CategoryImageService(ShopDbContext shopDbContext)
    {
        _shopContext = shopDbContext;
    }
    public async Task<GetCategoryImageResponse> CreateAsync(int id,
        CreateCategoryImageRequest request)
    {
        var (filePath, fileId) = await FileHelper.SaveFormFileAsync(request.CategoryFile);

        if(filePath is null)
            throw new ArgumentNullException(nameof(filePath));

        var newCategoryFile = request.ToEntity(id, filePath, fileId);

        var result = await _shopContext.CategoryImages.AddAsync(newCategoryFile);

        await _shopContext.SaveChangesAsync();

        return result.Entity.ToResponse();
    }
}
