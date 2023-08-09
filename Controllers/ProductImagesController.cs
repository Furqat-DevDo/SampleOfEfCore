using EfCore.Models.Requests;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;


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

        [HttpGet]
        public IActionResult GetFileFromPath (string filePath) 
        { 
            var file = _productImageService.ReadFileFromPathAsync(filePath);
            if(file is null)
            {
                return NotFound();
            }

            string contentType = GetContentType(Path.GetExtension(filePath));

            return File(file,contentType);
        }

        private string GetContentType(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".pdf":
                    return "application/pdf";
                
                default:
                    return "application/octet-stream";
            }
        }

        [HttpGet("download")]
        public IActionResult GetFileFromPathDownload(string filePath)
        {
            var file = _productImageService.ReadFileFromPathAsync(filePath);
            if (file is null)
            {
                return NotFound();
            }

            return File(file,"application/octet-stream",$"{Path.GetFileName(filePath)}");
        }
    }
}
