using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface ICategoryImageService
    {
        Task<GetCategoryImageResponse> CreateAsync(int id, CreateCategoryImageRequest request);
        byte[] ReadFileFromPathAsync(string filePath);
    }
}
