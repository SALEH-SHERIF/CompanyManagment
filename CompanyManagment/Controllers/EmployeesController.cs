using CompanyManagment.Models.Dtos.EmployeeDtos;
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
			return Ok(await _service.GetAllAsync());
		}
		[HttpGet("GetEmployeeById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var existingEmp = await _service.GetByIdAsync(id);
			if (existingEmp != null) return Ok(existingEmp);
			return NotFound("Not Exist Employee");
		}
		[HttpPost("CreateEmployee")]
		public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
		{
			if(!ModelState.IsValid) return BadRequest(ModelState);
			if(await _service.GetByEmailAsync(dto.Email))  return Conflict("Email already used");
			var employee = await _service.AddAsync(dto);
			if (employee != null)
			{
				return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
			}
			return BadRequest("Something Error");
		}
		[HttpPut("UpdateEmployee/{id}")]
		public async Task<IActionResult>UpdateEmployee(int id , [FromBody] CreateEmployeeDto dto)
		{
			if (!ModelState.IsValid) 
				return BadRequest(ModelState);
          var existEmp = await _service.GetByIdAsync(id);
			if (existEmp != null)
			{
				if(existEmp.Email.ToLower() == dto.Email.ToLower())
					return Conflict("Email already Exist");
				var updateEmp = await _service.UpdateAsync(id, dto);
				if (updateEmp != null)
					return Ok(updateEmp);
				else return NotFound("Not Updated"); 
			}
			return BadRequest("Employee Not Found ");
		}
		[HttpDelete("DeleteEmployee/{id}")]
		public async Task<IActionResult>DeleteEmployee(int id)
		{
			var existEmp= await _service.GetByIdAsync(id);
			if (existEmp != null)
			{
				var deleteEmp = await _service.DeleteByIdAsync(id);
				if(deleteEmp)
				return Ok("Delete Employee Successfully");
			
			}
			return BadRequest("Employee Not Found");
		}
    }
}
