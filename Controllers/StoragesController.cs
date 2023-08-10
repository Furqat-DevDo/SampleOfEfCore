using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/storages/{id}/[controller]")]
[ApiController]
public class StoragesController : ControllerBase
{
    private readonly IStorageService _storageService;

    public StoragesController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    [HttpPost]
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
