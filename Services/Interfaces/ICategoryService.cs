using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse> CreateCategoryAsync(CreateCategoryRequest categoryRequest);
        Task<bool> DeletedCategoryAsync(int id);
        Task<IEnumerable<GetCategoryResponse>> GetAllCategoriesAsync();
        Task<GetCategoryResponse?> GetCategoryByIdAsync(int id);
        Task<GetCategoryResponse?> UpdateCategoryAsync(int id, UpdateCategoryRequest update_request);

    }
}
