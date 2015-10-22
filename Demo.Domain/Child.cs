using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
	public class Child : Entity
	{
		[Required(ErrorMessage = "Child requires a first name.")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Child requires a last name.")]
		public string LastName { get; set; }
	}
}