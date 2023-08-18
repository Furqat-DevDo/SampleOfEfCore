using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class CategoryMapper
{
    public static void UpdateCategory(this Category category, UpdateCategoryRequest request)
    {
        category.Name = request.Name;
        category.UpperId = request.UpperId;
        category.ImageId = request.ImageID;
        category.UpdatedDate = DateTime.UtcNow;
    }

    public static GetCategoryResponse ResponseCategory(this Category entitie)
    => new GetCategoryResponse
    {
            Id = entitie.Id,
            Name = entitie.Name,
            UpperId = entitie.UpperId,
            ImageId = entitie.ImageId,
            IsActive = entitie.IsDeleted,
            CreatedDate = entitie.CreatedDate,
            UpdatedDate = entitie.UpdatedDate,
    };

    public static Category CreateCategory(this CreateCategoryRequest entitie)
    => new Category
    {
            Name = entitie.Name,
            UpperId = entitie.UpperId,
            ImageId = entitie.ImageID,
    };
}
