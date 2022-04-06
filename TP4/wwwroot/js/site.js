function annulerCreation() {
    let contenuFormulaire = document.getElementById("formulaire");
    contenuFormulaire.innerHTML = "";

    let boutonCreer = document.getElementById("btnCreer");
    boutonCreer.disabled = false;
}

function afficherFormulaire() {
    let boutonCreer = document.getElementById("btnCreer");
    boutonCreer.disabled = true;
    let contenuFormulaire = document.getElementById("formulaire");
    
    
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
    var jsonData = JSON.stringify(Object.fromEntries(data));
    var csrfToken = form.querySelector(
        '[name="__RequestVerificationToken"]'
    ).value;

    fetch("/Controller/Create/", {
        method: "POST",

        // Envoyer tout le formulaire en FormData, y compris le jeton CSRF
        body: data,

        /* Pour un envoi en JSON     
         contentType: "application/json; charset=utf-8",
         body:jsonData // JSON of the form
         
        headers: {
          "Content-Type": "application/json",
          "X-CSRF-TOKEN": csrfToken, //Envoyer le jeton CSRF avec la requête
        },
        */
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response);
        }
        return response.json();
        annulerCreation();
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
