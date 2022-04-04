using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Courriel { get; set; }

        [Required]
        public string NoTelephone { get; set; }
        public Abonnement Abonnement { get; set; }
    }
}
