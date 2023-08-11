using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers;

[Route("api/categorys/{id}/[controller]")]
[ApiController]
public class CategoryImagesController : ControllerBase
{


    private readonly ICategoryImageService _categoryImageService;
    private readonly ICategoryService _categoryService;
    public CategoryImagesController(ICategoryImageService categoryImageService, ICategoryService productService)
    {
        _categoryImageService = categoryImageService;
        _categoryService = productService;
    }
    /// <summary>
    /// Here you can create new image.
    /// </summary>
    /// <response code="201">Returns the newly created image</response>
    /// <response code="400">Returns when there was unable to create image</response>
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

    /// <summary>
    /// Here you can get the image.
    /// </summary>
    /// <response code="200">Returns the newly created image</response>
    /// <response code="404">Returns when there was unable to get image</response>
    [HttpGet("direct")]
    public async Task<IActionResult> GetFileFromPath(int id, string filePath)
    {

        var image = await _categoryService.GetCategoryByIdAsync(id);
        if (image is null) return NotFound("Image Not Found !!!");

        var searchFileResult = await _categoryImageService.ReadFileFromPathAsync(filePath);
        if (searchFileResult.bytes.Length == 0)
        {
            return NotFound("File not found !!!");
        }

        return File(searchFileResult.Item1, searchFileResult.fileInfo[0]);
    }

    /// <summary>
    /// Here you can get file of the image.
    /// </summary>
    /// <response code="200">Returns the newly file of created image</response>
    /// <response code="404">Returns when there was unable to get image</response>
    [HttpGet("download")]
    public async Task<IActionResult> GetFileFromPathDownload(int id, string filePath)
    {
        var image = await _categoryService.GetCategoryByIdAsync(id);
        if (image is null) return NotFound("image Not Found !!!");

        var searchFileResult = await _categoryImageService.ReadFileFromPathAsync(filePath);
        if (searchFileResult.bytes.Count() == 0)
        {
            return NotFound("File not found !!!");
        }

        return File(searchFileResult.Item1, "application/octet-stream", searchFileResult.fileInfo[1]);
    }

    /// <summary>
    /// Here you can get the image by id.
    /// </summary>
    /// <response code="200">Returns the newly created image</response>
    /// <response code="404">Returns when there was unable to get image</response>  
    [HttpGet]
    public async Task<IActionResult> GeCategoriesImages(int id)
    {
        var image = await _categoryService.GetCategoryByIdAsync(id);
        if (image is null) return NotFound("Image Not Found");

        var imageFiles = await _categoryImageService.GetCategoryFilesAsync(id);
        return Ok(imageFiles);
    }

    /// <summary>
    /// Here you can delete existing image by its Id.
    /// </summary>d
    /// <response code="200">Deletes the image with Id and returns true</response>
    /// <response code="404">Returns false when image was not found</response>
    [HttpDelete("{fileId}")]
    public async Task<IActionResult> DeleteCategoryImage(int id, Guid fileId)
    {
        var image = await _categoryService.GetCategoryByIdAsync(id);

        if (image is null)
            return NotFound("Image not found");

        var result = await _categoryImageService.DeleteCategoryImage(fileId);

        return result ? Ok(result) : NotFound(result);
    }

}       
    
