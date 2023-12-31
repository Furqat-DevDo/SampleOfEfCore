﻿using EfCore.Data;
using EfCore.Exceptions;
using EfCore.Helpers;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        _ = filePath ?? throw new UnableToCreateCategoryImageException(nameof(filePath));          

        var newCategoryFile = request.ToEntity(id, filePath, fileId);

        var result = await _shopContext.CategoryImages.AddAsync(newCategoryFile);

        if(await _shopContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveImageChangesExeption();

        return result.Entity.ToResponse();
    }

    public async Task<IEnumerable<GetCategoryImageResponse>> GetCategoryFilesAsync(int id)
    {
        var images = await _shopContext.CategoryImages
            .AsNoTracking()
            .Where(s => s.CategoryId == id)
            .ToListAsync();
    
        return images.Any() ? images.Select(i => i.ToResponse()) :
            Enumerable.Empty<GetCategoryImageResponse>();
    }

    public async Task<(byte[] bytes, string[] fileInfo)> ReadFileFromPathAsync(string filePath)
    {
        var bytes = await FileHelper.ReadFileFromPathAsync(filePath);
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

    public async Task<bool> DeleteCategoryImage(Guid fileId)
    {
        var result = await _shopContext.CategoryImages.FirstOrDefaultAsync(x => x.Id == fileId) ?? throw new CategoryImageNotFoundExeption();
        result.IsDeleted = true;
        return await _shopContext.SaveChangesAsync() > 0;
    }
}
