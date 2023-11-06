using System.ComponentModel.DataAnnotations;

namespace DI_MiddleWare_Configuration2.validators
{
    public class CheckNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();

                // You can add your custom name validation logic here.
                // For example, you can check for a minimum length or any other criteria you need.

                if (name.Length < 3) // Example: Require a minimum length of 3 characters.
                {
                    return new ValidationResult("Name must be at least 3 characters long.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

