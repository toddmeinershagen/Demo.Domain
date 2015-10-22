using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Demo.Domain
{
	public class Parent : Entity
	{
		public List<Child> Children { get; set; }

		public Address Address { get; set; }

		public ICar Car { get; set; }

		public override bool TryValidate(ICollection<ValidationResult> results = null)
		{
			base.TryValidate(results);
			Address.TryValidate(results);
			Car.TryValidate(results);

			foreach (var child in Children)
			{
				child.TryValidate(results);
			}

			return results == null 
				? false 
				: results.Any() == false;
		}
	}
}
