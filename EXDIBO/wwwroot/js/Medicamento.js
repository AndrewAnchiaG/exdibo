function searchbovine() {
    var input = document.getElementById("bovine");
    var num = parseInt(input.value);
    if (num >= 10) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: 'https://' + urlBase  + '/Animal/Res/' + num,
            error: function () {
                window.location.replace("https://exdibo.azurewebsites.net/Expediente/ProblemasConexion");
            },
            success: function (data) {
                document.getElementById('IdBovine').value = data.id;
                document.getElementById('lblnombre').value = data.name;
                document.getElementById('lblarete').value = data.earring;
                document.getElementById('lblgenero').value = data.gender;
                document.getElementById('IdFarm').value = data.idFarm;
                document.getElementById('IdGroup').value = data.idGroup;
            }
        });
    }
}