using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryImageController:ControllerBase
    {
        private readonly ICategoryImageService _categorimageservice;

        public CategoryImageController(ICategoryImageService CategoryImageService)
        {
            _categorimageservice = CategoryImageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryImageAsync([FromBody]CreateCategoryImageRequest request)
        {
            var response = await _categorimageservice.CreateCategoryImageAsync(request);
            return response is null ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : 
            Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryImagesAsync()
        {
            return Ok(await _categorimageservice.GetAllCategoryImagesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryImageByIdAsync(uint id)
        {
            var response = await _categorimageservice.GetCategoryImageByIdAsync((int)id);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryImageAsync(uint id)
        {
            var result = await _categorimageservice.DeleteAsync((int)id);
            return result ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryImageAsync(uint id, [FromBody] UpdateCategoryImageRequest request)
        {
            var result = await _categorimageservice.UpdateCategoryImageAsync((int)id, request);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
