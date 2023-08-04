using EfCore.Models.Requests;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EfCore.Controllers
{
    [Route("api/products/{id}/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {

        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync (int id,[FromForm] CreateProductImageRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productImageService.CreateAsync(id,request);
            return Ok(result);
        }

    }
}
