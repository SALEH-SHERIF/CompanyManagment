namespace CompanyManagment.Models.Dtos.EmployeeDtos
{
	public class EmployeeDetailsDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string phone {  get; set; }
		public string Email { get; set; }
		public  DateTime JoinOfDate { get; set; }
		public int DepaermentId { get; set; }
		public string DepartmentName { get; set; } = string.Empty;
	}
}
