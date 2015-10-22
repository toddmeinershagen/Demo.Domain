using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Demo.Domain
{
    public abstract class Entity
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
	        var results = new List<ValidationResult>();

	        if (TryValidate(results)) return;

	        throw new EntityValidationException(results);
        }

	    public bool TryValidate(ICollection<ValidationResult> results = null)
	    {
		    results = results ?? new Collection<ValidationResult>();
			var context = new ValidationContext(this);
			return Validator.TryValidateObject(this, context, results, true);
	    }

    }

	public class EntityValidationException : AggregateException
	{
		public EntityValidationException(IEnumerable<ValidationResult> results)
			: base(GetMessage(results), GetExceptions(results))
		{
		}

		private static string GetMessage(IEnumerable<ValidationResult> results)
		{
			var messageBuilder = new StringBuilder();
			results.ToList().ForEach(r => messageBuilder.AppendFormat("{0}\r\n", r.ErrorMessage));

			return messageBuilder.ToString();
		}

		private static IEnumerable<Exception> GetExceptions(IEnumerable<ValidationResult> results)
		{
			var exceptions = new List<ValidationException>();
			results.ToList().ForEach(r => exceptions.Add(new ValidationException(r.ErrorMessage)));

			return exceptions;
		}
	}
}