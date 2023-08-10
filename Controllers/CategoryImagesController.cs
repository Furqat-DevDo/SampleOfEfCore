﻿using EfCore.Models.Requests;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
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

    [HttpGet]
    public async Task<IActionResult> GeCategoriesImages(int id)
    {
        var image = await _categoryService.GetCategoryByIdAsync(id);
        if (image is null) return NotFound("Image Not Found");

        var imageFiles = await _categoryImageService.GetCategoryFilesAsync(id);
        return Ok(imageFiles);
    }

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
    
