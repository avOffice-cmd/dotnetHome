


using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class EmailCheckAttribute : ValidationAttribute
{
    private readonly string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string email = value.ToString();

            if (!Regex.IsMatch(email, emailPattern))
            {
                return new ValidationResult("Invalid email address format.");
            }
        }

        return ValidationResult.Success;
    }
}
