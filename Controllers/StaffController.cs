using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;  
        }

        [HttpPost]
        public async Task<IActionResult> CreateStuffAsync(CreateStaffRequest request)
        {
            var response = await _staffService.CreateStaffAsync(request);
            return response is null ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) :
                Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStuffByIdAsync(uint id)
        {
            var response = await _staffService.GetStaffByIdAsync((int)id);
            return response is null ? NotFound() : Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStuffsAsync()
        {
            return Ok(await _staffService.GetAllStaffAsync());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuffAsync(uint id)
        {
            var result = await _staffService.DeleteStaffAsync((int)id);
            return result ? Ok(result) : NotFound();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStuffAsync(uint id, [FromBody] UpdateStaffRequest request)
        {
            var result = await _staffService.UpdateStaffAsync((int)id, request);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
