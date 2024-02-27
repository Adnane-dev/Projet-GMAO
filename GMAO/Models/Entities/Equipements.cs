namespace GMAO.Models.Entities
{
    public class Equipements
    {
        // Propriétés
        public int IdEquipement { get; set; } // Clé primaire
        public string Type { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string NumeroSerie { get; set; }
        public string Localisation { get; set; }
        public DateTime DateInstallation { get; set; }
        public DateTime DateGarantie { get; set; }
    }

}




// Constructeurs
/*  public Equipements()
  {
  }

  public Equipements(int idEquipement, string type, string marque, string modele,
      string numeroSerie, string localisation, DateTime dateInstallation,
      DateTime dateGarantie)
  {
      IdEquipement = idEquipement;
      Type = type;
      Marque = marque;
      Modele = modele;
      NumeroSerie = numeroSerie;
      Localisation = localisation;
      DateInstallation = dateInstallation;
      DateGarantie = dateGarantie;
  }

  // Méthodes (en option)
  // Vous pouvez ajouter des méthodes pour vérifier l'état de l'équipement, calculer la durée restante de garantie, etc.
  // Exemple : Vérifier si la garantie est toujours valide
  public bool EstSousGarantie()
  {
      return DateGarantie >= DateTime.Today;

        }


  */
