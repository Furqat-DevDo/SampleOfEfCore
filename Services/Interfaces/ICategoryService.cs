using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces
{
    public interface ICategoryService
    {
         Task<IEnumerable<GetCategoryResponse>> GetAllCategoriesAsync();
         Task<GetCategoryResponse?> GetCategoryByIdAsync(int id);
         Task<bool> DeletedCategoryAsync(int id);
         Task<GetCategoryResponse?> CreateCategoryAsync(CreateCategoryRequest categoryRequest);
         Task<GetCategoryResponse?> UpdateCategoryAsync(int id, UpdateCategoryRequest update_request);
    }
}
