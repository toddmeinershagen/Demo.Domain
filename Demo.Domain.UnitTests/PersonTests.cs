using System;
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
        public void given_valid_person_when_validating_should_return_empty_results()
        {
            var complexPerson = new PersonWithBuiltInValidation{FirstName = "Todd", LastName = "Meinershagen", EmailAddress = "todd@meinershagen.net"};
            complexPerson.Validate().Should().BeEmpty();

            var simplePerson = new PersonWithCustomValidation { FirstName = "Todd", LastName = "Meinershagen", EmailAddress = "todd@meinershagen.net" };
            simplePerson.Validate().Should().BeEmpty();
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
                    person.Validate();
                });


            var customWatch = new Stopwatch();
            customWatch.Start();
            testCustomMethod();
            customWatch.Stop();

            customWatch.Elapsed.Subtract(builtInWatch.Elapsed).Should().BeLessThan(TimeSpan.FromSeconds(1));
        }
    }
}
