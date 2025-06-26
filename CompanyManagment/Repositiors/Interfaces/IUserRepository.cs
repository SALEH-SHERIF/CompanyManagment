using CompanyManagment.Models;

namespace CompanyManagment.Repositiors.Interfaces
{
	public interface IUserRepository
	{
		Task<User?>GetByUserNameAsync(string userName);
		Task<bool> GetExistUserNameAsync(string userName); 
	}
}
