using CompanyManagment.Models;
using CompanyManagment.Repositiors.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Repositiors
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetByUserNameAsync(string userName)
		{
		  return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
		}

		public async Task<bool> GetExistUserNameAsync(string userName)
		{
			return await _context.Users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower());
		}
	}
}
