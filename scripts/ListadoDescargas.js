
$(document).ready(function() {

    //$('#Mes > option[value="3"]').attr('selected', 'selected');


    var d = new Date();
    var Anio_actual = d.getFullYear();
    var Mes_actual = d.getMonth();
    if (Mes_actual <= 11) {
        Mes_actual = d.getMonth() + 1;
    
    }
    //alert(Mes_actual + ' +++ ' + Anio_actual);

    $('#Mes > option[value="' + Mes_actual + '"]').attr('selected', 'selected');
    $('#Anio > option[value="' + Anio_actual + '"]').attr('selected', 'selected');

    $('#TotalDescargas').text("Total de Descargas 0");



    $('.pagination').jqPagination({
        link_string: '/?page={page_number}',
        max_page: 14,
        paged: function(page) {
            $('.log').prepend('<li>Requested page ' + page + '</li>');

            Buscar(page);
            //alert('otra paginas ' + page);
        }

    });


    //Buscar(1);

    $('#btnMostrar').click(function() {
        // alert('1');
        // alert('inicio pagina 1');
        Buscar(1);
    });

    //    $('select#Mes').on('change', function() {
    //        var valor = $(this).val();
    //        alert(valor);
    //    });
    //    $('select#Anio').on('change', function() {
    //        var valor = $(this).val();
    //        alert(valor);
    //    });

    $('#btnMostrarPorMes').click(function() {
        // alert('1');
        //alert('inicio pagina 1');

        var Mes = $("#Mes").val();
        var Anio = $("#Anio").val();
        //alert(Mes + ' +++ ' + Anio);
        BuscarMesAnio(1, Mes, Anio);
    });

    //    $('#btnMostrar').bind('click',function() {
    //        // alert('1');
    //        alert('inicio pagina 1');
    //        Buscar(1);
    //    });



});


function Buscar(page) {
    //alert('llamando al server');
    var dataToSend = "{'intPagina': " + page + "}";
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: 'ListadoDescargas.aspx/BuscarTodasLasDescargas',
        data: dataToSend,
        success: function(result) {
            $('#tbResultadoBusqueda td').remove();
            if (result.d[0] != null) {
                //alert(result.d[0]);
                $('#etiquetaResultado').text("");

                var grid = $('#tbResultadoBusqueda');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";
                    row += "\">";
                    row += "<td>" + this.Titulo;
                    row += "</td>";
                    row += "<td>"
                    row += this.CantidadDescargaPagina
                    row += "</td>";
                    row += "</tr>"

                    grid.find('> tbody').append(row);
                    $('#TotalDescargas').text("Total de Descargas " + this.CantidadTotal);
                });
                grid.show();

            }
            else {
                $('#etiquetaResultado').text("No existen resultados para la búsqueda");
                $('#tbResultadoBusqueda').css('display', 'none');

            }
        }
    });
}

function BuscarMesAnio(page, Mes, Anio) {
    //alert('llamando al server 2');
    //var dataToSend = "{'intPagina': " + page + "}";
    var dataToSend = "{'intPagina': " + page + ", 'intMes': " + Mes + ", 'intAnio': " + Anio + "}";
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: 'ListadoDescargas.aspx/BuscarDescarga_x_Mes_Anio',
        data: dataToSend,
        success: function(result) {
            $('#tbResultadoBusqueda td').remove();
            if (result.d[0] != null) {
                //alert(result.d[0]);
                $('#etiquetaResultado').text("");

                var grid = $('#tbResultadoBusqueda');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";
                    row += "\">";
                    row += "<td>" + this.Titulo;
                    row += "</td>";
                    row += "<td>"
                    row += this.CantidadDescargaPagina
                    row += "</td>";
                    row += "</tr>"

                    grid.find('> tbody').append(row);
                    $('#TotalDescargas').text("Total de Descargas " + this.CantidadTotal);
                });
                grid.show();

            }
            else {
                $('#etiquetaResultado').text("No existen resultados para la búsqueda");
                $('#tbResultadoBusqueda').css('display', 'none');

            }
        }
    });
}


