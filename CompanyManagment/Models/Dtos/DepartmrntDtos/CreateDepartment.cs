using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.Models.Dtos.DepartmrntDtos
{
	public class CreateDepartment
	{
		[Required(ErrorMessage = "Name is Required")]
		[MaxLength(20, ErrorMessage = ("Name Must less or equal than 20 char"))]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description Required")]
		[MaxLength(100, ErrorMessage = "Description must less or equal from 100 char")]
		public string Description { get; set; }
	}
}
