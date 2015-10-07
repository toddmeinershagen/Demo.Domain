using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FluentAssertions;

using NUnit.Framework;

namespace Demo.Domain.UnitTests
{
    [TestFixture]
    public class TripTests
    {
        [Test]
        public void given_trip_with_date_not_after_today_when_checking_is_valid_should_be_false()
        {
	        var results = new List<ValidationResult>();
            var trip = new Trip { Date = 23.November(1972) };
            trip.TryValidate(results).Should().BeFalse();
	        results.Should().NotBeEmpty();
        }

        [Test]
        public void given_trip_with_date_after_today_when_checking_is_valid_should_be_true()
        {
            var trip = new Trip { Date = DateTime.Now.AddDays(1) };
            trip.IsValid().Should().BeTrue();
        }
    }
}
