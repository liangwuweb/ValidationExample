using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ValidationExample.CustomValidators;

namespace ValidationExample.Models
{
    public class Person : IValidatableObject
    {   
        // 0 is represent the proporties name
        [Required(ErrorMessage ="{0} name cannot be empty!")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters" )]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contain only alphabets, space and dot")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage ="{0} is required")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should contain 10 digits")]
        //[ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="{0} can't be empty")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be empty")]
        [Compare("Password", ErrorMessage ="{0} and {1} do not match")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double? Price { get; set; }

        [MinimumYearValidator(2005)]
        [BindNever]
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal to 'To date'")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return $"Person object\n " +
                $"name: {PersonName}" +
                $"Email: {Email}" +
                $"Phone: {Phone}" +
                $"Password: {Password}" +
                $"ConfirmPassword: {ConfirmPassword}" +
                $"Price: {Price}" 
                ;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!DateOfBirth.HasValue && !Age.HasValue) {
                // yield keyword allows to retur more than one value
                yield return new ValidationResult("Either DOB or Age is empty", new[] { nameof(Age) });
            
            }
        }
    }
}
