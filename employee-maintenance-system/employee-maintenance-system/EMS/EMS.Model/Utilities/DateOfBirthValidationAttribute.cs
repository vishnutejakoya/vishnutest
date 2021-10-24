using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Model.Utilities
{
    public class DateOfBirthValidationAttribute : ValidationAttribute
    {

        public DateOfBirthValidationAttribute(int minimumAge)
        {
            MinimumAge = minimumAge;
            
            ErrorMessage = "{0} must be someone at least {1} years of age";
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if ((value != null && DateTime.TryParse(value.ToString(), out date)))
            {
                return date.AddYears(MinimumAge) < DateTime.Now;
            }

            if (value == null)
                return true;

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MinimumAge);
        }

        public int MinimumAge { get; }
    }
}
