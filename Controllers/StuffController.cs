using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StuffController : ControllerBase
{
    private readonly IStuffService _stuffService;
    public StuffController(IStuffService stuffService)
    {
        _stuffService = stuffService;
    }

    /// <summary>
    /// Here you can create new shop.
    /// </summary>
    /// <param name="request">Parametres of new stuff</param>
    /// <response code="200">Returns the newly created stuff</response>
    /// <response code="500">Returns when there was unable to create stuff</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///               "fullName": "Behruz",
    ///               "role": 1,
    ///               "personalData": "2002.02.02",
    ///               "salary": 100000000
    ///         }
    /// </remarks>
    [HttpPost]
    [ProducesResponseType(typeof(GetCompanyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateStuffAsync(CreateStuffRequest request)
    {
        var response = await _stuffService.CreateStuffAsync(request);
        return response is null ?
            new StatusCodeResult(StatusCodes.Status500InternalServerError) :
            Ok(response);
    }

    /// <summary>
    /// Here you can get stuff with id.
    /// </summary>
    /// <param name="id"> Id of existing stuff</param>
    /// <response code="200">Returns shop by id</response>
    /// <response code="404">Returns null when stuff was not found</response>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStuffByIdAsync(uint id)
    {
        var response = await _stuffService.GetStuffByIdAsync((int)id);
        return response is null ? NotFound() : Ok(response);
    }

    /// <summary>
    /// Here you can get all stuff
    /// </summary>
    /// <response code="200">Returns all stuff</response>
    /// <response code="404">Returns null when stuff was not found</response>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAllStuffsAsync()
    {
        return Ok(await _stuffService.GetAllStuffAsync());
    }

    /// <summary>
    /// Here you can delete existinf stuff by its id
    /// </summary>
    /// <param name="id">Id of existing stuff</param>
    /// <response code="200">Deletes the stuff with Id and returns true</response>
    /// <response code="404">Returns false when stuff was not found</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStuffAsync(uint id)
    {
        var result = await _stuffService.DeleteStuffAsync((int)id);
        return result ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Here you can update stuff with id
    /// </summary>
    /// <param name="id">Id of existing stuff</param>
    /// <param name="request">Parametrs of stuff</param>
    /// <response code="200">Updated stuff by id </response>
    /// <response code="404">Returns null when stuff was not found</response>
    /// <remarks >    
    /// /// Sample request:
    ///
    ///         PUT
    ///         {
    ///              "fullName": "Behruz",
    ///              "role": 1,
    ///              "salary": 15000000,
    ///              "personalData": "2002.02.02"
    ///         }
    ///         /// </remarks>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStuffAsync(uint id, [FromBody] UpdateStuffRequest request)
    {
        var result = await _stuffService.UpdateStuffAsync((int)id, request);
        return result is null ? NotFound() : Ok(result);
    }
}
