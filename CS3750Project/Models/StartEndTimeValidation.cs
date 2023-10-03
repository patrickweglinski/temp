namespace CS3750Project.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class StartTimeBeforeEndTimeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var startTimeProperty = validationContext.ObjectType.GetProperty("StartTime");
        var endTimeProperty = validationContext.ObjectType.GetProperty("EndTime");

        if (startTimeProperty != null && endTimeProperty != null)
        {
            var startTimeValue = (TimeSpan)startTimeProperty.GetValue(validationContext.ObjectInstance, null);
            var endTimeValue = (TimeSpan)value;

            if (startTimeValue >= endTimeValue)
            {
                return new ValidationResult("Start time must be before end time.");
            }
        }

        return ValidationResult.Success;
    }
}

