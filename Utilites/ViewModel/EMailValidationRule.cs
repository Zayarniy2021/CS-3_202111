using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Utilites.ViewModel
{
    class EMailValidationRule: ValidationRule
    {

        Regex regex = new Regex(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6}");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            string email = value.ToString();
            if (!regex.IsMatch(email)) return new ValidationResult(false, "Не соответствует email");
            else return new ValidationResult(true, null);            

        }
    }
}
