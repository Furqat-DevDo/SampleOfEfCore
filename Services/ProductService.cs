using EfCore.Data;
using EfCore.Mappers;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Services;

public class ProductService : IProductService
{
    private readonly ShopDbContext _shopDbContext;
    public ProductService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<GetProductResponse> CreateProductAsync(CreateProductRequest request)
    {
        var product = request.CreateProduct();

        var newProduct = await _shopDbContext.Products
            .AddAsync(product);
        await _shopDbContext.SaveChangesAsync();

        return newProduct.Entity.ResponseProduct();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _shopDbContext.Products
            
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) return false;

        product.IsDeleted = true;
        return await _shopDbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<GetProductResponse>> GetAllProductsAsync()
    {
        var products = await _shopDbContext.Products.ToListAsync();
        return products.Any() ?
            products.Select(p => p.ResponseProduct())
            : new List<GetProductResponse>();
    }

    public async Task<GetProductResponse?> GetProductByIdAsync(int id)
    {
        var product = await _shopDbContext.Products
            .FirstOrDefaultAsync(sh => sh.Id == id);

        return product is null ? null : product.ResponseProduct();
    }

    public async Task<GetProductResponse?> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        var product = await _shopDbContext.Products
            .FirstOrDefaultAsync(sh => sh.Id == id);
        if (product is null) return null;

        product.UpdateProduct(request);

        _shopDbContext.Products.Update(product);
        _shopDbContext.SaveChanges();
        return product.ResponseProduct();
    }
}
