using CompanyManagment.Models;
using CompanyManagment.Models.Dtos.DepartmrntDtos;
using CompanyManagment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
			if (departments == null)
			{
				return NotFound("Not Found Department");
			}
			return Ok(departments);
		}
		
		[HttpGet("GetDepartmentById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var department = await _departmentService.GetByIdAsync(id);
			if (department == null)
			{
				return NotFound("Department Not Found");
			}
			return Ok(department);
		}

		[HttpPost("CreateDepartments")]
		public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartment dto)
		{
			if (ModelState.IsValid)
			{
				if (await _departmentService.GetExistByName(dto.Name))
				{
					return Conflict("Department with the same name already exists.");
				}
				var department = new Department
				{
					Name = dto.Name,
					Description = dto.Description
				};
				
				await _departmentService.AddAsync(department);
				return Ok("Department Created Successfully");
			}
            else
				return BadRequest(ModelState);

         }

		[HttpPut("UpdateDepartment/{id}")]
		public async Task<IActionResult> UpdateDepartment(int id , [FromBody] CreateDepartment dto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			
			var department = new Department
			{
				Name=dto.Name,
				Description=dto.Description
			};
			var existDepartment = await _departmentService.UpdateAsync(id, department);
			if (existDepartment == null)
				return NotFound("Department Not Found");
			else
			{
				if (existDepartment.Name.ToLower() != dto.Name.ToLower())
				{
					return Ok("Update Department Successfully");

				}
				return Conflict("Another department with the same name already exists.");
			}

		}

		[HttpDelete("DeleteDepartment/{id}")]
		public async Task<IActionResult> DeleteDepartment(int id)
		{
			var existDepartment = await _departmentService.DeleteByIdAsync(id);
			if (!existDepartment )
				return BadRequest("Department Not Exist");
			return Ok("Delete Department Successfully"); 
		}
	}
}
