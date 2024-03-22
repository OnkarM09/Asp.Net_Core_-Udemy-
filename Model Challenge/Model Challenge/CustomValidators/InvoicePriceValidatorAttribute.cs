using System.ComponentModel.DataAnnotations;

namespace Model_Challenge.CustomValidators
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrMessage = "Invalid invoice price";

        public InvoicePriceValidatorAttribute() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return null;
            }

            return base.IsValid(value, validationContext);
        }
    }
}
