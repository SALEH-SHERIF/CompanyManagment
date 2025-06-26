using CompanyManagment.Models;
using CompanyManagment.Repositiors.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Repositiors
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddAsync(Employee employee)
		{
			   _context.Employees.Add(employee);
			     await _context.SaveChangesAsync();
			     return employee;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existEmployee = await _context.Employees.FindAsync(id);
			if (existEmployee != null)
			{
				 _context.Employees.Remove(existEmployee);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;		
		}

		public async Task<IEnumerable<Employee>> GetAllAsync()
		{
			return await _context.Employees.Include(e=>e.Department).ToListAsync();
		}

		public async Task<Employee?> GetByIdAsync(int id)
		{
			var existEmplyess = await _context.Employees.FindAsync(id); 
			if(existEmplyess != null)
			{
				return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e=>e.Id == id);
			}
			return null;
		}

		public async Task<bool> GetExistEmailAsync(string email)
		{
			return await _context.Employees.AnyAsync(e=>e.Email.ToLower() == email.ToLower());
		}

		public async Task<Employee?> UpdateAsync(int id, Employee employee)
		{
			var existEmplyee = await _context.Employees.FindAsync(id); 
			if (existEmplyee != null)
			{
				existEmplyee.Email= employee.Email;
				existEmplyee.FullName= employee.FullName;
				existEmplyee.Phone= employee.Phone;
				existEmplyee.DateOfJoin= employee.DateOfJoin;
				existEmplyee.DepartmentId= employee.DepartmentId;
				await _context.SaveChangesAsync();
				return existEmplyee;
			}
			return null;
		}
	}
}
