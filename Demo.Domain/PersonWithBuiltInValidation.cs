using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    public class PersonWithBuiltInValidation : DomainObject, IPerson
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be at least {2} character and no more than {1} characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be at least {2} character and no more than {1} characters")]
        
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "{0} must be a valid email address.")]
        
        public string EmailAddress { get; set; }
    }
}
