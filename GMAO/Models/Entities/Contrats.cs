using System.ComponentModel.DataAnnotations;

namespace GMAO.Models.Entities
{
    public class Contrats
    {
        // Propriétés
        [Key]
        public int IdContrat { get; set; } // Clé primaire
        public string TypeContrat { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Prix { get; set; }
        public Clients Client { get; set; } // Navigation vers l'objet Client associé


    }

}


/*/ Propriété de navigation (en option)

// Constructeurs
public Contrats()
{
}

public Contrats(int idContrat, string typeContrat, DateTime dateDebut,
    DateTime dateFin, decimal prix, Clients client)
{
    IdContrat = idContrat;
    TypeContrat = typeContrat;
    DateDebut = dateDebut;
    DateFin = dateFin;
    Prix = prix;
    Client = client; // Affectation du client associé
}

// Méthodes (en option)
// Vous pouvez ajouter des méthodes pour calculer des durées, vérifier des conditions, etc.
// Exemple : Calculer la durée du contrat
public int GetDureeEnJours()
{
    return (DateFin - DateDebut).Days;
}
*/
