using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        /// <summary>
        /// Here you can create new category.
        /// </summary>
        /// <param name="request">Parametres of new category</param>
        /// <remarks >
        /// Sample request:
        ///
        ///         POST
        ///         {
        ///             "name": "electronika Category",
        ///             "upperId": 1,
        ///             "CreateDate": "2023-10-11T12:52:47.235Z",
        ///         }
        /// </remarks>
        /// <response code="200">Returns the newly created category</response>
        /// <response code="500">Returns when there was unable to create new category</response>
        [HttpPost]
        [ProducesResponseType(typeof(GetCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = await _categoryService.CreateCategoryAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Here you can get category by Id.
        /// </summary>
        /// <param name="id">Id of existing category</param>
        /// <response code="200">Returns the category which id = Id</response>
        /// <response code="404">Returns null when category was not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByIdAsync(uint id)
        {
            var response = await _categoryService.GetCategoryByIdAsync((int)id);
            return Ok(response);
        }

        /// <summary>
        /// Here you can get all categories.
        /// </summary>
        /// <response code="200">Returns all categories</response>
        /// <response code="404">Returns null when categories was not found</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<GetCategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<GetCategoryResponse>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        /// <summary>
        /// Here you can delete existing category by its Id.
        /// </summary>
        /// <param name="id">Id of existing category</param>
        /// <response code="200">Deletes the category which id = Id and returns true</response>
        /// <response code="404">Returns false when category was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProductAsync(uint id)
        {
            var result = await _categoryService.DeletedCategoryAsync((int)id);
            return Ok(result);
        }

        /// <summary>
        /// Here you can update the category with Id.
        /// </summary>
        /// <param name="id">Id of existing category</param>
        /// <param name="request">New parameters for updating category</param>
        /// <response code="200">Returns updated category with Id</response>
        /// <response code="404">Returns null when category was not found</response>
        /// /// <remarks >
        /// Sample request:
        ///
        ///         PUT
        ///         {
        ///             "name": "Telefon",
        ///             "UpperId": 1,
        ///             "UpdateDate": "2023-10-11T12:52:47.235Z",
        ///         }
        /// </remarks>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GetCategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategoryAsync(uint id, [FromBody] UpdateCategoryRequest request)
        {
            var result = await _categoryService.UpdateCategoryAsync((int)id, request);
            return Ok(result);
        }

    }
}
