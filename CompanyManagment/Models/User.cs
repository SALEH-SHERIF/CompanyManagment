using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.Models
{
	public class User
	{
		[Key]
	  	public int Id { get; set; }
		[Required(ErrorMessage ="UsreName is Required")]
		[MaxLength(20,ErrorMessage=("UserNmae Must less or equal 20 char"))]
		[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "FullName must contain only English letters and spaces")]
		public string UserName { get; set; }	
		public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
		public byte[] passwardSlat { get; set; } = Array.Empty<byte>();

	}
}
