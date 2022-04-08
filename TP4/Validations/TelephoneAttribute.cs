using System.ComponentModel.DataAnnotations;
using TP4.ViewModels;

namespace TP4.Validations
{
    public class TelephoneAttribute : ValidationAttribute
    {

        public string GetErrorMessage() => $"Le téléphone doit contenir 10 chiffres";


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var client = (ClientCreateVM)validationContext.ObjectInstance;
            var telephone = ((string)value);

            if (!telephone.Equals("") && telephone.Length < 10)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
