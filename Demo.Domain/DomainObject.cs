using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            var results = Validate();
            return results.Any() == false;
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <remarks>
        /// This is the more comprehensive version of validation that returns a list of the error messages.
        /// </remarks>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate()
        {
            var context = new ValidationContext(this, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(this, context, results, true);

            return results;
        }
    }
}