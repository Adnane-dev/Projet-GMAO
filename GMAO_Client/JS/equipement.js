const EquipementModal = new bootstrap.Modal('#modal-add-update-Equipement', {
    keyboard: false
});
const modalTitle = document.querySelector('.modal-title');
const EquipementsTbodyTable = document.getElementById("EquipementsTbodyTable");
let actionToDo = "";
let arrayEquipements = [];
MenuFrmEquipement.onclick = () => {
    modalTitle.textContent = "Add Equipement";
    actionToDo = "Add";
    EquipementModal.show();
}
let closeModal = document.querySelectorAll(".close-modal-Equipement");

hideModal = () => {
    frmEquipement.reset();
    EquipementModal.hide();
}
closeModal.forEach(item => {
    item.addEventListener('click', () => {
        hideModal();
    });
});

frmEquipement.onsubmit = (event) => {
    event.preventDefault();
    let equipement = serialize(frmEquipement.serialize(frmEquipement.querySelectorAll("input")));
    console.log(equipement);
    if (actionToDo === "Add") {

        /***************************************   Asynchronous method add Equipement    **************************************** */

        /*addEquipementAsync(Equipement)
        .then(response => 
            {
             if(response.success){
                alertify.alert(response.message,function(){
                    let Equipement = response.data;
                    arrayEquipements.push(Equipement);
                    BindDataToFrmNomFormulaire(Equipement);
                    hideModal();
                });
             }
             else{
                 alertify.alert(response.message);
             }
            })
            .catch(error => 
            {
                messageError(error);
            });*/

        /***************************************   Synchronous method add Equipement    ****************************************** */

        addEquipementSync(equipement, function(response, error) {
            if (response == null) {
                messageError(error);
            } else {
                alertify.alert(response.message, function() {
                    let equipement = response.data;
                    arrayEquipements.push(equipement);
                    bindDataToFrmNomFormulaire(equipement);
                    hideModal();
                });
            }
        });

    } else {
        let id = document.getElementById("IdEquipement").value;

        /***************************************   Asynchronous method update Equipement    **************************************** */
        /*updateEquipement(id,Equipement)
         .then(response => 
          {
              if(response.success){
                  alertify.alert(response.message,function(){
                      let newEquipement = response.data;
                      let index = arrayEquipements.findIndex(a => a.id === newEquipement.id);
                      arrayEquipements.splice(index, 1, newEquipement);
                      bindDataUpdate(id,newEquipement);
                      hideModal();
                  });
                 
              }
              else{
                  alertify.alert(response.message);
              }
          })
          .catch(error => 
          {
              messageError(error);
          });*/
        /***************************************   Synchronous method update Equipement    ****************************************** */
        updateEquipementSync(id, equipement, function(response, error) {
            if (response == null) {
                messageError(error);
            } else {
                alertify.alert(response.message, function() {
                    let newEquipement = response.data;
                    let index = arrayEquipements.findIndex(a => a.idEquipement === newEquipement.idEquipement);
                    arrayEquipements.splice(index, 1, newEquipement);
                    bindDataUpdate(id, newEquipement);
                    hideModal();
                });
            }
        });
    }
}

let getDataFromFrmNomFormulaire = (equipement) => {
    document.getElementById("IdEquipement").value = equipement.idEquipement;
    document.getElementById("Type").value = equipement.type;
    document.getElementById("Marque").value = equipement.marque;
    document.getElementById("Modele").value = equipement.modele;
    document.getElementById("NumeroSerie").value = equipement.numeroSerie;
    document.getElementById("Localisation").value = equipement.localisation;
    if (equipement.dateInstallation)
        document.getElementById("DateInstallation").value = equipement.dateInstallation.slice(0, 10);
    if (equipement.dateGarantie)
        document.getElementById("DateGarantie").value = equipement.dateGarantie.slice(0, 10);

}
let Update = (id) => {
    if (id) {
        modalTitle.textContent = "Update Equipement";
        actionToDo = "Update";
        let equipement = arrayEquipements.find(a => a.idEquipement === id);
        getDataFromFrmNomFormulaire(equipement);
        EquipementModal.show();
    } else {
        alertify.alert("Verify selected data");
    }
}

let Delete = (id) => {
    if (id) {
        alertify.set({
            labels: {
                ok: "Delete",
                cancel: "Cancel"
            }
        });
        alertify.confirm("Do you want to delete this Equipement ?", function(e) {
            if (e) {
                /***************************************   Asynchronous method add Equipement    ****************************************** */
                /*deleteEquipement(id)
                .then(response => 
                    {
                        if(response.success){
                            alertify.success(response.message);
                            arrayEquipements = arrayEquipements.filter(a => a.id !== id);
                            document.getElementById(`${id}`).remove();
                        }
                        else{
                            alertify.error(response.message);
                        }
                    })
                    .catch(error => 
                    {
                        messageError(error);
                    });*/

                /***************************************   Synchronous method add Equipement    ****************************************** */

                deleteEquipementSync(id, function(response, error) {
                    if (response == null) {
                        messageError(error);
                    } else {
                        alertify.success(response.message);
                        arrayEquipements = arrayEquipements.filter(a => a.idEquipement !== id);
                        document.getElementById(`${id}`).remove();
                    }
                });
            }
        });
    } else {
        alertify.alert("Verify selected data");
    }
}


