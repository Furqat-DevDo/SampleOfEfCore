using EfCore.Data;
using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfCore.Services
{
    public class CategoryImageService : ICategoryImageService
    {
        private readonly ShopDbContext _context;
        public CategoryImageService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryImageResponse> CreateCategoryImageAsync(CreateCategoryImageRequest request)
        {
            var categoryimage = new CategoryImage
            {
                CategoryId = request.CategoryId
            };

            var newCategoryImage = await _context.CategoryImages.AddAsync(categoryimage);
            await _context.SaveChangesAsync();

            return new GetCategoryImageResponse(newCategoryImage.Entity);

        }

        public async Task<IEnumerable<GetCategoryImageResponse>> GetAllCategoryImagesAsync()
        {
            var categoryimages = await _context.CategoryImages.ToListAsync();
            return categoryimages.Any() ?
                categoryimages.Select(sh => new GetCategoryImageResponse(sh))
                : new List<GetCategoryImageResponse>();
        }

        public async Task<GetCategoryImageResponse?> GetCategoryImageByIdAsync(int id)
        {
            var categoryimage = await _context.CategoryImages
                .Include(x => x.CategoryId)
                .FirstOrDefaultAsync(sh => sh.CategoryId == id);

            return categoryimage is null ? null : new GetCategoryImageResponse(categoryimage);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var categoryimage = await _context.CategoryImages.FirstOrDefaultAsync(sh => sh.CategoryId == id);
            if (categoryimage is null) return false;

            categoryimage.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<GetCategoryImageResponse?> UpdateCategoryImageAsync(int id, UpdateCategoryImageRequest request)
        {
            var categoryimage = await _context.CategoryImages.FirstOrDefaultAsync(sh => sh.CategoryId == id);
            if (categoryimage is null) return null;

            categoryimage.CategoryId = (int)request.CategoryId;
            categoryimage.UpdatedDate = DateTime.UtcNow;
            

            _context.CategoryImages.Update(categoryimage);
            _context.SaveChanges();
            return new GetCategoryImageResponse(categoryimage);
        }
    }
}
