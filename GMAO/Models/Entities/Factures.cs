using MessagePack;
using System.ComponentModel.DataAnnotations;


namespace GMAO.Models.Entities
{

    public class Factures
    {
        // Propriétés
        [System.ComponentModel.DataAnnotations.Key]
        public int IdFacture { get; set; } // Clé primaire
        public DateTime DateFacture { get; set; }
        public decimal Prix { get; set; }

        // Propriété de navigation (en option)
        public Clients Client { get; set; } // Navigation vers l'objet Client associé

        // Constructeurs
        public Factures()
        {
        }

        public Factures(int idFacture, DateTime dateFacture, decimal prix, Clients client)
        {
            IdFacture = idFacture;
            DateFacture = dateFacture;
            Prix = prix;
            Client = client; // Affectation du client associé
        }

        // Méthodes (en option)
        // Vous pouvez ajouter des méthodes pour calculer des taxes, générer des PDF, etc.
        // Exemple : Calculer le montant TTC de la facture
        public decimal GetMontantTTC(decimal tauxTVA)
        {
            return Prix * (1 + tauxTVA / 100);
        }
    }


}
