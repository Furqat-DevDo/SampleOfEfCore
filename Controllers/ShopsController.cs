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
    /// Here you can create new company.
    /// </summary>
    /// <param name="request">Parametres of new company</param>
    /// <response code="200">Returns the newly created company</response>
    /// <response code="500">Returns when there was unable to create company</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST /Todo
    ///         {
    ///             "Name":"Coca Cola",
    ///             "ClosedDate" : null,
    ///             "UpperId" : null
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


    [HttpGet("{id}")]
    public async Task<IActionResult> GetShopByIdAsync(uint id)
    {
        var response = await  _shopService.GetShopByIdAsync((int)id);
        return response is null ? NotFound() : Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllShopsAsync()
    {
        return Ok(await _shopService.GetAllShopsAsync());
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShopAsync(uint id)
    {
        var result = await _shopService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound();    
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShopAsync(uint id, [FromBody] UpdateShopRequest request)
    {
        var result = await  _shopService.UpdateShopAsync((int) id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
