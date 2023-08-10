using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class ProductMapper
{
    public static void UpdateProduct(this Product product, UpdateProductRequest request)
    {
        product.Name = request.Name;
        product.ExpireDate = request.ExpireDate;
        product.ManufacturedDate = request.ManufacturedDate;
        product.CategoryId = request.CategoryId;
        product.CompanyId = request.CompanyId
        product.Price = request.Price;
    }

    public static GetProductResponse ResponseProduct(this Product product)
    => new GetProductResponse
    {
        Name = product.Name,
        ExpireDate = product.ExpireDate,
        ManufacturedDate = product.ManufacturedDate,
        CategoryId = product.CategoryId,
        CompanyId = product.CompanyId,
        Price = product.Price
    };

    public static Product CreateProduct(this CreateProductRequest product)
    => new Product
    {
        Name = product.Name,
        ExpireDate = product.ExpireDate,
        ManufacturedDate = product.ManufacturedDate,
        CategoryId = product.CategoryId,
        CompanyId = product.CompanyId,
        Price = product.Price
    };
}
