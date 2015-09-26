using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    /// <summary>
    /// A validator that checks if a property is before today.
    /// </summary>
    /// <remarks>
    /// This was based on a sample found online in an article by Scott K. Allen at 
    /// http://odetocode.com/blogs/scott/archive/2011/02/21/custom-data-annotation-validator-part-i-server-code.aspx
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class AfterTodayAttribute : ValidationAttribute
    {
        public AfterTodayAttribute()
            : base("{0} must be after today")
        { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var firstComparable = value as IComparable;
            var secondComparable = DateTime.Now as IComparable;

            return firstComparable.CompareTo(secondComparable) < 0 
                ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) 
                : ValidationResult.Success;
        }
    }
}
