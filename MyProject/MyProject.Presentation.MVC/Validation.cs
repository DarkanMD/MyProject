using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace MyProject.Presentation.MVC
{
    public class PositiveNumber : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var myValidationRule = new ModelClientValidationRule
            {
                ErrorMessage = "This is An Error",
                ValidationType =""
            };
            return new[] {myValidationRule};
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            long number;
            if (long.TryParse(value.ToString(), out number))
            {
                return number > 0;
            }
            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}