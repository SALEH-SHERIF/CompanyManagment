using CompanyManagment.Models;
using CompanyManagment.Models.Dtos.EmployeeDtos;
using CompanyManagment.Repositiors.Interfaces;
using CompanyManagment.Services.Interfaces;

namespace CompanyManagment.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
			_repo = repo;            
        }

		public async Task<Employee> AddAsync(CreateEmployeeDto createEmployeeDto)
		{
			var Employee = new Employee
			{
				Email = createEmployeeDto.Email,
				Phone = createEmployeeDto.Phone,
				FullName = createEmployeeDto.FullName,
				DateOfJoin = createEmployeeDto.DateOfJoin,
				DepartmentId = createEmployeeDto.DepartmentId,
			};
			return await _repo.AddAsync(Employee);
		}
	    public async Task<bool> DeleteByIdAsync(int id)=>await _repo.DeleteAsync(id);
		public async Task<IEnumerable<EmployeeDetailsDto>> GetAllAsync()
		{
			var employess = await _repo.GetAllAsync();
			return employess.Select(e => new EmployeeDetailsDto
			{
				Id = e.Id,
				Email = e.Email,
				phone = e.Phone,
				FullName = e.FullName,
				DepaermentId = e.DepartmentId,
				JoinOfDate = e.DateOfJoin,
				DepartmentName = e.Department?.Name ?? ""

			}); 
		}
		public async Task<bool> GetByEmailAsync(string email)=>	await _repo.GetExistEmailAsync(email);
		public async Task<EmployeeDetailsDto?> GetByIdAsync(int id)
		{
			var existEmployee =await _repo.GetByIdAsync(id);
			if (existEmployee == null)
				return null;
			
			return new EmployeeDetailsDto
			{
				Email = existEmployee.Email,
				phone=existEmployee.Phone,
				FullName = existEmployee.FullName,
				Id = existEmployee.Id,
				DepaermentId=existEmployee.DepartmentId,
				DepartmentName=existEmployee.Department?.Name ??"" ,
				JoinOfDate=existEmployee.DateOfJoin
			};
		}
    	public async Task<Employee?> UpdateAsync(int id, CreateEmployeeDto employee)
		{
			var existname =await _repo.GetByIdAsync(id);
			if (existname == null)
				return null;
			var Existemployee = new Employee
			{
				Email=employee.Email,
				Phone=employee.Phone,
				FullName=employee.FullName,
				DateOfJoin=employee.DateOfJoin,
				DepartmentId=employee.DepartmentId
			};
			 return  await _repo.UpdateAsync(id , Existemployee);
         }		
			
	}
}
