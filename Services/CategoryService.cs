using EfCore.Data;
using EfCore.Entities;
using EfCore.Exceptions;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class CategoryService : ICategoryService
{
    private readonly ShopDbContext _context;
    public CategoryService(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryResponse> CreateCategoryAsync(CreateCategoryRequest categoryRequest)
    {
        var category = new Category
        {
            Name = categoryRequest.Name,
            UpperId = categoryRequest.UpperId,
            ImageId= categoryRequest.ImageID ,
        };
        var newCategory = await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return new GetCategoryResponse();
    }

    public async Task<bool> DeletedCategoryAsync(int id)
    {
        var category=await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
        if (category == null) throw new CategoryNotFoundException();

        category.IsDeleted = true;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<GetCategoryResponse>> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories.Select(x => new GetCategoryResponse()).ToList();
    }

    public async Task<GetCategoryResponse?> GetCategoryByIdAsync(int id)
    {
        var category=await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if (category is null)
        {
            throw new CategoryNotFoundException();
        }
            return new GetCategoryResponse();
    }

    public async Task<GetCategoryResponse?> UpdateCategoryAsync(int id, UpdateCategoryRequest update_request)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category == null) throw new CategoryNotFoundException();

        category.Name = update_request.Name;
        category.UpperId = update_request.UpperId;

        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return new GetCategoryResponse();

    }
}
