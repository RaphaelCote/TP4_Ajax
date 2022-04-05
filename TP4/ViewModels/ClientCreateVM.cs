using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP4.ViewModels
{
    public class ClientCreateVM : IValidatableObject
    {
        [Required(ErrorMessage = "Le nom est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "L'âge est requis")]
        [Range(20, 75)]
        [DisplayName("Âge")]
        public int Age { get; set; }

        [DisplayName("Téléphone")]
        public string NumeroTelephone { get; set; }

        [Required(ErrorMessage = "Le courriel est requis")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Le champs doit contenir un email")]
        public string Courriel { get; set; }

        public List<SelectListItem> ListesAbonnement { get; set; }

        [Required(ErrorMessage = "L'abonnement n'est pas spécifié")]
        [DisplayName("Type d'abonnement")]
        public int TypeAbonnementId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!NumeroTelephone.Equals("") && NumeroTelephone.Length < 10)
            {
                yield return new ValidationResult($"Le numéro de téléphone doit contenir 10 chiffres.");
            }
        }
    }
}
