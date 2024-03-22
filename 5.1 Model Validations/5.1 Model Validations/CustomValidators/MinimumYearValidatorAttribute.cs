using System.ComponentModel.DataAnnotations;

namespace _5._1_Model_Validations.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefualtErrMsg { get; set; } = "Year should not be less than {0}";

        //Paremeterless constructor
        public MinimumYearValidatorAttribute() { 
        }

        public MinimumYearValidatorAttribute(int minYear)
        {
            MinimumYear = minYear;
        }

        protected override ValidationResult?IsValid(object? value, ValidationContext validationContext)
        {
           if(value != null)
            {
                DateTime date = (DateTime)value;
                if(date.Year >= MinimumYear)
                {
                    //return new ValidationResult("Minimum year allowed is 2000!");
                    return new ValidationResult(string.Format(ErrorMessage ?? DefualtErrMsg, MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
