using System.ComponentModel.DataAnnotations;

namespace GMAO.Models.Entities
{
    public class Stocks
    {
        // Propriétés
        [Key]
        public int IdStock { get; set; } // Clé primaire
        public string Produit { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }

        // Méthodes (en option)
        // Vous pouvez ajouter des méthodes pour calculer la valeur du stock, gérer les entrées et sorties, etc.
        // Exemple : Calculer la valeur du stock
        public decimal GetValeurStock()
        {
            return Quantite * PrixUnitaire;
        }
    }

}
