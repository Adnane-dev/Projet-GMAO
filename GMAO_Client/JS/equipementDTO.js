class equipement

{
   #idEquipement;
    type;
    marque;
    modele;
    numeroSerie;
    localisation;
    dateInstallation;
    dateGarantie;
    constructor(pId, Type, Marque, Modele, NumeroSerie, Localisation, DateInstallation, DateGarantie) {
        this.idEquipement= pId;
        this.type = Type;
        this.marque = Marque;
        this.modele = Modele;
        this.numeroSerie = NumeroSerie;
        this.localisation = Localisation;
        this.dateInstallation = DateInstallation;
        this.dateGarantie = DateGarantie;

    }
}