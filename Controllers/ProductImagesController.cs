using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EfCore.Controllers;

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

        /// <summary>
        /// Here you can add new image for existing product.
        /// </summary>
        /// <param name="request">Field for adding new image</param>
        /// <param name="id">Id of existing product</param>
        /// <response code="200">Returns parameters of newly created image</response>
        /// <response code="400">Returns ModelState parametres when provided data is not valid</response>
        /// <response code="404">Returns NULL when there was unable to find product which id = Id</response>
        /// <response code="500">Returns when there was unable to add new image</response>
        [HttpPost]
        [ProducesResponseType(typeof(GetProductImageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync(int id, [FromForm] CreateProductImageRequest request)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound(null);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productImageService.CreateAsync(id, request);
            return result is null ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : Ok(result);
        }

        /// <summary>
        /// Here you can get image of product from path in the server where product id = Id .
        /// </summary>
        /// <param name="id"> Id of existing product</param>
        /// <param name="filePath"> Path of image</param>
        /// <response code="200">Returns image which id = Id</response>
        /// <response code="404">Returns null when image was not found</response>
        [HttpGet("direct")]
        [ProducesResponseType(typeof(GetProductImageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFileFromPath(int id, string filePath)
        {

            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound(null);

            var searchFileResult = await _productImageService.ReadFileFromPathAsync(filePath);
            if (searchFileResult.bytes.Length == 0)
            {
                return NotFound(null);
            }

        return File(searchFileResult.Item1, searchFileResult.fileInfo[0]);
    }

        /// <summary>
        /// Here you can download product image which id = Id
        /// </summary>
        /// <param name="id">Id of existing product</param>
        /// <param name="filePath">Path of image</param>
        /// <response code="200">Returns all companys</response>
        /// <response code="404">Returns null when companys was not found</response>
        [HttpGet("download")]
        [ProducesResponseType(typeof(GetProductImageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFileFromPathDownload(int id, string filePath)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound(null);

            var searchFileResult = await _productImageService.ReadFileFromPathAsync(filePath);
            if (searchFileResult.bytes.Count() == 0)
            {
                return NotFound(null);
            }

        return File(searchFileResult.Item1, "application/octet-stream", searchFileResult.fileInfo[1]);
    }

        /// <summary>
        /// Here you can get all images of product which id = Id.
        /// </summary>
        /// <param name="id">Id of existing product</param>
        /// <response code="200">Returns all images of product</response>
        /// <response code="404">Returns null when no image was found</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetProductImageResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsImages(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return NotFound(null);

        var productFiles = await _productImageService.GetProductFilesAsync(id);
        return Ok(productFiles);
    }

        /// <summary>
        /// Here you can delete existing product image by product Id and image FileId.
        /// </summary>
        /// <param name="id">Id of existing product</param>
        /// <param name="fileId">Id of existing product image</param>
        /// <response code="200">Deletes the image and returns true</response>
        /// <response code="404">Returns false when image was not found</response>
        [HttpDelete("{fileId}")]
        [ProducesResponseType(typeof(GetProductImageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProductImage(int id, Guid fileId)
        {
            var product = await _productService.GetProductByIdAsync(id);

        if (product is null)
            return NotFound("Product not found");

        var result = await _productImageService.DeleteProductImage(fileId);

        return result ? Ok(result) : NotFound(result);
    }
}
