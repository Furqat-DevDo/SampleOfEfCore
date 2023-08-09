using EfCore.Models.Requests;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/products/{id}/[controller]")]
[ApiController]
public class CategoryImagesController : ControllerBase
{


    private readonly ICategoryImageService _categoryImageService;

    public CategoryImagesController(ICategoryImageService categoryImageService)
    {
        _categoryImageService = categoryImageService;
    }
    /// <summary>
    /// posted image
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns code="201"></returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(int id, [FromForm] CreateCategoryImageRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _categoryImageService.CreateAsync(id, request);
        var routValue = new { id = result.CategoryId };
        return CreatedAtRoute(routValue, result);
    }
    
}       
    
