using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace Demo.Domain.UnitTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void given_valid_person_when_trying_to_validate_should_return_true_and_empty_results()
        {
			var results = new List<ValidationResult>();
            var complexPerson = new PersonWithBuiltInValidation{FirstName = "Todd", LastName = "Meinershagen", EmailAddress = "todd@meinershagen.net"};
            complexPerson.TryValidate(results).Should().BeTrue();
			results.Should().BeEmpty();

            var simplePerson = new PersonWithCustomValidation { FirstName = "Todd", LastName = "Meinershagen", EmailAddress = "todd@meinershagen.net" };
            simplePerson.TryValidate(results).Should().BeTrue();
			results.Should().BeEmpty();
        }

	    [Test]
	    public void given_invalid_person_when_validating_should_throw()
	    {
		    var complexPerson = new PersonWithBuiltInValidation
		    {
			    FirstName =
				    "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT",
			    EmailAddress = "todd"
		    };

			Action action = complexPerson.Validate;
		    action
			    .ShouldThrow<AggregateException>()
				.WithMessage("FirstName must be at least 1 character and no more than 50 characters\r\nThe LastName field is required.\r\nEmailAddress must be a valid email address.\r\n")
			    .And
			    .InnerExceptions
			    .Should()
			    .Contain(ex => ex.Message == "FirstName must be at least 1 character and no more than 50 characters")
			    .And
				.Contain(ex => ex.Message == "The LastName field is required.")
				.And
				.Contain(ex => ex.Message == "EmailAddress must be a valid email address.");
	    }

        [Test]
        public void given_valid_person_when_comparing_difference_in_validation_execution_time_for_a_million_executions_should_be_less_than_1_second()
        {
            var range = Enumerable.Range(1, 1000000).ToList();

            Action testBuiltInMethod = () => 
                range.ForEach(x =>
                {
                    var person = new PersonWithBuiltInValidation
                    {
                        FirstName = "Todd",
                        LastName = "Meinershagen",
                        EmailAddress = "todd@meinershagen.net"
                    };
                    person.Validate();
                });

            var builtInWatch = new Stopwatch();
            builtInWatch.Start();
            testBuiltInMethod();
            builtInWatch.Stop();
            

            Action testCustomMethod = () =>
                range.ForEach(x =>
                {
                    var person = new PersonWithCustomValidation
                    {
                        FirstName = "Todd",
                        LastName = "Meinershagen",
                        EmailAddress = "todd@meinershagen.net"
                    };
                    person.TryValidate();
                });


            var customWatch = new Stopwatch();
            customWatch.Start();
            testCustomMethod();
            customWatch.Stop();

            customWatch.Elapsed.Subtract(builtInWatch.Elapsed).Should().BeLessThan(TimeSpan.FromSeconds(1));
        }
    }
}
