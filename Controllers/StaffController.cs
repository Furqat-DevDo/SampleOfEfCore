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

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffController"/> class.
        /// </summary>
        /// <param name="staffService">The staff service.</param>
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;  
        }

        /// <summary>
        /// Here you can create new staff.
        /// </summary>
        /// <param name="request">Parametres of new staff</param>
        /// <remarks >
        /// Sample request:
        ///
        ///         POST
        ///         {
        ///             "name": "Coca Cola",
        ///             "categoryId": 1,
        ///             "companyId": 1,
        ///             "manufacturedDate": "2023-08-11T12:52:47.235Z",
        ///             "expireDate": "2023-10-11T12:52:47.235Z",
        ///             "price": 1000
        ///         }
        /// </remarks>
        /// <response code="200">Returns the newly created staff</response>
        /// <response code="500">Returns when there was unable to create new staff</response>
        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync(CreateStaffRequest request)
        {
            var response = await _staffService.CreateStaffAsync(request);
            return response is null ?
                new StatusCodeResult(StatusCodes.Status500InternalServerError) :
                Ok(response);
        }

        /// <summary>
        /// Here you can get staff by Id.
        /// </summary>
        /// <param name="id">Id of existing staff</param>
        /// <response code="200">Returns the staff which id = Id</response>
        /// <response code="404">Returns null when staff was not found</response>
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
        /// Here you can update the staff with Id.
        /// </summary>
        /// <param name="id">Id of existing staff</param>
        /// <param name="request">New parameters for updating staff</param>
        /// <response code="200">Returns updated staff with Id</response>
        /// <response code="404">Returns null when staff was not found</response>
        /// /// <remarks >
        /// Sample request:
        ///
        ///         PUT
        ///         {
        ///             "name": "Coca Cola",
        ///             "categoryId": 1,
        ///             "companyId": 1,
        ///             "manufacturedDate": "2023-08-11T12:52:47.235Z",
        ///             "expireDate": "2023-10-11T12:52:47.235Z",
        ///             "price": 1000
        ///         }
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaffAsync(uint id, [FromBody] UpdateStaffRequest request)
        {
            var result = await _staffService.UpdateStaffAsync((int)id, request);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
