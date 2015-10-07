using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FluentAssertions;

using NUnit.Framework;

namespace Demo.Domain.UnitTests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void given_employee_without_firstname_when_checking_isvalid_should_be_false()
        {
            var employee = new Employee();
            employee.IsValid()
                .Should()
                .BeFalse();
        }

        [Test]
        public void given_employee_with_firstname_when_checking_isvalid_should_be_true()
        {
            var employee = new Employee { FirstName = "Todd" };
            employee.IsValid()
                .Should()
                .BeTrue();
        }

        [Test]
        public void given_employee_with_long_firstname_and_lastname_when_validating_should_return_error_about_full_name_being_too_long()
        {
            var employee = new Employee
            {
                FirstName = "ToddMeinershagenToddMeinershagenToddMeinershagen",
                LastName = "ToddMeinershagenToddMeinershagenToddMeinershagen"
            };

	        var results = new List<ValidationResult>();
            employee.TryValidate(results)
                .Should().BeFalse();

			results.Should()
                .Contain(x => x.ErrorMessage == "The full name must not be longer than 100 characters.");
        }
    }
}
