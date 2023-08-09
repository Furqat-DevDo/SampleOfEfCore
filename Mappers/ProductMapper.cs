using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class ProductMapper
{
    public static void UpdateProduct(this Product product, UpdateProductRequest request)
    {
        product.CategoryId = request.CategoryId;
        product.CompanyId = request.CompanyId;
        product.Name = request.Name;
        product.ExpireDate = request.ExpireDate;
        product.ManafactureDate = request.ManufacturedDate;
        product.Price = request.Price;
    }

    public static GetProductResponse ToResponseProduct(this Product product)
    => new GetProductResponse
    {
        CategoryId = product.CategoryId,
        CompanyId = product.CompanyId,
        Name = product.Name,
        ExpireDate = product.ExpireDate,
        ManufacturedDate = product.ManafactureDate,
        Price = product.Price
    };

    public static Product ToCreateProduct(this CreateProductRequest product)
    => new Product
    {
        CategoryId = product.CategoryId,
        CompanyId = product.CompanyId,
        Name = product.Name,
        ExpireDate = product.ExpireDate,
        ManafactureDate = product.ManufacturedDate,
        Price = product.Price
    };
}
