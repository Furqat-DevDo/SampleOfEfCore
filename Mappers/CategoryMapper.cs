using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

public static class CategoryMapper
{
    public static GetCategoryResponse ResponseCategory(this Category category)
    => new GetCategoryResponse
    {
            Id = category.Id,
            Name = category.Name,
            UpperId = category.UpperId,
            CreatedDate = category.CreatedDate,
            UpdatedDate = category.UpdatedDate
    };

    public static Category CreateCategory(this CreateCategoryRequest category)
   => new Category
   {

       UpperId = category.UpperId,
       Name = category.Name,

   };

    public static void UpdateCategory(this Category category, UpdateCategoryRequest request)
    {
            category.Name = request.Name;
            category.UpperId = request.UpperId;
    }
}
