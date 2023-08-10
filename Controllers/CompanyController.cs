using EfCore.Models.Requests;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    /// <summary>
    /// Here you can create new company.
    /// </summary>
    /// <param name="request">Parametres of new company</param>
    /// <response code="200">Returns the newly created company</response>
    /// <response code="500">Returns when there was unable to create company</response>
    [HttpPost]
    public async Task<IActionResult> CreateCompanyAsync(CreateCompanyRequest request)
    {
        var response = await _companyService.CreateCompanyAsync(request);
        return response is null ?
            new StatusCodeResult(StatusCodes.Status500InternalServerError) :
            Ok(response);
    }

    /// <summary>
    /// Here you can get company by Id.
    /// </summary>
    /// <param name="id">Id of existing company</param>
    /// <response code="200">Returns the company with Id</response>
    /// <response code="404">Returns null when company was not found</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompanyByIdAsync(uint id)
    {
        var response = await _companyService.GetCompanyByIdAsync((int)id);
        return response is null ? NotFound(response) : Ok(response);
    }

    /// <summary>
    /// Here you can get all companys.
    /// </summary>
    /// <response code="200">Returns all companys</response>
    /// <response code="404">Returns null when companys was not found</response>
    [HttpGet]
    public async Task<IActionResult> GetAllCompanysAsync()
    {
        return Ok(await _companyService.GetAllCompanysAsync());
    }

    /// <summary>
    /// Here you can delete existing company by its Id.
    /// </summary>
    /// <param name="id">Id of existing company</param>
    /// <response code="200">Deletes the company with Id and returns true</response>
    /// <response code="404">Returns false when company was not found</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompanyAsync(uint id)
    {
        var result = await _companyService.DeleteAsync((int)id);
        return result ? Ok(result) : NotFound(result);
    }

    /// <summary>
    /// Here you can update the company with Id.
    /// </summary>
    /// <param name="id">Id of existing company</param>
    /// <param name="request"></param>
    /// <response code="200">Returns updated company with Id</response>
    /// <response code="404">Returns null when company was not found</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompanyAsync(uint id, [FromBody] UpdateCompanyRequest request)
    {
        var result = await _companyService.UpdateCompanyAsync((int)id, request);
        return result is null ? NotFound(result) : Ok(result);
    }
}