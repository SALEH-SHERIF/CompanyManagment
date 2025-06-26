using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.Models.Dtos.UserDtos
{
	public class LoginDto
	{
		[Required(ErrorMessage = "UsreName is Required")]
		[MaxLength(20, ErrorMessage = ("UserNmae Must less or equal 20 char"))]
		[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "FullName must contain only English letters and spaces")]
		public string UserName { get; set; }

		[Required]
		[StringLength(15, MinimumLength = 8)]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,15}$",
	ErrorMessage = "Password must be 8-15 characters and include at least 1 uppercase, 1 lowercase, 1 digit, and 1 special character.")]
		public string Password { get; set; } = string.Empty;
	}
}
