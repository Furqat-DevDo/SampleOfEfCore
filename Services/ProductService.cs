using EfCore.Data;
using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace EfCore.Services;

public class ProductService : IProductInterface
{
    private readonly ShopDbContext _context;
    public ProductService(ShopDbContext context)
    {
        _context = context;
    }

    public async Task<GetProductResponse> CreateProductAsync(CreateProductRequest request)
    {
        var product = new Product()
        {
            Name = request.Name,
            ImageSrc = request.ImageSrc,
            Categories = request.Categories,
            ManufacturedDate = request.ManufacturedDate,
            ExpireDate = request.ExpireDate,
            Companies = request.Companies,
            Price = request.Price,
            CategoryId = request.CategoryId,
            CompanyId = request.CompanyId,
        };

        var newProduct = await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return new GetProductResponse(newProduct.Entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product is null) return false;

        product.IsDeleted = true;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<GetProductResponse>> GetAllProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products.Any() ?
            products.Select(p => new GetProductResponse(p))
            : new List<GetProductResponse>();
    }

    public async Task<GetProductResponse?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(sh => sh.Id == id);

        return product is null ? null : new GetProductResponse(product);
    }

    public async Task<GetProductResponse?> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        var product = await _context.Products.FirstOrDefaultAsync(sh => sh.Id == id);
        if (product is null) return null;

        product.Name = request.Name;
        product.ImageSrc = request.ImageSrc;
        product.Categories = request.Categories;
        product.ManufacturedDate = request.ManufacturedDate;
        product.ExpireDate = request.ExpireDate;
        product.Companies = request.Companies;
        product.Price = request.Price;
        product.CategoryId = request.CategoryId;
        product.CompanyId = request.CompanyId;

        _context.Products.Update(product);
        _context.SaveChanges();
        return new GetProductResponse(product);
    }
}
