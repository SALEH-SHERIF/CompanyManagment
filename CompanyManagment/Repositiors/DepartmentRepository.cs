using CompanyManagment.Models;
using CompanyManagment.Repositiors.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Repositiors
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<Department> AddAsync(Department department)
		{
			_context.Departments.Add(department);
			 await _context.SaveChangesAsync();
			return department;
		}

		public  async Task<bool> DeleteAsync(int id)
		{
			var existDepartment = await _context.Departments.FindAsync(id);
			if (existDepartment != null)
			{
				_context.Departments.Remove(existDepartment);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<Department>> GetAllAsync()
		{
			return await _context.Departments.ToListAsync();
		}

		public async Task<Department?> GetByIdAsync(int id)
		{
			return await _context.Departments.FindAsync(id);
		}

		public async Task<Department?> UpdateAsync(int id, Department department)
		{
			var existing = await _context.Departments.FindAsync(id); 
			if (existing == null) 
				return null;
		   existing.Description = department.Description;
		   existing.Name = department.Name;
			await _context.SaveChangesAsync();
			return department;

		}
		public async Task<bool> GetExistByName(string name)
		{
			return await _context.Departments.AnyAsync(d=>d.Name.ToLower() == name.ToLower() );
		}
	}
}
