using EfCore.Data;
using EfCore.Helpers;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;

namespace EfCore.Services;

public class ProductImageService : IProductImageService
{
    private readonly ShopDbContext _shopContext;
    public ProductImageService(ShopDbContext shopDbContext)
    {
         _shopContext = shopDbContext;
    }
    public async  Task<GetProductImageResponse> CreateAsync(int id, 
        CreateProductImageRequest request)
    {
        var (filePath,fileId) = await FileHelper.SaveFormFileAsync(request.ProductFile);

        //TODO check output result for null !!!
        var newProductFile = request.ToEntity(id,filePath,fileId);

        var result = await _shopContext.ProductImages.AddAsync(newProductFile);

        await _shopContext.SaveChangesAsync();

        return result.Entity.ToResponse(); 
    }

    public byte[] ReadFileFromPathAsync(string filePath)
    {
        return FileHelper.ReadFileFromPathAsync(filePath);
    }
}
