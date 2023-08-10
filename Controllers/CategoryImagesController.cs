using EfCore.Models.Requests;
using EfCore.Services;
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

    [HttpGet]
    public IActionResult GetFileFromPath(string filePath)
    {
        var file = _categoryImageService.ReadFileFromPathAsync(filePath);
        if (file is null)
        {
            return NotFound();
        }

        string contentType = GetContentType(Path.GetExtension(filePath));

        return File(file, contentType);
    }

    private string GetContentType(string fileExtension)
    {
        switch (fileExtension.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            case ".pdf":
                return "application/pdf";

            default:
                return "application/octet-stream";
        }
    }

    [HttpGet("download")]
    public IActionResult GetFileFromPathDownload(string filePath)
    {
        var file = _categoryImageService.ReadFileFromPathAsync(filePath);
        if (file is null)
        {
            return NotFound();
        }

        return File(file, "application/octet-stream", $"{Path.GetFileName(filePath)}");
    }

}       
    
