using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo.Domain
{
    public class PersonWithCustomValidation : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public bool IsValid()
        {
	        return TryValidate();
        }

        public bool TryValidate(ICollection<ValidationResult> results = null)
        {
	        results = results ?? new List<ValidationResult>();

            if (FirstName == null)
            {
                results.Add(new ValidationResult("FirstName is a required field"));
            }
            else if (FirstName.Length == 0 || FirstName.Length > 50)
            {
                results.Add(new ValidationResult("FirstName must be at least 1 character and no more than 50 characters"));
            }

            if (LastName == null)
            {
                results.Add(new ValidationResult("LastName is a required field"));
            }
            else if (LastName.Length == 0 || LastName.Length > 50)
            {
                results.Add(new ValidationResult("LastName must be at least 1 character and no more than 50 characters"));
            }

            const string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            if (EmailAddress == null)
            {
                results.Add(new ValidationResult("EmailAddress is a required field"));
            }
            else if (!Regex.IsMatch(EmailAddress, pattern))
            {
                results.Add(new ValidationResult("EmailAddress must be a valid email address"));
            }

	        return results.Any() == false;
        }
    }
}