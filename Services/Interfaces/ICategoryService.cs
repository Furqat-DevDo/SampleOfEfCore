using EfCore.Entities;

namespace EfCore.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategories();
        public Task<Category> GetCategory(int id);
        public Task<Category> DeletedCategory(int id);
        public Task<Category> CreateCategory(Category category);
        public Task<Category> UpdateCategory(int id, Category category);
    }
}
