
namespace EfCore.Controllers;
using EfCore.Models.Requests;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ProducsController : ControllerBase 
{
    private readonly IProductService _productService;

    public ProducsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Siz yangi product yaratishiz mumkin!
    /// </summary>
    /// <param name="product"></param>
    /// <response code="200">Returns the newly created product</response>
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
    {
        var response = await _productService.CreateProductAsync(request);
        return response is null ? 
            new StatusCodeResult(StatusCodes.Status500InternalServerError):
            Ok(response);
    }

    /// <summary>
    /// Id orqali productni olishingiz mumkin!
    /// </summary>
    /// <param name="product"></param>
    /// <response code="200">Returns the product with Id</response>
    /// <response code="404">Returns null when product was not found</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(uint id)
    {
        var response = await  _productService.GetProductByIdAsync((int)id);
        return response is null ? NotFound(null) : Ok(response);
    }

    /// <summary>
    /// Barcha productlarni olishingiz mumkin!
    /// </summary>
    /// <param name="product"></param>
    /// <response code="200">Returns all products</response>
    /// <response code="404">Returns null when products was not found</response>
    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }

    /// <summary>
    /// Id orqali productni o'chirishingiz mumkin!
    /// </summary>
    /// <param name="product"></param>
    /// <response code="200">Deletes the product with Id</response>
    /// <response code="404">Returns null when product was not found</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(uint id)
    {
        var result = await _productService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound();    
    }

    /// <summary>
    /// Id orqali productni o'zgartirishingiz mumkin!
    /// </summary>
    /// <param name="product"></param>
    /// <response code="200">Returns updated product with Id</response>
    /// <response code="404">Returns null when product was not found</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(uint id, [FromBody] UpdateProductRequest request)
    {
        var result = await  _productService.UpdateProductAsync((int) id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
