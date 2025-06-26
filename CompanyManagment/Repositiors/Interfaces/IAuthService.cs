using CompanyManagment.Models.Dtos.UserDtos;

namespace CompanyManagment.Repositiors.Interfaces
{
	public interface IAuthService
	{
		Task<string?> LoginAsync(LoginDto dto);
	}
}
