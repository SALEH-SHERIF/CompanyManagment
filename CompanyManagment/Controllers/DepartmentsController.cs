using CompanyManagment.Models;
using CompanyManagment.Models.Dtos.DepartmrntDtos;
using CompanyManagment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class DepartmentsController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;
		public DepartmentsController(IDepartmentService department)
		{
			_departmentService = department;
		}

		[HttpGet("GetAllDepartments")]
		public async Task<IActionResult> GetAll()
		{
			var departments = await _departmentService.GetAllAsync();
			return Ok(new ApiResponse<IEnumerable<Department>>(true, "Departments fetched successfully", departments));
		}

		[HttpGet("GetDepartmentById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var department = await _departmentService.GetByIdAsync(id);
			if (department == null)
				return NotFound(new ApiResponse<string>(false, "Department not found"));
			return Ok(new ApiResponse<Department>(true, "Department fetched successfully", department));
		}

		[HttpPost("CreateDepartments")]
		public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartment dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ApiResponse<string>(false, "Invalid request data"));

			if (await _departmentService.GetExistByName(dto.Name))
				return Conflict(new ApiResponse<string>(false, "Department with the same name already exists"));

			var department = new Department
			{
				Name = dto.Name,
				Description = dto.Description
			};

			await _departmentService.AddAsync(department);
			return CreatedAtAction(
		         nameof(GetById),                          
		         new { id = department.Id },              
		         new ApiResponse<Department>(true, "Department created successfully", department)
	);
		}

		[HttpPut("UpdateDepartment/{id}")]
		public async Task<IActionResult> UpdateDepartment(int id, [FromBody] CreateDepartment dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(new ApiResponse<string>(false, "Invalid request data"));

			var isNameTaken = await _departmentService.GetExistByName(dto.Name);
			if (isNameTaken)
				return Conflict(new ApiResponse<string>(false, "Another department with the same name already exists"));

			var department = new Department
			{
				Name = dto.Name,
				Description = dto.Description
			};

			var updated = await _departmentService.UpdateAsync(id, department);
			if (updated == null)
				return NotFound(new ApiResponse<string>(false, "Department not found"));

			return Ok(new ApiResponse<Department>(true, "Department updated successfully", updated));
		}

		[HttpDelete("DeleteDepartment/{id}")]
		public async Task<IActionResult> DeleteDepartment(int id)
		{
			var deleted = await _departmentService.DeleteByIdAsync(id);
			if (!deleted)
				return NotFound(new ApiResponse<string>(false, "Department not found"));

			return Ok(new ApiResponse<string>(true, "Department deleted successfully"));
		}
	}
}
