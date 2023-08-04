using EfCore.Models.Requests;
using EfCore.Models.Responses;
namespace EfCore.Services.Interfaces;

public interface ICategoryImageService
{
    Task<GetCategoryImageResponse> CreateCategoryImageAsync(CreateCategoryImageRequest request);
	Task<IEnumerable<GetCategoryImageResponse>> GetAllCategoryImagesAsync();
	Task<GetCategoryImageResponse?> GetCategoryImageByIdAsync(int id);
	Task<bool> DeleteAsync(int id);
	Task<GetCategoryImageResponse?> UpdateCategoryImageAsync(int id, UpdateCategoryImageRequest request);
}
