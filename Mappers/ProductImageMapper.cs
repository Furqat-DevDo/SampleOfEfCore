using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class ProductImageMapper
{
    public static GetProductImageResponse ToResponse(this ProductImage image)
    => new GetProductImageResponse 
    { 
        ProductId = image.ProductId,
        FileId = image.Id,
        FileSrc = image.Src
    };

    public static ProductImage ToEntity(this CreateProductImageRequest request,
        int id,
        string filePath,
        Guid fileId) 
        =>new ProductImage
        {
            ProductId = id,
            Id = fileId,
            Src = filePath,
            Size = request.ProductFile.Length,
            Extension = Path.GetExtension(request.ProductFile.FileName)
        };

}
