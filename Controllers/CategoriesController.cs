using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoriesController"/> class.
        /// </summary>
        /// <param name="categoryService">The category service.</param>
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="request">The category creation request.</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/categories
        ///     {
        ///         "categoryName": "Electronics",
        ///         "upperId": 1
        ///     }
        /// 
        /// </remarks>
        /// <returns>A newly created category.</returns>
        /// <response code="200">Returns the newly created category.</response>
        /// <response code="404">If the category creation was unsuccessful.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = await _categoryService.CreateCategoryAsync(request);
            return response is null ? new StatusCodeResult(StatusCodes.Status404NotFound) : Ok(response);

        }

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>Returns a list of all categories.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCategoryResponse>))]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }



        /// <summary>
        /// Gets a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>The category if found, or a 404 Not Found response.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoryByIdAsync(uint id)
        {

            ///Get the category by its unique identifier using the categoryService.
            var response = await _categoryService.GetCategoryByIdAsync((int)id);
            /// If the response is null, return a 404 Not Found response.
            try
            {
                return Ok(await _categoryService.GetCategoryByIdAsync((int)id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return response is null ? new StatusCodeResult(StatusCodes.Status404NotFound) : Ok(response);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategoryAsync(uint id, UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateCategoryAsync((int)id, request);
            return result is null ? NotFound() : Ok(result);
        }


        /// <summary>
        /// Updates an existing category with new data.
        /// </summary>
        /// <param name="request">The updated category data.</param>
        /// <returns>Returns the updated category if successful, or a 404 Not Found response.</returns>
        /// <response code="200">Returns the updated category.</response>
        /// <response code="400">If the request data is invalid.</response>
        /// <response code="404">If the category to update is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategoryAsync(uint id)
        {
            var result = await _categoryService.DeletedCategoryAsync((int)id);
            return result ? Ok(result) : NotFound();
        }


    }
}
