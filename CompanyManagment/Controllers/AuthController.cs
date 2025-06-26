using CompanyManagment.Models.Dtos.UserDtos;
using CompanyManagment.Repositiors.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
		[HttpPost("Login")]
		public async Task<IActionResult>Login(LoginDto loginDto)
		{
			if(!ModelState.IsValid) return BadRequest(ModelState);
			var res = await _authService.LoginAsync(loginDto);
			if(res==null) return BadRequest("Invalid Entire Data or Unotherized ");
			return Ok("Success Login and this Token:" + res);
		}
    }
}
