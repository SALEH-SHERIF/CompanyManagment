using CompanyManagment.Models;

namespace CompanyManagment.Services.Interfaces
{
	public interface IDepartmentService
	{
	   Task<IEnumerable<Department>> GetAllAsync();
	   Task<Department?> GetByIdAsync(int id);
		Task<Department> AddAsync(Department department); 
		Task<Department?> UpdateAsync(int id , Department department);
		Task<bool> DeleteByIdAsync(int id);
		Task<bool> GetExistByName(string name);
	}
}
