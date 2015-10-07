using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    public interface IPerson
    {
        
        string FirstName { get; set; }

        string LastName { get; set; }

        string EmailAddress { get; set; }

        bool IsValid();

        bool TryValidate(ICollection<ValidationResult> results = null);
    }
}