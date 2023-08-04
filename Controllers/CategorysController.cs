using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController:ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategorysController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAllCategoriesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = await categoryService.CreateCategoryAsync(request);
            return response ==null ?new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok(response);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(uint id)
        {
            var response = await categoryService.GetCategoryByIdAsync((int)id);
            return response == null ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(uint id)
        {
            var result = await categoryService.DeletedCategoryAsync((int)id);
            return result ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(uint id, UpdateCategoryRequest request)
        {
            var result = await categoryService.UpdateCategoryAsync((int)id, request);
            return result == null ? NotFound() : Ok(result);
        }

    }
}
