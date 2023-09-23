



//  Search Bovine By Number and Set text in the labels

function searchCaw() {                 // Numero de Vaca
        var input = document.getElementById("caw");
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
                    document.getElementById('IdBovine').value = data.id;
                    document.getElementById('bovine').value = data.name;
                    document.getElementById('earring').value = data.earring;
                    document.getElementById('genderbovine').value = data.gender;
                    document.getElementById('Output').value = data.productionMilk;
                    var selectFarm = document.getElementById('IdFarm');
                    var selectGroup = document.getElementById('IdGroup');
                    selectFarm.value = data.idFarm;
                    selectGroup.value = data.idGroup;

                    if (data.gender.trim() === "Macho".trim()) {
                        document.getElementById('msgerror').innerText = "El número seleccionado es un Macho, no puede producir leche";
                    } else
                    {
                        document.getElementById('msgerror').innerText = "";
                    }

                }
            });
        }
    }