using EfCore.Data;
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
    private readonly ILogger<ProductService> _logger;
    public ProductService(ShopDbContext shopDbContext, ILogger<ProductService> logger)
    {
        _shopDbContext = shopDbContext;
        _logger = logger;
    }
    public async Task<GetProductResponse> CreateProductAsync(CreateProductRequest request)
    {
        var product = request.CreateProduct();

        var company = _shopDbContext.Companies.FirstOrDefault(c=>c.Id == request.CompanyId);
        if (company == null)
        {
            _logger.LogError($"Company with Id = {request.CompanyId}" +
                $" for product: {request.Name} not found !!!");
            throw new CompanyNotFoundException();
        }

        var category = _shopDbContext.Categories.FirstOrDefault(c => c.Id == request.CategoryId);
        if (category is null)
        {
            _logger.LogError($"Category with Id = {request.CompanyId}" +
                $" for product: {request.Name} not found !!!");
            throw new CategoryNotFoundException();
        }

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

        if (product is null)
        {
            _logger.LogError($"Unable to delete product. Product with Id = {id} not found !!!"); 
            throw new ProductNotFoundException();
        }
            

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

        if (product is null)
        {
            _logger.LogError($"Product with Id = {id} not found");
            throw new ProductNotFoundException();
        }
        
        return product.ResponseProduct();
    }

    public async Task<GetProductResponse?> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        var product = await _shopDbContext.Products
            .FirstOrDefaultAsync(sh => sh.Id == id);
        if (product is null)
        {
            _logger.LogError($"Product with Id = {id} not found");
            throw new ProductNotFoundException();
        }
         

        product.UpdateProduct(request);

        _shopDbContext.Products.Update(product);
        if (await _shopDbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveProductChangesException();
        return product.ResponseProduct();
    }
}
