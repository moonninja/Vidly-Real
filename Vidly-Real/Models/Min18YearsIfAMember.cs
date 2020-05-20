using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace Vidly_Real.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknow || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success; 
            }
            if ( customer.BirthDate == null)
                return new ValidationResult("Birthday is required.");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}