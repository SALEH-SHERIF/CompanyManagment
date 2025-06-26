using CompanyManagment.Models;
using CompanyManagment.Repositiors.Interfaces;
using CompanyManagment.Services.Interfaces;

namespace CompanyManagment.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _repo;
		public DepartmentService(IDepartmentRepository repo)
		{
		  _repo = repo;
		}
		public Task<Department> AddAsync(Department department)=>_repo.AddAsync(department);
		public Task<bool> DeleteByIdAsync(int id)=>_repo.DeleteAsync(id);
		public Task<IEnumerable<Department>> GetAllAsync()=> _repo.GetAllAsync();
		public Task<Department?> GetByIdAsync(int id)=>_repo.GetByIdAsync(id);
		public Task<Department?> UpdateAsync(int id, Department department)=>_repo.UpdateAsync(id, department);
		public Task<bool> GetExistByName(string name) => _repo.GetExistByName(name);


	}
}
