using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DI_MiddleWare_Configuration2.validators
{
    public class phoneNumberCheckAttribute : ValidationAttribute
    {
        private readonly string phonePattern = @"^\d{10}$"; // You can customize this regular expression based on your phone number format

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();

                if (!Regex.IsMatch(phoneNumber, phonePattern))
                {
                    return new ValidationResult("Invalid phone number format");
                }
            }

            return ValidationResult.Success;
        }
    }
}

