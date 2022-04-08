using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TP4.Validations;

namespace TP4.ViewModels
{
    public class ClientCreateVM
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [DisplayName("Nom*")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "L'âge est requis")]
        [Range(20, 75, ErrorMessage = "L'âge doit être entre 20 et 75 ans")]
        [DisplayName("Âge*")]
        public int Age { get; set; }

        [DisplayName("Téléphone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Le format semble invalide")]
        [StringLength(10)]
        [Telephone]
        public string NumeroTelephone { get; set; }

        [Required(ErrorMessage = "Le courriel est requis")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-][\w-]*$", ErrorMessage = "Le champs doit contenir un email")]
        [DisplayName("Courriel*")]
        public string Courriel { get; set; }

        public List<SelectListItem> ListesAbonnement { get; set; }

        [Required(ErrorMessage = "L'abonnement n'est pas spécifié")]
        [DisplayName("Type d'abonnement*")]
        [Range(0, int.MaxValue, ErrorMessage = "Veuillez choisir un abonnement")]
        public int? TypeAbonnementId { get; set; }

    }
}
