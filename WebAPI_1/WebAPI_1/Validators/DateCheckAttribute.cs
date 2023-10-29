﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI_1.Validators
{
    public class DateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = (DateTime?)value;

            if (date < DateTime.Now) {

                return new ValidationResult("The date must be greater than or equals to todays date");
            };

            return ValidationResult.Success;
        }
    }
}
