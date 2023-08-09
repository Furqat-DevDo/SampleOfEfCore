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







    //// GET: api/<CategoryImageController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //// GET api/<CategoryImageController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}



    //// PUT api/<CategoryImageController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<CategoryImageController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
}       //}
    
