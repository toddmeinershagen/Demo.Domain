using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;

using Demo.Domain.Properties;

using FluentAssertions;

using NUnit.Framework;

namespace Demo.Domain.UnitTests
{
	[TestFixture]
	public class GuarantorWithGlobalResourcesTests
	{
		[Test]
		public void given_guarantor_with_no_first_name_when_validating_should_return_result_with_resource_value()
		{
			var guarantor = new GuarantorWithGlobalResources { LastName = "Meinershagen" };

			var results = new List<ValidationResult>();
			guarantor.TryValidate(results);

			results.Should().Contain(r => r.ErrorMessage == Resources.GuarantorFirstNameRequired);
			results.Should().NotContain(r => r.ErrorMessage == Resources.ResourceManager.GetString("GuarantorLastNameRequired"));
		}
	}
}
