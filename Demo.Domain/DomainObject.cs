using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            return TryValidate();
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <remarks>
        /// This is the more comprehensive version of validation that returns a list of the error messages.
        /// </remarks>
        /// <returns></returns>
        public void Validate()
        {
			var context = new ValidationContext(this);
			Validator.ValidateObject(this, context, true);
        }

	    public bool TryValidate(ICollection<ValidationResult> results = null)
	    {
		    results = results ?? new Collection<ValidationResult>();
			var context = new ValidationContext(this);
			return Validator.TryValidateObject(this, context, results, true);
	    }

    }
}