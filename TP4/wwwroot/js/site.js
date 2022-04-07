function annulerCreation() {
    let contenuFormulaire = document.getElementById("formulaireDiv");
    contenuFormulaire.innerHTML = "";

    let boutonCreer = document.getElementById("btnCreer");
    boutonCreer.disabled = false;
}

function afficherFormulaire() {
    let boutonCreer = document.getElementById("btnCreer");
    boutonCreer.disabled = true;
    let contenuFormulaire = document.getElementById("formulaireDiv");
    
    
    fetch("/Clients/Create").then(function (response) {
        if (response.ok) {
            response.text().then(function (data) {
                contenuFormulaire.innerHTML = data;
            });
        } 
    });
}



function creerClient(ev) {
    var form = ev.target.closest("form");
    var data = new FormData(form);
    if (data.get("TypeAbonnementId") == "" || data.get("TypeAbonnementId") == undefined) {
        data.set("TypeAbonnementId", -1);
    }
    var jsonData = JSON.stringify(Object.fromEntries(data));
    var csrfToken = form.querySelector(
        '[name="__RequestVerificationToken"]'
    ).value;

    fetch("/Clients/Create/", {
        method: "POST",

        /* Pour un envoi en JSON */
        contentType: "application/json; charset=utf-8",
        body:jsonData, // JSON of the form
        headers: {
          "Content-Type": "application/json",
          "RequestVerificationToken": csrfToken, //Envoyer le jeton CSRF avec la requête
        },
        
    }).then(function (response) {

        if (response.status == 400) {
            let contenuFormulaire = document.getElementById("formulaireDiv");
            response.text().then(function (data) {
                contenuFormulaire.innerHTML = data;
            });
        } else {
            let contenuTableau = document.getElementById("clientsList");
            response.text().then(function (data) {
                contenuTableau.innerHTML = data;
            });
            annulerCreation();
        }
        
    });
}


function deleteClient(clientId) {
    console.log("Clicked !", event);
    let clientListDiv = document.getElementById("clientsList");
    let csrfToken = clientListDiv.querySelector('[name="__RequestVerificationToken"]').value;
    console.log("CSRF : ", csrfToken)

    fetch("/clients/delete/" + clientId, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
            "RequestVerificationToken": csrfToken, 
        },
    }).then(res => {
        console.log("Res : ", res);
        if (res.ok) {
            return res.text()
        }
        else {
            return "Une erreur est survenu"
        }
    }).then(res => {
        afficherListeClient(res);
    });}

function afficherListeClient(partialView) {

    let divListe = document.getElementById("clientsList");
    divListe.innerHTML = partialView;
}
