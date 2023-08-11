using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers
{
    public static class CategoryMapper
    {
        public static void UpdateCategory(this Category category, UpdateCategoryRequest request)
        {
            category.Name = request.Name;
            category.UpperId = request.UpperId;
            category.UpdatedDate=request.UpdateDate;
        }

        public static GetCategoryResponse ResponseCategory(this Category entitie)
        => new GetCategoryResponse
        {
            Id = entitie.Id,
            Name = entitie.Name,
            UpperId = entitie.UpperId,
            IsActive = entitie.IsDeleted,
            CreatedDate = entitie.CreatedDate,
            UpdatedDate = entitie.UpdatedDate

        };



        public static Category CreateCategory(this CreateCategoryRequest category)
        => new Category
        {
            UpperId = category.UpperId,
            Name = category.Name,
            CreatedDate=category.CreateDate

        };
    }
}

