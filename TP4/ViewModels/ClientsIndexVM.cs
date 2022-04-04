using System.ComponentModel;

namespace TP4.ViewModels
{
    public class ClientsIndexVM
    {

        public int ClientId { get; set; }

        public string Nom { get; set; }

        [DisplayName("Âge")]
        public int Age { get; set; }

        public string Courriel { get; set; }

        [DisplayName("Téléphone")]
        public string NoTelephone { get; set; }

        [DisplayName("Type d'abonnement")]
        public string TypeAbonnement { get; set; }
    }
}
