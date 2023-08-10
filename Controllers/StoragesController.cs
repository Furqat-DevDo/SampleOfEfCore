using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoragesController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StoragesController(IStorageService storageService)
    {
        _storageService = storageService;
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
    public async Task<IActionResult> CreateStorageAsync(CreateStorageRequest request)
    {
        var response = await _storageService.CreateStorageAsync(request);
        return response is null ?
            new StatusCodeResult(StatusCodes.Status500InternalServerError) :
            Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStorageByIdAsync(uint id)
    {
        var response = await _storageService.GetStorageByIdAsync((int)id);
        return response is null ? NotFound() : Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStoragesAsync()
    {
        return Ok(await _storageService.GetAllStoragesAsync());
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStorageAsync(uint id)
    {
        var result = await _storageService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStorageAsync(uint id, [FromBody] UpdateStorageRequest request)
    {
        var result = await _storageService.UpdateStorageAsync((int)id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
