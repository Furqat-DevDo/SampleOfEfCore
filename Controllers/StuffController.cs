using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StuffController : ControllerBase
    {
        private readonly IStuffService _stuffService;
        public StuffController(IStuffService stuffService)
        {
            _stuffService = stuffService;  
        }

        [HttpPost]
        public async Task<IActionResult> CreateStuffAsync(CreateStuffRequest request)
        {
            var response = await _stuffService.CreateStuffAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStuffByIdAsync(uint id)
        {
            var response = await _stuffService.GetStuffByIdAsync((int)id);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStuffsAsync()
        {
            return Ok(await _stuffService.GetAllStuffAsync());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuffAsync(uint id)
        {
            var result = await _stuffService.DeleteStuffAsync((int)id);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStuffAsync(uint id, [FromBody] UpdateStuffRequest request)
        {
            var result = await _stuffService.UpdateStuffAsync((int)id, request);
            return Ok(result);
        }
    }
}
