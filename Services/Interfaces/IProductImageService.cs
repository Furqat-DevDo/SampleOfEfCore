using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface IProductImageService
{
    Task<GetProductImageResponse?> CreateAsync(int id, CreateProductImageRequest request);
    Task<bool> DeleteProductImage(Guid fileId);
    Task<IEnumerable<GetProductImageResponse>> GetProductFilesAsync(int id);
    public Task<(byte[] bytes,string[] fileInfo)> ReadFileFromPathAsync(string filePath);
}
