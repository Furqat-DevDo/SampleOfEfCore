﻿using EfCore.Data;
using EfCore.Exceptions;
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

        var company = _shopDbContext.Companies.FirstOrDefault(c=>c.Id == request.CompanyId);
        if (company == null) throw new CompanyNotFoundException();

        var category = _shopDbContext.Categories.FirstOrDefault(c => c.Id == request.CategoryId);
        if (category is null) throw new CategoryNotFoundException();

        var newProduct = await _shopDbContext.Products
            .AddAsync(product);

        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveProductChangesException();

        return newProduct.Entity.ResponseProduct();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _shopDbContext.Products            
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null) throw new ShopNotFoundException();

        product.IsDeleted = true;

        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveProductChangesException();

        return true;
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

        return product is null ? throw new ProductNotFoundException() 
            : product.ResponseProduct();
    }

    public async Task<GetProductResponse?> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        var product = await _shopDbContext.Products
            .FirstOrDefaultAsync(sh => sh.Id == id);
        if (product is null) throw new ProductNotFoundException();

        product.UpdateProduct(request);

        _shopDbContext.Products.Update(product);
        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveProductChangesException();
        return product.ResponseProduct();
    }
}
