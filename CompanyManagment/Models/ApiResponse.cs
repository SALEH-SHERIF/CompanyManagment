using System.Text.Json.Serialization;

namespace CompanyManagment.Models
{
	public class ApiResponse<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; } = "Request completed successfully.";

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public T? Data { get; set; }
		public ApiResponse() { }
		public ApiResponse(bool success, string message, T? data = default)
		{
			Success = success;
			Message = message;
			Data = data;
		}
	}
}
