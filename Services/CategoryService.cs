using EfCore.Data;
using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext context;
        public CategoryService(ShopDbContext _context)
        {
            context = _context;
        }


        public async Task<GetCategoryResponse> CreateCategoryAsync(CreateCategoryRequest categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                UpperId = categoryRequest.UpperId,
                //ImageId= (Guid?)categoryRequest.ImageId,
            };
            var newCategory = await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return new GetCategoryResponse(newCategory.Entity);


        }

        public async Task<bool> DeletedCategoryAsync(int id)
        {
            var category=await context.Categories.LastOrDefaultAsync(x=>x.Id==id);
            if (category == null) return false;

            category.IsDeleted = true;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<GetCategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await context.Categories.ToListAsync();
            return categories.Select(x => new GetCategoryResponse(x)).ToList();
        }

        public async Task<GetCategoryResponse> GetCategoryByIdAsync(int id)
        {
            var category=await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return category == null ? null : new GetCategoryResponse(category);

        }

        public async Task<GetCategoryResponse?> UpdateCategoryAsync(int id, UpdateCategoryRequest update_request)
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return null;
            
            category.Name = update_request.Name;
           // category.ImageId = (Guid?)update_request.ImageId;
            category.UpperId = update_request.UpperId;

            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return new GetCategoryResponse(category);

        }
    }
}
