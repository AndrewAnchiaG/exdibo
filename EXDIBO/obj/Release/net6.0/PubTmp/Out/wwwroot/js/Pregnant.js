
$(document).ready(function () {
    // Petition to DB
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: urlBase + '/Reporte/DataGestacion/',     //?desde=2022-01-01 00:00:00.000&hasta=2022-08-30 00:00:00.000
        error: function () {
            alert("Se produjo un error al consultar los datos");
        },
        success: function (data) {
            Graficar(data);
        }
    })
});

function Graficar(serie) {

    var date = new Date();
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    const timecurrent = Date.now();
    const today = new Date(timecurrent).getDate();
    var last = year - 1;

    Highcharts.chart('container', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Gráfico de Gestación Anual ' + last + '-' + year
        },
        subtitle: {
            text: 'Desde: 01/' + month + '/' + last + '- Hasta: ' + today + '/' + month + '/' +  year
        },
        xAxis: {
            categories: serie.months,
            arguments: serie.total,
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Vacas'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:1f} Vacas</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: [
        {
            name: 'Ovulaciones',
            data: serie.total
        }, {
            name: 'Gestación',
            data: serie.pregnants
        }, {
            name: 'Vacía',
            data: serie.emptys
        }]

    });
   
}