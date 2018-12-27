using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class FollowUpDateIfFollowUpRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var diagnosis = (Diagnosis)validationContext.ObjectInstance;

            if (!diagnosis.IsFollowUpRequired && diagnosis.DateOfFollowUp == null)//followUp not required and fullowup date not given.
                return ValidationResult.Success;

            if (!diagnosis.IsFollowUpRequired && diagnosis.DateOfFollowUp != null)//followUp not required but fullowup date was given.
                return new ValidationResult("Don't Need Any FollowUp Date."); 
            
            if (diagnosis.IsFollowUpRequired && diagnosis.DateOfFollowUp == null)//followUp required but date not given
                return new ValidationResult("Enter the Date of the FollowUp Diagnosis");

            //followUp required and followup date also given. Validation Success only when the followup date is in future.
            return (diagnosis.DateOfFollowUp > DateTime.Today)
                ? ValidationResult.Success
                : new ValidationResult("FollowUp date must be a Date in Future.");
        }
    }
}