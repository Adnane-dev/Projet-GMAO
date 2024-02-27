using System.ComponentModel.DataAnnotations;

namespace GMAO.Models.Entities
{
    public class Clients
    {
        // Propriétés
        [Key]
        public int IdClient { get; set; } // Clé primaire
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Rue { get; set; }

    }
}

        /*/ Constructeurs
        public Clients()
        {
        }

        public Clients(int idClient, string nom, string prenom, string email,
            string telephone, string adresse, string codePostal, string ville, string pays)
        {
            IdClient = idClient;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Telephone = telephone;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
        }

        // Méthodes (en option)
        // Vous pouvez ajouter des méthodes pour obtenir/définir d'autres informations liées aux clients
        // Exemple : Obtenir le nom complet du client
        public string GetNomComplet()
        {
            return $"{Prenom} {Nom}";
        }
    }
        */


