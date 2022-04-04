using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Abonnement
    {
        public int AbonnementId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        public double PrixMensuel { get; set; }

        [Required]
        public int RabaisPourcentage { get; set; }
    }
}

