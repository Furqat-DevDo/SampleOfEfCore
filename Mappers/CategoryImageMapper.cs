using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class CategoryImageMapper
{
    public static GetCategoryImageResponse ToResponse(this CategoryImage image)
    => new GetCategoryImageResponse
    {
        CategoryId = image.CategoryId,
        FileId = image.Id,
        FileSrc = image.Src
    };

    public static CategoryImage ToEntity(this CreateCategoryImageRequest request,
        int id,
        string filePath,
        Guid fileId)
        => new CategoryImage
        {
            CategoryId = id,
            Id = fileId,
            Src = filePath,
            Size = request.CategoryFile.Length,
            Extension = Path.GetExtension(request.CategoryFile.FileName)
        };

}
