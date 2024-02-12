using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Rosneft.WebApplication.Validation
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        private const string Pattern = @"^[^\p{N}]+$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string input = value.ToString();
                if (!Regex.IsMatch(input, Pattern))
                {
                    return new ValidationResult("Недопустимые символы для ввода: арабские цифры");
                }
            }

            return ValidationResult.Success;
        }
    }
}
