using EfCore.Models.Requests;
using EfCore.Models.Responses;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EfCore.Controllers;

[Route("api/products/{id}/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{

    private readonly IProductImageService _productImageService;
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductImagesController"/> class.
    /// </summary>
    /// <param name="productImageService">The productImage service.</param>
    /// <param name="productService">The product service.</param>
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
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync(int id, [FromForm] CreateProductImageRequest request)
    {
        var product = await _productService.GetProductByIdAsync(id);

        var result = await _productImageService.CreateAsync(id, request);
        return Ok(result);
    }

    /// <summary>
    /// Here you can get image of product from path in the server where product id = Id .
    /// </summary>
    /// <param name="id"> Id of existing product</param>
    /// <param name="filePath"> Path of image</param>
    /// <response code="200">Returns image which id = Id</response>
    /// <response code="404">Returns null when image was not found</response>
    [HttpGet("direct")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFileFromPathDownload(int id, string filePath)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product is null) return NotFound(null);

        var searchFileResult = await _productImageService.ReadFileFromPathAsync(filePath);
        if (!searchFileResult.bytes.Any())
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
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(bool), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProductImage(int id, Guid fileId)
    {
        var product = await _productService.GetProductByIdAsync(id);

        var result = await _productImageService.DeleteProductImage(fileId);

        return Ok(result);
    }
}
