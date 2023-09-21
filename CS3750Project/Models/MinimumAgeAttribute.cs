using System;
using System.ComponentModel.DataAnnotations;

namespace CS3750Project.Models
{
    public class MinimumAgeAttribute:ValidationAttribute
    {
        int minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            this.minimumAge = minimumAge;
        }

        
        public override bool IsValid(object value)
        {
            
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(minimumAge) < DateTime.Now;
            }
            
            return false;
        }
        
    }
}
