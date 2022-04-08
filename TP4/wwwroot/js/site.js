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
        } else {
           contenuFormulaire.innerHTML = "Une erreur s'est produite.";
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

        contentType: "application/json; charset=utf-8",
        body:jsonData,
        headers: {
          "Content-Type": "application/json",
          "RequestVerificationToken": csrfToken, 
        },
        
    }).then(function (response) {
        let contenuFormulaire = document.getElementById("formulaireDiv");
        if (response.status == 400) {
            response.text().then(function (data) {
                contenuFormulaire.innerHTML = data;
            });
        } else if (response.ok) {
            let contenuTableau = document.getElementById("clientsList");
            response.text().then(function (data) {
                contenuTableau.innerHTML = data;
            });
            annulerCreation();
        } else {
            contenuFormulaire.innerHTML = "Une erreur s'est produite."
        }
        
    });
}


function deleteClient(clientId) {
 
    let clientListDiv = document.getElementById("clientsList");
    let csrfToken = clientListDiv.querySelector('[name="__RequestVerificationToken"]').value;


    fetch("/clients/delete/" + clientId, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json",
            "RequestVerificationToken": csrfToken, 
        },
    }).then(res => {

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
