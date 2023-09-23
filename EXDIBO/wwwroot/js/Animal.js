

//  Search Father By Number and set text in the inputs
function searchFather() {
    var input = document.getElementById("numFather");
    var num = parseInt(input.value);
    if (num >= 10) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: 'https://' + urlBase + '/Animal/Res/' + num,
            error: function () {
                window.location.replace("https://exdibo.azurewebsites.net/Expediente/ProblemasConexion");
            },
            success: function (data) {
                document.getElementById('IdFather').value = data.id;
                document.getElementById('father').value = data.name;
                document.getElementById('generofather').value = data.gender;
                if (data.gender.trim() === "Hembra".trim()) {
                    document.getElementById('msgf').innerText = "La vaca seleccionada no puede ser el Padre";
                } else {
                    document.getElementById('msgf').innerText = "";
                }
            }
        });
    }
}


//  Search Mother By Number and set text in the inputs

function searchMother() {
    var input = document.getElementById("numMother");
    var num = parseInt(input.value);
    if (num >= 10) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: 'https://' + urlBase + '/Animal/Res/' + num,
            error: function () {
                window.location.replace("https://exdibo.azurewebsites.net/Expediente/ProblemasConexion");
            },
            success: function (data) {
                document.getElementById('IdMother').value = data.id;
                document.getElementById('Mother').value = data.name;
                document.getElementById('generoMother').value = data.gender;
                if (data.gender.trim() === "Macho".trim()) {
                    document.getElementById('msgm').innerText = "El Toro seleccionado no puede ser la Madre";
                } else { document.getElementById('msgm').innerText = ""; }

            }
        });
    }
}


//  Search Father By ID and set text in the inputs

function searchFatherId() {
    var input = document.getElementById("numFather");
    var num = parseInt(input.value);
    if (num >= 10) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: 'https://' + urlBase + '/Animal/ResById/' + num,
            error: function () {
                window.location.replace("https://exdibo.azurewebsites.net/Expediente/ProblemasConexion");
            },
            success: function (data) {
                document.getElementById('IdFather').value = data.id;
                document.getElementById('generofather').value = data.gender;
                if (data.gender.trim() === "Hembra".trim()) {
                    document.getElementById('msgf').innerText = "La vaca seleccionada no puede ser el Padre";
                } else { document.getElementById('msgf').innerText = ""; }
            }
        });
    }
}


//  Search Mother By ID and set text in the inputs

function searchMotherId() {
    var input = document.getElementById("numMother");
    var num = parseInt(input.value);
    if (num >= 10) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: 'https://' + urlBase + '/Animal/ResById/' + num,
            error: function () {
                window.location.replace("https://exdibo.azurewebsites.net/Expediente/ProblemasConexion");
            },
            success: function (data) {
                document.getElementById('IdMother').value = data.id;
                document.getElementById('Mother').value = data.name;
                document.getElementById('generoMother').value = data.gender;
                if (data.gender.trim() === "Macho".trim()) {
                    document.getElementById('msgm').innerText = "El Toro seleccionado no puede ser la Madre";
                } else { document.getElementById('msgm').innerText = ""; }

            }
        });
    }
}