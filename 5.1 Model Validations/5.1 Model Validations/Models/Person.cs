using _5._1_Model_Validations.CustomValidators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _5._1_Model_Validations.Models
{
    //public class Person : IValidatableObject
    public class Person
    {
        [Required(ErrorMessage = "{0} is required....!!")]   //To change predefined error message   the personname (property) is passed as an argument
        [Display(Name = "Person Name")] //{0} represents this name
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be minimum {2} and {1} char long!")]
        //[RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should be a valid name")]
        public string? PersonName { get; set; }
        [EmailAddress(ErrorMessage = "{0} should be a proper email")]
        [Required]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} is invalid!")]
        //[ValidateNever]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} should not be empty!")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} should not be empty!")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match!")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999, ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        //[MinimumYearValidator(2005)]
        [MinimumYearValidator(2005, ErrorMessage = "Should not be above {0}")]
        [BindNever]
        public DateTime DateOfBirth { get; set; }

        public DateTime FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older or equal to 'To date")]
        public DateTime ToDate { get; set; }

        public int? Age { get; set; }

        public List<string> Tags {  get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Person Name - {PersonName}\n Person Email - {Email}\n Person Phone - {Phone}\n Person Password - {Password}\n Person Price - {Price}\n";
        }

/*        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of date of birth or age must be provided", new[] { nameof(Age) });
            }
        }*/
    }
}
