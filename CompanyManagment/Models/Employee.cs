using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagment.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage ="Required FullName")]
		[MaxLength(20,ErrorMessage ="FullName Must Less or equal than 20 char")]
		[RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "FullName must contain only English letters and spaces")]
		public string FullName { get; set; }
		[Required(ErrorMessage ="Email Required")]
		[MaxLength(50, ErrorMessage = "Email Must Contain less or equal 50 char ")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }
		
		[Required(ErrorMessage = "Phone number is required")]
		[RegularExpression(@"^(01)[0125][0-9]{8}$", ErrorMessage = "Invalid Egyptian phone number")]
		public string Phone { get; set; }
		[Required(ErrorMessage ="DataOfJoin Required")]
		public DateTime DateOfJoin { get; set; }

		// one employee has one department only 
		[Required]
		public int DepartmentId { get; set; }
		[ForeignKey(nameof(DepartmentId))]
		public Department? Department { get; set; }

	}
}
