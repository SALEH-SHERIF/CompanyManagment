using CompanyManagment.Models;

namespace CompanyManagment.Repositiors.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync(); // Retrive All Department
        Task<Department?> GetByIdAsync(int id);     // Retrive specific department
        Task<Department> AddAsync(Department department); // Add Department 
        Task<Department?> UpdateAsync(int id, Department department);  // update department 
        Task<bool> DeleteAsync(int id);                     // Delete Department 
        Task<bool>GetExistByName(string name);
    }
}
