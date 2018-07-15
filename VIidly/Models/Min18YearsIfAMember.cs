using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerDto = (Customer)validationContext.ObjectInstance;

            if (customerDto.MembershipTypeId== MembershipType.Unknown || 
                customerDto.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customerDto.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Now.Year - customerDto.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success 
                :new ValidationResult("Customer must be at least 18 years of age to become a member.");
        }
    }
}