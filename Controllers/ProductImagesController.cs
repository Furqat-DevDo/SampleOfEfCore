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
        private readonly IProductService _productService;

        public ProductImagesController(IProductImageService productImageService,
            IProductService productService)
        {
            _productImageService = productImageService;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(int id, [FromForm] CreateProductImageRequest request)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound("Product Not Found !!!");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productImageService.CreateAsync(id, request);
            return Ok(result);

        }

        [HttpGet("direct")]
        public async Task<IActionResult> GetFileFromPath(int id, string filePath)
        {

            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound("Product Not Found !!!");

            var searchFileResult = await _productImageService.ReadFileFromPathAsync(filePath);
            if (searchFileResult.bytes.Length == 0)
            {
                return NotFound("File not found !!!");
            }

            return File(searchFileResult.Item1, searchFileResult.fileInfo[0]);
        }

        [HttpGet("download")]
        public async Task<IActionResult> GetFileFromPathDownload(int id, string filePath)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound("Product Not Found !!!");

            var searchFileResult = await _productImageService.ReadFileFromPathAsync(filePath);
            if (searchFileResult.bytes.Count() == 0)
            {
                return NotFound("File not found !!!");
            }

            return File(searchFileResult.Item1, "application/octet-stream", searchFileResult.fileInfo[1]);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsImages(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound("Product Not Found");

            var productFiles = await _productImageService.GetProductFilesAsync(id);
            return Ok(productFiles);
        }

        [HttpDelete("{fileId}")]
        public async Task<IActionResult> DeleteProductImage(int id, Guid fileId)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product is null)
                return NotFound("Product not found");

            var result = await _productImageService.DeleteProductImage(fileId);

            return result ? Ok(result) : NotFound(result);
        }
    }
}
