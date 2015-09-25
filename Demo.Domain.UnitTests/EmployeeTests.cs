using NUnit.Framework;

namespace Demo.Domain.UnitTests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void TestFailure()
        {
            var employee = new Employee();
            Assert.That(employee.IsValid(), Is.False);
        }

        [Test]
        public void TestSuccess()
        {
            var employee = new Employee{FirstName = "Todd"};
            Assert.That(employee.IsValid(), Is.True);
        }

        [Test]
        public void TestCustomCheck()
        {
            var employee = new Employee
            {
                FirstName = "ToddMeinershagenToddMeinershagenToddMeinershagen",
                LastName = "ToddMeinershagenToddMeinershagenToddMeinershagen"
            };

            Assert.That(employee.IsValid(), Is.False);
            Assert.That(employee.Validate()[0].ErrorMessage, Is.EqualTo("The full name must not be longer than 100 characters."));
        }
    }
}
