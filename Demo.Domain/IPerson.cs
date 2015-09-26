using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    public interface IPerson
    {
        
        string FirstName { get; set; }

        string LastName { get; set; }

        string EmailAddress { get; set; }

        bool IsValid();

        IEnumerable<ValidationResult> Validate();
    }
}