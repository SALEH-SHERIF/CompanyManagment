﻿using CompanyManagment.Models;

namespace CompanyManagment.Repositiors.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetAllAsync();
		Task<Employee?> GetByIdAsync(int id);
		Task<Employee> AddAsync(Employee employee);
		Task<Employee?> UpdateAsync(int id , Employee employee);
		Task<bool> DeleteAsync(int id);
		Task<bool> GetExistEmailAsync(string email);
	}
}
