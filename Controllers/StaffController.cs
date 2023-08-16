using EfCore.Models.Requests;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Controllers
{
    /// <summary>
    /// API for Staff Management.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffController"/> class.
        /// </summary>
        /// <param name="staffService">The staff service.</param>
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;  
        }

        /// <summary>
        /// Create a new staff member.
        /// </summary>
        /// <param name="request">Parameters of the new staff member.</param>
        /// <returns>The newly created staff member's details.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync(CreateStaffRequest request)
        {
            var response = await _staffService.CreateStaffAsync(request);
            return response is null ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) :
                Ok(response);
        }
        /// <summary>
        /// Get staff member by ID.
        /// </summary>
        /// <param name="id">ID of an existing staff member.</param>
        /// <returns>The details of the staff member with the given ID.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffByIdAsync(uint id)
        {
            var response = await _staffService.GetStaffByIdAsync((int)id);
            return response is null ? NotFound() : Ok(response);
        }
        /// <summary>
        /// Here you can get all staffs.
        /// </summary>
        /// <response code="200">Returns all existing staffs or empty list if not</response>
        [HttpGet]
        public async Task<IActionResult> GetAllStaffsAsync()
        {
            return Ok(await _staffService.GetAllStaffAsync());
        }

        /// <summary>
        /// Here you can delete existing staff by its Id.
        /// </summary>
        /// <param name="id">Id of existing staff</param>
        /// <response code="200">Deletes the staff which id = Id and returns true</response>
        /// <response code="404">Returns false when staff was not found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAsync(uint id)
        {
            var result = await _staffService.DeleteStaffAsync((int)id);
            return result ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Update staff member details by ID.
        /// </summary>
        /// <param name="id">ID of an existing staff member.</param>
        /// <param name="request">New parameters for updating staff member.</param>
        /// <returns>The updated details of the staff member with the given ID.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffAsync(uint id, [FromBody] UpdateStaffRequest request)
        {
            var result = await _staffService.UpdateStaffAsync((int)id, request);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
