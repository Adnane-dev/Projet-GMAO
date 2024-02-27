using System.ComponentModel.DataAnnotations;

namespace GMAO.Models.Entities
{
    public class Techniciens
    {
        // Propriétés
        [Key]
        public int IdTechnicien { get; set; } // Clé primaire
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Specialisation { get; set; }

    }

}


// Méthodes (en option)
// Vous pouvez ajouter des méthodes pour vérifier le format des informations saisies, etc.
// Exemple : Vérifier le format de l'adresse email
/*  public bool EstEmailValide()
  {
      // Implémentation de la validation de l'email
      // (vérification de la syntaxe, utilisation de bibliothèques spécifiques, etc.)
  }
*/
// Propriétés de navigation (en option)
// Vous pourriez envisager de lier les techniciens à d'autres classes, par exemple :
// - Intervention pour accéder aux interventions auxquelles le technicien est affecté.

/* Constructeurs
public Techniciens()
{
}

public Techniciens(int idTechnicien, string nom, string prenom, string email, string telephone, string specialisation)
{
    IdTechnicien = idTechnicien;
    Nom = nom;
    Prenom = prenom;
    Email = email;
    Telephone = telephone;
    Specialisation = specialisation;
}*/
