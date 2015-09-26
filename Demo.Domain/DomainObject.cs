using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    public abstract class DomainObject
    {
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
            Validator.TryValidateObject(this, context, results, true);

            return results;
        }
    }
}