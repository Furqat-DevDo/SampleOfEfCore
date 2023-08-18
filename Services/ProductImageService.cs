using EfCore.Data;
using EfCore.Exceptions;
using EfCore.Helpers;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class ProductImageService : IProductImageService
{
    private readonly ShopDbContext _shopContext;
    private readonly ILogger<ProductImageService> _logger;

    public ProductImageService(ShopDbContext shopDbContext, ILogger<ProductImageService> logger)
    {
        _shopContext = shopDbContext;
        _logger = logger;
    }

    public async Task<GetProductImageResponse?> CreateAsync(int id,
        CreateProductImageRequest request)
    {
        
        var (filePath, fileId) = await FileHelper.SaveFormFileAsync(request.ProductFile);

        var newProductFile = request.ToEntity(id, filePath, fileId);

        var result = await _shopContext.ProductImages.AddAsync(newProductFile); 

        if(await _shopContext.SaveChangesAsync() <= 0) 
            throw new UnableToSaveImageChangesExeption();

        return result.Entity.ToResponse(); 
    }

    public async Task<IEnumerable<GetProductImageResponse>> GetProductFilesAsync(int id)
    {
        var images = await _shopContext.ProductImages
            .Where(s => s.ProductId == id)
            .AsNoTracking()
            .ToListAsync();

        return images.Any() ? images.Select(i => i.ToResponse()) :
            Enumerable.Empty<GetProductImageResponse>();
    }

    public async Task<(byte[] bytes, string[] fileInfo)> ReadFileFromPathAsync(string filePath)
    {
        var bytes = await FileHelper.ReadFileFromPathAsync(filePath);
        if(!bytes.Any())
        {
            _logger.LogCritical($"Empty file is loaded from {filePath}");
        }

        var fileInfo = new string[] {
            GetContentType(Path.GetExtension(filePath)),
            Path.GetFileName(filePath) };

        return new(bytes, fileInfo);
    }

    private static readonly Dictionary<string, string> _contentTypes = new Dictionary<string, string>
    {
        { ".jpg", "image/jpeg" },
        { ".jpeg", "image/jpeg" },
        { ".png", "image/png" },
        { ".gif", "image/gif" },
        { ".pdf", "application/pdf" }
    };

    private string GetContentType(string fileExtension)
    {
        return _contentTypes.TryGetValue(fileExtension.ToLower(), out var contentType) ? contentType : "application/octet-stream";
    }

    public async Task<bool> DeleteProductImage(Guid fileId)
    {
        var result = await _shopContext.ProductImages.FirstOrDefaultAsync(x => x.Id == fileId);
        
        if (result is null)
        {
            _logger.LogError($"file with Id = {fileId} not found on deleting !!!");
            throw new ProductImageNotFoundExeption();
        }            
        
        result.IsDeleted = true;

        if (await _shopContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveImageChangesExeption();

        return true;
    }
}
