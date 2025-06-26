using CompanyManagment.Models;
using CompanyManagment.Models.Dtos.EmployeeDtos;

namespace CompanyManagment.Services.Interfaces
{
	public interface IEmployeeService
	{
		Task<IEnumerable<EmployeeDetailsDto>>GetAllAsync();
		Task<EmployeeDetailsDto?> GetByIdAsync(int id);
		Task<bool> GetByEmailAsync(string email);
		Task<bool> DeleteByIdAsync(int id);
		Task<Employee?> UpdateAsync(int id, CreateEmployeeDto employee);
		Task<Employee> AddAsync(CreateEmployeeDto createEmployeeDto);
	}
}
