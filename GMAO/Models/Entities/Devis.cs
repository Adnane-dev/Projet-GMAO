using System.ComponentModel.DataAnnotations;

namespace GMAO.Models.Entities
{
    public class Devis
    {
        // Propriétés
        [Key]
        public int IdDevis { get; set; } // Clé primaire
        public DateTime DateDevis { get; set; }
        public decimal Prix { get; set; }
        public string Description { get; set; }

        // Propriété de navigation (en option)
        public Clients Client { get; set; } // Navigation vers l'objet Client associé

        /*/ Constructeurs
        public Devis()
        {
        }

        public Devis(int idDevis, DateTime dateDevis, decimal prix, string description, Clients client)
        {
            IdDevis = idDevis;
            DateDevis = dateDevis;
            Prix = prix;
            Description = description;
            Client = client; // Affectation du client associé
        }

        // Méthodes (en option)
        // Vous pouvez ajouter des méthodes pour calculer des taxes, générer des PDF, etc.
        // Exemple : Calculer le montant TTC du devis
        public decimal GetMontantTTC(decimal tauxTVA)
        {
            return Prix * (1 + tauxTVA / 100);
        }*/
    }
}
