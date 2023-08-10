using EfCore.Data;
using EfCore.Helpers;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class ProductImageService : IProductImageService
{
    private readonly ShopDbContext _shopContext;
    public ProductImageService(ShopDbContext shopDbContext)
    {
        _shopContext = shopDbContext;
    }

    public async Task<GetProductImageResponse> CreateAsync(int id,
        CreateProductImageRequest request)
    {
        var (filePath, fileId) = await FileHelper.SaveFormFileAsync(request.ProductFile);

        var newProductFile = request.ToEntity(id, filePath, fileId);

        var result = await _shopContext.ProductImages.AddAsync(newProductFile);

        await _shopContext.SaveChangesAsync();

        return result.Entity.ToResponse();
    }

    public async Task<IEnumerable<GetProductImageResponse>> GetProductFilesAsync(int id)
    {
        var images = await _shopContext.ProductImages
            .Where(s => s.ProductId == id)
            .ToListAsync();

        return images.Any() ? images.Select(i => i.ToResponse()) :
            new List<GetProductImageResponse>();
    }

    public async Task<(byte[] bytes, string[] fileInfo)> ReadFileFromPathAsync(string filePath)
    {
        var bytes = await FileHelper.ReadFileFromPathAsync(filePath);
        var fileInfo = new string[] {
            GetContentType(Path.GetExtension(filePath)),
            Path.GetFileName(filePath) };

        return new(bytes, fileInfo);
    }

    private string GetContentType(string fileExtension)
    {
        switch (fileExtension.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            case ".pdf":
                return "application/pdf";

            default:
                return "application/octet-stream";
        }
    }

    public async Task<bool> DeleteProductImage(Guid fileId)
    {
        var result = await _shopContext.ProductImages.FirstOrDefaultAsync(x => x.Id == fileId);
        
        if (result is null) return false;
        
        result.IsDeleted = true;
        return await _shopContext.SaveChangesAsync() > 0;
    }
}
