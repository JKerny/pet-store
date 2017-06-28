using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Custom_Validation
{
    public class ValidateDateRange : ValidationAttribute
    {
        
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                // your validation logic
                if (Convert.ToDateTime(value) >= DateTime.MinValue && Convert.ToDateTime(value) <= DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Date is not in given range.");
                }
            }
        }
    }
