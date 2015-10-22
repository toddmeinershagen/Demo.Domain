using System.ComponentModel.DataAnnotations;

using Demo.Domain.Properties;

namespace Demo.Domain
{
	public class GuarantorWithGlobalResources : Entity
	{
		[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "GuarantorFirstNameRequired")]
		public string FirstName { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "GuarantorLastNameRequired")]
		public string LastName { get; set; }
	}
}
