using Model_Challenge.Models;
using System.ComponentModel.DataAnnotations;

namespace Model_Challenge.CustomValidators
{
    public class ProductListValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrMessage = "The order should be valid!";
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return null;
            }
            List<Product> products = (List<Product>)value;
            if(products.Count == 0)
            {
                return new ValidationResult(DefaultErrMessage, new string[] {nameof(validationContext.MemberName)});
            }
            return ValidationResult.Success;
        }
    }
}
