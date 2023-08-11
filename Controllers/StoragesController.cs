using EfCore.Models.Requests;
using EfCore.Models.Responses;
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
    /// Here you can create new storage.
    /// </summary>
    /// <param name="request">Parametres of new storage</param>
    /// <response code="200">Returns the newly created storage</response>
    /// <response code="500">Returns when there was unable to create storage</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "name": "Uzum Storage",
    ///             "adrress": "Yunusobod, Amir Temur 119",
    ///             "productIds": null
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

    /// <summary>
    /// Here you can get storage with id.
    /// </summary>
    /// <param name="id"> Id of existing storage</param>
    /// <response code="200">Returns storage by id</response>
    /// <response code="404">Returns null when storage was not found</response>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStorageByIdAsync(uint id)
    {
        var response = await _storageService.GetStorageByIdAsync((int)id);
        return response is null ? NotFound() : Ok(response);
    }

    /// <summary>
    /// Here you can get all storages
    /// </summary>
    /// <response code="200">Returns all storages</response>
    /// <response code="404">Returns null when storage was not found</response>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllStoragesAsync()
    {
        return Ok(await _storageService.GetAllStoragesAsync());
    }


    /// <summary>
    /// Here you can delete existing storage by its id
    /// </summary>
    /// <param name="id">Id of existing storage</param>
    /// <response code="200">Deletes the storage with Id and returns true</response>
    /// <response code="404">Returns false when storage was not found</response>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStorageAsync(uint id)
    {
        var result = await _storageService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound();
    }


    /// <summary>
    /// Here you can update storage with id
    /// </summary>
    /// <param name="id">Id of existing storage</param>
    /// <param name="request">Parametrs of storage</param>
    /// <response code="200">Updated storage by id </response>
    /// <response code="404">Returns null when storage was not found</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         PUT
    ///         {
    ///             "name": "Uzum Storage",
    ///             "adrress": "Yunusobod, AMir Temur 119",
    ///             "productIds": [
    ///                             1
    ///             ]
    ///         }
    /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStorageAsync(uint id, [FromBody] UpdateStorageRequest request)
    {
        var result = await _storageService.UpdateStorageAsync((int)id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
