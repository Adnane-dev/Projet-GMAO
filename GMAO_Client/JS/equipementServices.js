/************************************************************************
 * **********************************************************************
 * 
 *         
 *          DTO Serialization Deserialization methods
 * 
 * 
 * **********************************************************************
 ***********************************************************************/

// Serialize Equipement
let serialize = (dtoEquipement) => {
    //let jsonEquipement = dtoEquipement.serialize();
    return JSON.stringify(dtoEquipement);
}

// Serialize List Equipement
let serializeList = (dtoEquipementList) => {
        return JSON.stringify(dtoEquipementList);
    }
    // Deserialize Equipement
let deserialize = (object) => {
    let dtoEquipement = new Equipement(object.Id, object.Type, object.Marque, object.Modele, object.NumeroSerie, object.Localisation, object.DateInstallation, object.DateGarantie);
    return dtoEquipement;
}

// Deserialize List Equipement
let deserializeList = (jsonEquipementList) => {
    let lsitEquipement = [];
    for (let item of jsonEquipementList)
        lsitEquipement.push(deserialize(item));
    return lsitEquipement;
}

/************************************************************************
 * **********************************************************************
 * 
 *         
 *          Consumption of Web API (Communication with the back)
 * 
 * 
 * **********************************************************************
 ***********************************************************************/

const urlAPI = "http://localhost:24632/Equipements";

/*******************************************    Asynchronous add Equipement     ***********************************/
let addEquipementAsync = async(equipement) => {
    try {
        let response = await fetch(urlAPI, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: equipement,
        });
        if (!response.ok) {
            throw new Error('Network response was not OK');
        }
        return response.json();
    } catch (e) {
        alertify.alert(e.message);
    }
}

/*******************************************    Synchronous add Equipement     ***********************************/
let addEquipementSync = (equipement, callback) => {
    try {
        fetch(urlAPI, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: equipement,
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not OK');
                }
                return response.json();
            })
            .then((response) => {
                if (response.success) {
                    callback(response);
                } else {
                    callback(null, response.message);
                }
            })
            .catch(error => {
                callback(null, error.statusText);
            });
    } catch (e) {
        callback(null, e.message);
    }
}

/*******************************************    Asynchronous update Equipement     ***********************************/
let updateEquipementAsync = async(id, equipement) => {
    try {
        let response = await fetch(`${urlAPI}/${id}`, {
            method: "PUT",
            headers: {
                'Content-Type': 'application/json',
            },
            body: equipement,
        });
        if (!response.ok) {
            throw new Error('Network response was not OK');
        }
        return response.json();
    } catch (e) {
        alertify.alert(e.message);
    }
}

/*******************************************    Synchronous update Equipement     ***********************************/
let updateEquipementSync = (id, equipement, callback) => {
    try {
        fetch(`${urlAPI}/${id}`, {
                method: "PUT",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: equipement,
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not OK');
                }
                return response.json();
            })
            .then((response) => {
                if (response.success) {
                    callback(response);
                } else {
                    callback(null, response.message);
                }
            })
            .catch(error => {
                callback(null, error.statusText);
            });
    } catch (e) {
        callback(null, e.message);
    }
}

/*******************************************    Asynchronous delete Equipement     ***********************************/
let deleteEquipementAsync = async(id) => {
    try {
        let response = await fetch(`${urlAPI}/${id}`, {
            method: "Delete",
            headers: {
                'Content-Type': 'application/json',
            },
        });
        if (!response.ok) {
            throw new Error('Network response was not OK');
        }
        return response.json();
    } catch (e) {
        alertify.error(e.message);
    }
}

/*******************************************    Synchronous delete Equipement     ***********************************/
let deleteEquipementSync = (id, callback) => {
    try {
        fetch(`${urlAPI}/${id}`, {
                method: "Delete",
                headers: {
                    'Content-Type': 'application/json',
                },
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not OK');
                }
                return response.json();
            })
            .then((response) => {
                if (response.success) {
                    callback(response);
                } else {
                    callback(null, response.message);
                }
            })
            .catch(error => {
                callback(null, error.statusText);
            });
    } catch (e) {
        callback(null, e.message);
    }
}

/*******************************************    Asynchronous get all Equipement     ***********************************/
let getAllEquipementsAsync = async() => {

    try {
        let response = await fetch(urlAPI, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
            },
        });
        if (!response.ok) {
            throw new Error('Network response was not OK');
        }
        return response.json();

    } catch (e) {
        alertify.alert(e.message);
    }
}

/*******************************************    Synchronous get all Equipement     ***********************************/
let getAllEquipementsSync = () => {
    try {
        fetch(urlAPI, {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json',
                },
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not OK');
                }
                return response.json();
            })
            .then((response) => {
                if (response.success) {
                    callback(response);
                } else {
                    callback(null, response.message);
                }
            })
            .catch(error => {
                callback(null, error.statusText);
            });

    } catch (e) {
        callback(null, e.message);
    }
}

let getEquipementById = async(id) => {
    try {
        let response = await fetch(`${urlAPI}/${id}`, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
            },
        });
        if (!response.ok) {
            throw new Error('Network response was not OK');
        }

        return Deserialize(response.json());

    } catch (e) {
        alertify.alert(e.message);
    }
}