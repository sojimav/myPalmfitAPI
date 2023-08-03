using Palmfit.Data.EntityEnums;

namespace Palmfit.Api.Repository
{
	public class RegisterDTO
	{
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Image { get; set; }
		public string Address { get; set; }
		public string Area { get; set; }
		public string State { get; set; }
		public Gender Gender { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Country { get; set; }
	}
}
