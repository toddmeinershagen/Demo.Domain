using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    [CustomValidation(typeof(Employee), "CustomValidation")]
    public class Employee : DomainObject
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [Required(ErrorMessage = "First Name is a required property.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }


        /// <summary>
        /// Custom object-level validation
        /// </summary>
        /// <remarks>
        /// I don't know if I like that this is a public static, so I prefer to use custom validators.  
        /// But, this is much easier to cover any cases that can't be handled out of the box.
        /// </remarks>
        /// <param name="employee">The employee.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ValidationResult CustomValidation(Employee employee, ValidationContext context)
        {
            var fullName = String.Format("{0} {1}", employee.FirstName, employee.LastName);
            return fullName.Length > 50 
                ? new ValidationResult("The full name must not be longer than 100 characters.") 
                : ValidationResult.Success;
        }
    }
}
