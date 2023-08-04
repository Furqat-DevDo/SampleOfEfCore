namespace EfCore.Controllers;
using EfCore.Models.Requests;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ProducsController : ControllerBase 
{
    private readonly IProductInterface _productService;

    public ProducsController(IProductInterface productService)
    {
        _productService = productService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
    {
        var response = await _productService.CreateProductAsync(request);
        return response is null ? 
            new StatusCodeResult(StatusCodes.Status500InternalServerError):
            Ok(response);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductByIdAsync(uint id)
    {
        var response = await  _productService.GetProductByIdAsync((int)id);
        return response is null ? NotFound() : Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync(uint id)
    {
        var result = await _productService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound();    
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(uint id, [FromBody] UpdateProductRequest request)
    {
        var result = await  _productService.UpdateProductAsync((int) id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
