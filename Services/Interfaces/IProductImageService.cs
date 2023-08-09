using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface IProductImageService
{
    Task<GetProductImageResponse> CreateAsync(int id, CreateProductImageRequest request);
    public byte[] ReadFileFromPathAsync(string filePath);
}
