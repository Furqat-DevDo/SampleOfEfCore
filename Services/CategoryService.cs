using EfCore.Data;
using EfCore.Entities;
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



        public async Task<GetCategoryResponse> CreateCategoryAsync(CreateCategoryRequest categoryRequest)
        {

            var category = categoryRequest.CreateCategory();

            var newCategory = await _context.Categories
                .AddAsync(category);
            await _context.SaveChangesAsync();

            return newCategory.Entity.ResponseCategory();

        }

        public async Task<bool> DeletedCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return false;

            category.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GetCategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories.Any() ?
                categories.Select(p => p.ResponseCategory())
                : new List<GetCategoryResponse>();
        }

        public async Task<GetCategoryResponse?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories
            .FirstOrDefaultAsync(sh => sh.Id == id);

            return category is null ? null : category.ResponseCategory();

        }

        public async Task<GetCategoryResponse?> UpdateCategoryAsync(int id, UpdateCategoryRequest update_request)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;

            category.Name = update_request.Name;
            category.UpperId = update_request.UpperId;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category.ResponseCategory();

        }
    }
}
