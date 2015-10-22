using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
	public class Address : Entity
	{
		[Required(ErrorMessage = "Address requires a city.")]
		public string City { get; set; }
	}
}