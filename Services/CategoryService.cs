using EfCore.Data;
using EfCore.Exceptions;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext _context;
        public CategoryService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryResponse?> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var category = request.CreateCategory();

            var newCategory = await _context.Categories
                .AddAsync(category); ;

            if (await _context.SaveChangesAsync() <= 0 || category.UpperId<=0)
                throw new UnableToSaveShopChangesException();
            
            return  newCategory.Entity.ResponseCategory();
        }

        public async Task<IEnumerable<GetCategoryResponse>> GetAllCategoriesAsync()
        {
            var category = await _context
                .Categories
                .ToListAsync();

            return category.Any() ? category.Select(c => c.ResponseCategory())
                : new List<GetCategoryResponse>();
        }
        public async Task<GetCategoryResponse?> GetCategoryByIdAsync(int id)
        {
            var category = await _context
                .Categories
                .FirstOrDefaultAsync(p => p.Id == id);

            return category is null ? throw new CategoryNotFoundException() : category.ResponseCategory();
        }
        public async Task<GetCategoryResponse?> UpdateCategoryAsync(int id, UpdateCategoryRequest request)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (category is null || category?.UpperId<=0)
                throw new CategoryNotFoundException();

            category?.UpdateCategory(request);
            _context.SaveChanges();

            return category?.ResponseCategory();
        }
        public async Task<bool> DeletedCategoryAsync(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(p => p.Id == id);

            if (category is null)
                throw new CategoryNotFoundException();

            category.IsDeleted = true;
            return _context.SaveChanges() > 0;
        }
    }
}
