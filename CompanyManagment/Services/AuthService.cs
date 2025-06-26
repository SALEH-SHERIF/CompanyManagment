using CompanyManagment.Models;
using CompanyManagment.Models.Dtos.UserDtos;
using CompanyManagment.Repositiors;
using CompanyManagment.Repositiors.Interfaces;
using CompanyManagment.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CompanyManagment.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration ;
        public AuthService(IUserRepository userRepository , IConfiguration configuration )
        {
			_userRepository = userRepository; 
			_configuration = configuration;
        }
        public async Task<string?> LoginAsync(LoginDto dto)
		{
			var user = await _userRepository.GetByUserNameAsync(dto.UserName);
			if (user is null) return null;

			// Verify password
			using var hmac = new HMACSHA256(user.passwardSlat);
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
			if (!computedHash.SequenceEqual(user.PasswordHash)) return null;

			// Generate Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim("UserId", user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature
				)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	
	}
}
