
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
    /// Here you can create new product.
    /// </summary>
    /// <param name="request">Parametres of new product</param>
    /// <response code="200">Returns the newly created product</response>
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
    {
        var response = await _productService.CreateProductAsync(request);
        return response is null ?
            new StatusCodeResult(StatusCodes.Status500InternalServerError) :
            Ok(response);
    }

    /// <summary>
    /// Here you can get product by Id.
    /// </summary>
    /// <param name="id">Id of existing product</param>
    /// <response code="200">Returns the product with Id</response>
    /// <response code="404">Returns null when product was not found</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(uint id)
    {
        var response = await _productService.GetProductByIdAsync((int)id);
        return response is null ? NotFound(response) : Ok(response);
    }

    /// <summary>
    /// Here you can get all products.
    /// </summary>
    /// <response code="200">Returns all products</response>
    /// <response code="404">Returns null when products was not found</response>
    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }

    /// <summary>
    /// Here you can delete existing product by its Id.
    /// </summary>
    /// <param name="id">Id of existing product</param>
    /// <response code="200">Deletes the product with Id and returns true</response>
    /// <response code="404">Returns false when product was not found</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(uint id)
    {
        var result = await _productService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound(result);
    }

    /// <summary>
    /// Here you can update the product with Id.
    /// </summary>
    /// <param name="id">Id of existing product</param>
    /// <param name="request"></param>
    /// <response code="200">Returns updated product with Id</response>
    /// <response code="404">Returns null when product was not found</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(uint id, [FromBody] UpdateProductRequest request)
    {
        var result = await _productService.UpdateProductAsync((int)id, request);
        return result is null ? NotFound(result) : Ok(result);
    }
}
