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
    /// <summary>
    /// Initializes a new instance of the <see cref="StuffController"/> class.
    /// </summary>
    /// <param name="stuffService">The product service.</param>
    public StuffController(IStuffService stuffService)
    {
        _stuffService = stuffService;
    }

    /// <summary>
    /// Here you can create new stuff.
    /// </summary>
    /// <param name="request">Parametres of new stuff</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "fullName": "Ali",
    ///             "role": 1,
    ///             "personalData": "2023 03 17",
    ///             "salary": 100000000
    ///         }
    /// </remarks>
    /// <response code="200">Returns the newly created stuff</response>
    /// <response code="500">Returns when there was unable to create new stuff</response>
    [HttpPost]
    public async Task<IActionResult> CreateStuffAsync(CreateStuffRequest request)
    {
        var response = await _stuffService.CreateStuffAsync(request);
        return Ok(response);
    }

    /// <summary>
    /// Here you can get stuff by Id.
    /// </summary>
    /// <param name="id">Id of existing stuff</param>
    /// <response code="200">Returns the stuff which id = Id</response>
    /// <response code="404">Returns null when stuff was not found</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStuffByIdAsync(uint id)
    {
        var response = await _stuffService.GetStuffByIdAsync((int)id);
        return Ok(response);
    }


    /// <summary>
    /// Here you can get all stuff.
    /// </summary>
    /// <response code="200">Returns all existing stuff or empty list if not</response>
    [HttpGet]
    public async Task<IActionResult> GetAllStuffsAsync()
    {
        return Ok(await _stuffService.GetAllStuffAsync());
    }


    /// <summary>
    /// Here you can delete existing stuff by its Id.
    /// </summary>
    /// <param name="id">Id of existing stuff</param>
    /// <response code="200">Deletes the stuff which id = Id and returns true</response>
    /// <response code="404">Returns false when stuff was not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteStuffAsync(uint id)
    {
        var result = await _stuffService.DeleteStuffAsync((int)id);
        return Ok(result);
    }


    /// <summary>
    /// Here you can update the stuff with Id.
    /// </summary>
    /// <param name="id">Id of existing stuff</param>
    /// <param name="request">New parameters for updating stuff</param>
    /// <response code="200">Returns updated stuff with Id</response>
    /// <response code="404">Returns null when stuff was not found</response>
    /// /// <remarks >
    /// Sample request:
    ///
    ///         PUT
    ///         {
    ///              "fullName": "Ali",
    ///              "role": 1,
    ///              "salary": 15000000,
    ///              "personalData": "2023 03 17"
    ///         }
    /// </remarks>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateStuffAsync(uint id, [FromBody] UpdateStuffRequest request)
    {
        var result = await _stuffService.UpdateStuffAsync((int)id, request);
        return Ok(result);
    }
}
