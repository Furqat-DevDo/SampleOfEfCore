using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopsController : ControllerBase
{
    private readonly IShopService _shopService;

    public ShopsController(IShopService shopService)
    {
          _shopService = shopService;
    }

    /// <summary>
    /// Here you can create new shop.
    /// </summary>
    /// <param name="request">Parametres of new shop</param>
    /// <response code="200">Returns the newly created shop</response>
    /// <response code="500">Returns when there was unable to create shop</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "name": "Uzum Market",
    ///             "adrress": "Chilonzor",
    ///             "phone": "931871234",
    ///             "upperId": 0
    ///         }
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(GetCompanyResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateShopAsync(CreateShopRequest request)
    {
       var response = await _shopService.CreateShopAsync(request);
        return response is null ? 
            new StatusCodeResult(StatusCodes.Status500InternalServerError):
            Ok(response);
    }

    /// <summary>
    /// Here you can get shop with id.
    /// </summary>
    /// <param name="id"> Id of existing shop</param>
    /// <response code="200">Returns shop by id</response>
    /// <response code="404">Returns null when shop was not found</response>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShopByIdAsync(uint id)
    {
        var response = await  _shopService.GetShopByIdAsync((int)id);
        return response is null ? NotFound() : Ok(response);
    }

    /// <summary>
    /// Here you can get all shops
    /// </summary>
    /// <response code="200">Returns all shops</response>
    /// <response code="404">Returns null when shop was not found</response>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllShopsAsync()
    {
        return Ok(await _shopService.GetAllShopsAsync());
    }

    /// <summary>
    /// Here you can delete existinf shop by its id
    /// </summary>
    /// <param name="id">Id of existing shop</param>
    /// <response code="200">Deletes the shop with Id and returns true</response>
    /// <response code="404">Returns false when shop was not found</response>
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShopAsync(uint id)
    {
        var result = await _shopService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound();    
    }

    /// <summary>
    /// Here you can update shop with id
    /// </summary>
    /// <param name="id">Id of existing shop</param>
    /// <param name="request">Parametrs of shop</param>
    /// <response code="200">Updated shop by id </response>
    /// <response code="404">Returns null when shop was not found</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         PUT
    ///         {
    ///             "name": "Uzum Market",
    ///             "adrress": "Chilonzor",
    ///             "phone": "931871234",
    ///             "upperId": 0
    ///         }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShopAsync(uint id, [FromBody] UpdateShopRequest request)
    {
        var result = await  _shopService.UpdateShopAsync((int) id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
