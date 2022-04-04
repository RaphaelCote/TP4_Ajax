function annulerCreation() {
    let contenuFormulaire = document.getElementById("formulaire");
    contenuFormulaire.innerHTML = "";
}

// Write your JavaScript code.


function deleteClient(clientId) {}

function afficherFormulaire() {
    fetch("/Clients/Create").then(function (response) {
        if (response.ok) {
            response.text().then(function (data) {
                reponse4.innerHTML = data;
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
    });
}
