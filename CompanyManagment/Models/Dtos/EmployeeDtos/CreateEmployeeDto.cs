using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.Models.Dtos.EmployeeDtos
{
	public class CreateEmployeeDto
	{
		public string FullName { get; set; }
		[Required(ErrorMessage = "Email Required")]
		[MaxLength(50, ErrorMessage = "Email Must Contain less or equal 50 char ")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Phone number is required")]
		[RegularExpression(@"^(01)[0125][0-9]{8}$", ErrorMessage = "Invalid Egyptian phone number")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "DataOfJoin Required")]
		public DateTime DateOfJoin { get; set; }

		// one employee has one department only 
		[Required]
		public int DepartmentId { get; set; }
	}
}
