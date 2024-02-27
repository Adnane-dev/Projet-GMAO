using System.ComponentModel.DataAnnotations;

namespace GMAO.Models.Entities
{
    public class Interventions
    {
        // Propriétés
        [Key]
        public int IdIntervention { get; set; } // Clé primaire
        public DateTime DateIntervention { get; set; }
        public TimeSpan HeureIntervention { get; set; } // Utilisé pour le temps, pas une chaîne de caractères
        public string TypeIntervention { get; set; }

        // Propriétés de navigation (en option)
        public Clients Client { get; set; } // Navigation vers l'objet Client associé
        public Equipements Equipement { get; set; } // Navigation vers l'objet Equipement associé
        public Techniciens Technicien { get; set; } // Navigation vers l'objet Technicien associé

        // Propriété supplémentaire
        public string Statut { get; set; }

        // Propriété pour commentaire optionnel
        public string Commentaire { get; set; }

        /*/ Constructeurs
        public Interventions()
        {
        }

        public Interventions(int idIntervention, DateTime dateIntervention, TimeSpan heureIntervention,
            string typeIntervention, Clients client, Equipements equipement, Techniciens technicien,
            string statut, string commentaire)
        {
            IdIntervention = idIntervention;
            DateIntervention = dateIntervention;
            HeureIntervention = heureIntervention;
            TypeIntervention = typeIntervention;
            Client = client;
            Equipement = equipement;
            Technicien = technicien;
            Statut = statut;
            Commentaire = commentaire;
        }

        // Méthodes (en option)
        // Vous pouvez ajouter des méthodes pour calculer la durée de l'intervention, générer des rapports, etc.
        // Exemple : Calculer la durée de l'intervention
       /*public TimeSpan GetDurée()
        {
            return DateIntervention.Date + HeureIntervention - DateIntervention.StartOfDay();
        }*/
    }

}
