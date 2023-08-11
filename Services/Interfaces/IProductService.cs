using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Services.Interfaces;

public interface IProductService
{
    Task<GetProductResponse> CreateProductAsync(CreateProductRequest request);
    Task<GetProductResponse?> UpdateProductAsync(int id, UpdateProductRequest request);
    Task<bool> DeleteAsync(int id);
    Task<GetProductResponse?> GetProductByIdAsync(int id);
    Task<IEnumerable<GetProductResponse>> GetAllProductsAsync();
}
