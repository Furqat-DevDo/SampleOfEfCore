using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategorysController"/> class.
        /// </summary>
        /// <param name="categoryService">The category service.</param>
        public CategorysController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>Returns a list of all categories.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAllCategoriesAsync());
        }


        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="request">The details of the category to create.</param>
        /// <returns>Returns the newly created category if successful, or a 500 Internal Server Error if not.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = await categoryService.CreateCategoryAsync(request);
            return response is null ?new StatusCodeResult(StatusCodes.Status404NotFound) : Ok(response);
            
        }

        /// <summary>
        /// Gets a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The category if found, or a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryByIdAsync(uint id)
        {

            ///Get the category by its unique identifier using the categoryService.
            var response = await categoryService.GetCategoryByIdAsync((int)id);
            /// If the response is null, return a 404 Not Found response.
            try
            {
                return Ok(await categoryService.GetCategoryByIdAsync((int)id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return response is null ? new StatusCodeResult(StatusCodes.Status404NotFound) : Ok(response);
        }


        /// <summary>
        /// If you think that a category is not needed, you can delete it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(uint id)
        {
            var result = await categoryService.DeletedCategoryAsync((int)id);
            return result ? Ok(result) : NotFound();
        }




        /// <summary>
        /// Update a category with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the category to update.</param>
        /// <param name="request">The update request containing new category information.</param>
        /// <returns>
        /// Returns an IActionResult representing the updated category or a NotFound result if the category with the specified ID was not found.
        /// </returns>
        /// <response code="200">Returns the updated category.</response>
        /// <response code="404">If the category with the specified ID was not found.</response>
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(uint id, UpdateCategoryRequest request)
        {
            var result = await categoryService.UpdateCategoryAsync((int)id, request);
            return result is null ? NotFound() : Ok(result);
        }

    }
}
