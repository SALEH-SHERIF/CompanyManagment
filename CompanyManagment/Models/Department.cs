using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage ="Name is Required")]
		[MaxLength(20, ErrorMessage =("Name Must less or equal than 20 char"))]
		public string Name { get; set; }
		[Required(ErrorMessage ="Description Required")]
		[MaxLength(50, ErrorMessage ="Description must less or equal from 50 char")]
		public string Description { get; set; }

		// Relation many employee to one department
		// ?  => if create first deparrment no employee
		public ICollection<Employee>? Employees { get; set; }
	}
}
