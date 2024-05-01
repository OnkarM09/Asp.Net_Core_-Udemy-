using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _5._1_Model_Validations.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropName { get; set; }
        public DateRangeValidatorAttribute(string otherPropName)
        {
            OtherPropName = otherPropName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime toDate = Convert.ToDateTime(value);
                PropertyInfo? otherProp = validationContext.ObjectType.GetProperty(OtherPropName);

                if (otherProp != null)
                {
                    DateTime fromDate = Convert.ToDateTime(otherProp.GetValue(validationContext.ObjectInstance));

                    if (fromDate > toDate)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropName, validationContext.MemberName });
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}
