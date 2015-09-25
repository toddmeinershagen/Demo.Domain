using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    [CustomValidation(typeof(Employee), "CustomCheck")]
    public class Employee
    {
        [Required(ErrorMessage = "First Name is a required property.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static ValidationResult CustomCheck(Employee employee, ValidationContext context)
        {
            var fullName = String.Format("{0} {1}", employee.FirstName, employee.LastName);
            return fullName.Length > 50 
                ? new ValidationResult("The full name must not be longer than 100 characters.") 
                : ValidationResult.Success;
        }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <remarks>
        /// This is a simple validation method that just returns a true/false without any error details.
        /// </remarks>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        public bool IsValid()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, context, results);

            return results.Count == 0;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <remarks>
        /// This is the more comprehensive version of validation that returns a list of the error messages.
        /// </remarks>
        /// <returns></returns>
        public List<ValidationResult> Validate()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, context, results);

            return results;
        }
    }
}
