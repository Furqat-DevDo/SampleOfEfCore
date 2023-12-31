﻿using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyController"/> class.
    /// </summary>
    /// <param name="companyService">The compnany service.</param>
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    /// <summary>
    /// Here you can create new company.
    /// </summary>
    /// <param name="request">Parametres of new company</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "Name":"Coca-Cola Co.",
    ///             "ClosedDate" : null,
    ///             "UpperId" : null
    ///         }
    /// </remarks>
    /// <response code="200">Returns the newly created company</response>
    /// <response code="500">Returns when there was unable to create new company</response>
    [HttpPost]
    [ProducesResponseType(typeof(GetCompanyResponse),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCompanyAsync(CreateCompanyRequest request)
    {
        var response = await _companyService.CreateCompanyAsync(request);
        return Ok(response);
    }

    /// <summary>
    /// Here you can get company by Id.
    /// </summary>
    /// <param name="id">Id of existing company</param>
    /// <response code="200">Returns the company with Id</response>
    /// <response code="404">Returns null when company was not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCompanyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompanyByIdAsync(uint id)
    {
        var response = await _companyService.GetCompanyByIdAsync((int)id);
        return Ok(response);
    }

    /// <summary>
    /// Here you can get all companys.
    /// </summary>
    /// <response code="200">Returns all existing companies or empty list if not</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetCompanyResponse>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCompanyAsync(uint id)
    {
        var result = await _companyService.DeleteAsync((int)id);
        return Ok(result);
    }

    /// <summary>
    /// Here you can update the company with Id.
    /// </summary>
    /// <param name="id">Id of existing company</param>
    /// <param name="request">New parameters of updating company</param>
    /// <response code="200">Returns updated company with Id</response>
    /// <response code="404">Returns null when company was not found</response>
    /// <remarks >
    /// Sample request:
    ///
    ///         PUT
    ///         {
    ///             "Name":"Coca-Cola Co.",
    ///             "ClosedDate" : null,
    ///             "UpperId" : null
    ///         }
    /// </remarks>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(GetCompanyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCompanyAsync(uint id, [FromBody] UpdateCompanyRequest request)
    {
        var result = await _companyService.UpdateCompanyAsync((int)id, request);
        return Ok(result);
    }
}