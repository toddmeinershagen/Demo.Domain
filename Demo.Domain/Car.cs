using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
	public class Car : Entity, ICar
	{
		[Required(ErrorMessage = "Car requires a make.")]
		public string Make { get; set; }
		[Required(ErrorMessage = "Car requires a model.")]
		public string Model { get; set; }
	}
}