using System.ComponentModel.DataAnnotations;

namespace Model_Challenge.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrMessage { get; set; }
        public DateTime DefaultDate {  get; set; }

        public MinimumDateValidatorAttribute(string minimumDate)
        {
            DefaultDate = Convert.ToDateTime(minimumDate);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return null;
            }

            //Get the order date
            DateTime orderDate = (DateTime)value;
            if(orderDate > DefaultDate)
            {
                DefaultErrMessage = $"The order date should not be greater than the {DefaultDate.ToString("yyyy-MM-dd")}";
                return new ValidationResult(ErrorMessage ?? DefaultErrMessage);
            }

          return ValidationResult.Success;
        }
    }
}
