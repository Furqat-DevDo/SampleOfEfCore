using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProducsController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProducsController"/> class.
    /// </summary>
    /// <param name="productService">The product service.</param>
    public ProducsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Here you can create new product.
    /// </summary>
    /// <param name="request">Parametres of new product</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "name": "Coca Cola",
    ///             "categoryId": 1,
    ///             "companyId": 1,
    ///             "manufacturedDate": "2023-08-11T12:52:47.235Z",
    ///             "expireDate": "2023-10-11T12:52:47.235Z",
    ///             "price": 1000
    ///         }
    /// </remarks>
    /// <response code="200">Returns the newly created product</response>
    /// <response code="500">Returns when there was unable to create new product</response>
    [HttpPost]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProductAsync(CreateProductRequest request)
    {
        var response = await _productService.CreateProductAsync(request);
        return Ok(response);
    }

    /// <summary>
    /// Here you can get product by Id.
    /// </summary>
    /// <param name="id">Id of existing product</param>
    /// <response code="200">Returns the product which id = Id</response>
    /// <response code="404">Returns null when product was not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductByIdAsync(uint id)
    {
        var response = await _productService.GetProductByIdAsync((int)id);
        return Ok(response);
    }

    /// <summary>
    /// Here you can get all products.
    /// </summary>
    /// <response code="200">Returns all existing products or empty list if not</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }

    /// <summary>
    /// Here you can delete existing product by its Id.
    /// </summary>
    /// <param name="id">Id of existing product</param>
    /// <response code="200">Deletes the product which id = Id and returns true</response>
    /// <response code="404">Returns false when product was not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteProductAsync(uint id)
    {
        var result = await _productService.DeleteAsync((int)id);
        return Ok(result);
    }

    /// <summary>
    /// Here you can update the product with Id.
    /// </summary>
    /// <param name="id">Id of existing product</param>
    /// <param name="request">New parameters for updating product</param>
    /// <response code="200">Returns updated product with Id</response>
    /// <response code="404">Returns null when product was not found</response>
    /// /// <remarks >
    /// Sample request:
    ///
    ///         PUT
    ///         {
    ///             "name": "Coca Cola",
    ///             "categoryId": 1,
    ///             "companyId": 1,
    ///             "manufacturedDate": "2023-08-11T12:52:47.235Z",
    ///             "expireDate": "2023-10-11T12:52:47.235Z",
    ///             "price": 1000
    ///         }
    /// </remarks>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProductAsync(uint id, [FromBody] UpdateProductRequest request)
    {
        var result = await _productService.UpdateProductAsync((int)id, request);
        return Ok(result);
    }
}