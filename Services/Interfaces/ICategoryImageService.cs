using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface ICategoryImageService
    {
        Task<GetCategoryImageResponse> CreateAsync(int id, CreateCategoryImageRequest request);
        Task<bool> DeleteCategoryImage(Guid fileId);
        Task<IEnumerable<GetCategoryImageResponse>> GetCategoryFilesAsync(int id);
        public Task<(byte[] bytes, string[] fileInfo)> ReadFileFromPathAsync(string filePath);
    }
}