getAllEquipementsAsync()
    .then(response => {
        if (response.success) {
            arrayEquipements = response.data;
            let lsitEquipement = deserializeList(arrayEquipements);
            bindDataToTableomTableau(lsitEquipement);
        } else {
            alertify.alert(response.message);
        }
    })
    .catch(error => {
        messageError(error);
    });



let messageError = (error) => {
    if (error.statusText === undefined)
        alertify.error("Start service please to communicate with customer");
    else
        alertify.error(error.statusText);
}


let bindDataToTableomTableau = (data) => {
    EquipementsTbodyTable.innerHTML = "";
    for (let equipement of data) {
        EquipementsTbodyTable.innerHTML += `<tr id="${equipement.idEquipement}">
                                     <td id="type_${equipement.idEquipement}">${equipement.type}</td>
                                     <td id="marque_${equipement.idEquipement}">${equipement.marque ?? ""}</td>
                                     <td id="modele_${equipement.idEquipement}">${equipement.modele ?? ""}</td>
                                     <td id="numeroSerie_${equipement.idEquipement}">${equipement.numeroSerie ?? ""}</td>
                                     <td id="localisation_${equipement.idEquipement}">${equipement.localisation ?? ""}</td>
                                     


                                     <td id="dateInstallation_${equipement.idEquipement}">${dateFormat(equipement.dateInstallation) ?? ""}</td>
                                     <td id="dateGarantie_${equipement.idEquipement}">${dateFormat(equipement.dateGarantie) ?? ""}</td>
                                     
                                     <td class="action-buttons">
                                      <a class="green" href="#" onclick="Update(${equipement.idEquipement})">
                                        <i class="fa fa-edit fa-2x"></i>
                                      </a>
                                      <a class="red" href="#" onclick="Delete(${equipement.idEquipement})">
                                        <i class="fa fa-trash fa-2x"></i>
                                      </a>
                                     </td>
                                    </tr>`;
    }
}

let bindDataToFrmNomFormulaire = (equipement) => {
    EquipementsTbodyTable.innerHTML += `<tr id="${equipement.idEquipement}">
                                        <td id="type_${equipement.idEquipement}">${equipement.type}</td>
                                        <td id="marque_${equipement.idEquipement}">${equipement.marque ?? ""}</td>
                                        <td id="modele_${equipement.idEquipement}">${equipement.modele ?? ""}</td>
                                        <td id="numeroSerie_${equipement.idEquipement}">${equipement.numeroSerie}</td>
                                        <td id="localisation_${equipement.idEquipement}">${equipement.localisation ?? ""}</td>
                                        <td id="dateInstallation_${equipement.idEquipement}">${dateFormat(equipement.dateInstallation) ?? ""}</td>
                                        <td id="dateGarantie_${equipement.idEquipement}">${dateFormat(equipement.dateGarantie) ?? ""}</td>
                                       
                                        <td class="action-buttons">
                                        <a class="green" href="#" onclick="Update(${equipement.idEquipement})">
                                        <i class="fa fa-edit fa-2x"></i>
                                        </a>
                                        <a class="red" href="#" onclick="Delete(${equipement.idEquipement})">
                                        <i class="fa fa-trash fa-2x"></i>
                                        </a>
                                        </td>
                                    </tr>`;
}
let bindDataUpdate = (id, equipement) => {
    console.log(id, equipement);
    console.log(equipement);
        document.getElementById(`type_${id}`).innerText = equipement.type ?? "";
        document.getElementById(`marque_${id}`).innerText = equipement.marque ?? "";
        document.getElementById(`modele_${id}`).innerText = equipement.modele ?? "";
        document.getElementById(`numeroSerie_${id}`).innerText = equipement.numeroSerie;
        document.getElementById(`localisation_${id}`).innerText = equipement.localisation ?? "";

        document.getElementById(`dateInstallation_${id}`).innerText = dateFormat(equipement.dateInstallation) ?? "";
        document.getElementById(`dateGarantie_${id}`).innerText = dateFormat(equipement.dateGarantie) ?? "";
    }
    /*
    let bindDataUpdate = (id, equipement) => {
        document.getElementById(`type_${id}`).innerText = equipement.type ? ? "";
        document.getElementById(`marque_${id}`).innerText = equipement.marque ? ? "" ;
        document.getElementById(`modele_${id}`).innerText = equipement.modele ? ? "";
        document.getElementById(`numeroSerie_${id}`).innerText = equipement.NumeroSerie;
        document.getElementById(`localisation_${id}`).innerText = equipement.Localisation ? ? "";

        document.getElementById(`dateInstallation_${id}`).innerText = dateFormat(equipement.dateInstallation) ? ? "";
        document.getElementById(`dateGarantie_${id}`).innerText = dateFormat(equipement.dateInstallation) ? ? "";
    }*/