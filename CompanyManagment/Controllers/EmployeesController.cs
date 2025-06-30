using CompanyManagment.Models;
using CompanyManagment.Models.Dtos.EmployeeDtos;
using CompanyManagment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService _service;

		public EmployeesController(IEmployeeService service)
		{
			_service = service;
		}

		[HttpGet("GetAllEmployees")]
		public async Task<IActionResult> GetAllEmployees()
		{
			var employees = await _service.GetAllAsync();
			return Ok(new ApiResponse<IEnumerable<EmployeeDetailsDto>>(true, "Employees fetched successfully", employees));
		}

		[HttpGet("GetEmployeeById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var existingEmp = await _service.GetByIdAsync(id);
			if (existingEmp != null)
				return Ok(new ApiResponse<EmployeeDetailsDto>(true, "Employee found", existingEmp));

			return NotFound(new ApiResponse<string>(false, "Employee not found"));
		}

		[HttpPost("CreateEmployee")]
		public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ApiResponse<string>(false, "Invalid request data"));

			if (await _service.GetByEmailAsync(dto.Email))
				return Conflict(new ApiResponse<string>(false, "Email already used"));

			var employee = await _service.AddAsync(dto);
			if (employee != null)
			{
				return CreatedAtAction(nameof(GetById), new { id = employee.Id },
					new ApiResponse<EmployeeDetailsDto>(true, "Employee created successfully"));
			}
			
			return BadRequest(new ApiResponse<string>(false, "Something went wrong or department does not exist"));
		}

		[HttpPut("UpdateEmployee/{id}")]
		public async Task<IActionResult> UpdateEmployee(int id, [FromBody] CreateEmployeeDto dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ApiResponse<string>(false, "Invalid request data"));

			var existEmp = await _service.GetByIdAsync(id);
			if (existEmp != null)
			{
				if (existEmp.Email.ToLower() == dto.Email.ToLower())
					return Conflict(new ApiResponse<string>(false, "Email already exists"));

				var updateEmp = await _service.UpdateAsync(id, dto);
				if (updateEmp != null)
					return Ok(new ApiResponse<EmployeeDetailsDto>(true, "Employee updated successfully"));

				return NotFound(new ApiResponse<string>(false, "Failed to update employee"));
			}

			return NotFound(new ApiResponse<string>(false, "Employee not found"));
		}

		[HttpDelete("DeleteEmployee/{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var existEmp = await _service.GetByIdAsync(id);
			if (existEmp != null)
			{
				var deleteEmp = await _service.DeleteByIdAsync(id);
				if (deleteEmp)
					return Ok(new ApiResponse<string>(true, "Employee deleted successfully"));
			}

			return NotFound(new ApiResponse<string>(false, "Employee not found"));
		}
	}
}
