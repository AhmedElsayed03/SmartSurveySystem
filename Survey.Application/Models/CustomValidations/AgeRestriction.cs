using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.CustomValidations
{
    internal class AgeRestriction : ValidationAttribute
    {
        public override bool IsValid(object? value)
         => value is DateTime date && (DateTime.Now - date).Days >= 6570;
    
    }
}
