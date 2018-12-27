using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class CardNumberIfIsCardPayment: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bill = (Bill)validationContext.ObjectInstance;

            if(bill.IsCardPayment && bill.CardNumber==null)//card payment but card number was not given.
                return new ValidationResult("Please give the card number.");

            if(!bill.IsCardPayment && bill.CardNumber != null)//not card payment but card number was given.
                return new ValidationResult("Don't need card number!");

            //else (for other 2 condition validation will success).
            return ValidationResult.Success; 
        }
    }
}