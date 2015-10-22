using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FluentAssertions;

using NUnit.Framework;

namespace Demo.Domain.UnitTests
{
	[TestFixture]
	public class ParentTests
	{
		[Test]
		public void given_invalid_children_when_validating_parent_should_return_validation_results()
		{
			var parent = new Parent
			{
				Address = new Address{},
				Car = new Car(),
				Children = new List<Child> {new Child {FirstName = "Todd"}, new Child {LastName = "Meinershagen"}}
			};

			var results = new List<ValidationResult>();
			parent.TryValidate(results);

			results.Should()
				.Contain(r => r.ErrorMessage == "Child requires a first name.")
				.And
				.Contain(r => r.ErrorMessage == "Child requires a last name.")
				.And
				.Contain(r => r.ErrorMessage == "Address requires a city.")
				.And
				.Contain(r => r.ErrorMessage == "Car requires a make.")
				.And
				.Contain(r => r.ErrorMessage == "Car requires a model.");
		}
	}
}
