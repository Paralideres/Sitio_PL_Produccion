var FilterDom = {
    Anio: '#ddlYear',
    BtnBuscar: '#btnBuscar',
    Grafico: '#popup'
};
$(document).ready(function() {

   

    $('.pagination').jqPagination({
        link_string: '/?page={page_number}',
        max_page: 14,
        paged: function(page) {
            $('.log').prepend('<li>Requested page ' + page + '</li>');

            BuscarPreguntas(page);
        }

    });

    BuscarPreguntas(1);

    //alert('hola1') 
    //$(FilterDom.BtnBuscar).click(function() { alert('hola') });


    //    $('#MuestraGrafico').click(function() {
    //        $('#popup').fadeIn('slow');
    //        $('.popup-overlay').fadeIn('slow');
    //        $('.popup-overlay').height($(window).height());
    //        return false;
    //    });

    $('#close').click(function() {
        $('#popup').fadeOut('slow');
        // $('.popup-overlay').fadeOut('slow');
        return false;
    });

});


function BuscarPreguntas(page) {
    alert('hola');
    //$(FilterDom.BtnBuscar).click(function()    {



    var anio = $(FilterDom.Anio).val();
    var filtroDto = new Sistema.PL.Filtros.FiltroPregunta();
    //var sFeatures = "center:yes; resizable:no; status:no;dialogWidth:640px; dialogHeight:600px;"


    filtroDto.Numero = page;

    var dtoObj = Sys.Serialization.JavaScriptSerializer.serialize(filtroDto);
    var dataToSend = "{'oFiltro': " + dtoObj + "}";
    alert(dataToSend);
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: 'ResultadoEncuesta.aspx/BuscarByFiltros',
        data: dataToSend,
        success: function(result) {
            $('#tbResultadoBusqueda td').remove();
            if (result.d[0] != null) {
                $('#etiquetaResultado').text("");
                var grid = $('#tbResultadoBusqueda');
                $.each(result.d, function(index) {
                    var row = "<tr class=\"";
                    if (index % 2 == 0)
                        row += "gridRow";
                    else
                        row += "gridAltRow";
                    row += "\">";
                    row += "<td><a href=\"javascript:VerGrafico('" + this.Id_Pregunta + "')\"><img id=\"" + "VerResult_ " + this.Id_Pregunta + "\"   border='0'>" + this.Titulo_Pregunta + "</a>";
                    row += "</td>";
                    row += "<td>"
                    //row += "<a href=\"javascript:VerResultado('" + this.Id_Pregunta + "')\"><img id=\"" + "VerResult_ " + this.Id_Pregunta + "\"  title=\"Ver  Resultados\"  src=\".\\images\\detail.png\" border='0'></a>"
                    //row += "<a href=\"javascript:VerGrafico('" + this.Id_Pregunta + "')\"><img id=\"" + "VerResult_ " + this.Id_Pregunta + "\"  title=\"Ver  Resultados\"  src=\".\\images\\detail.png\" border='0'></a>"
                    row += this.MesAnno


                    //row += "<a href=\"javascript:window.open('ResultadoEncuesta.aspx?IdPr=" + this.Id_Pregunta + "')\"><img id=\"" + "VerResult_ " + this.Id_Pregunta + "\"  title=\"Ver  Resultados\"  src=\".\\images\\detail.png\" border='0'></a>"


                    row += "</td>";
                    row += "</tr>"
                    grid.find('> tbody').append(row);
                });
                grid.show();

            }
            else {
                $('#etiquetaResultado').text("No existen resultados para la búsqueda");
                $('#tbResultadoBusqueda').css('display', 'none');

            }
            //alert(result.d[0].Id_Pregunta);


        }
    });
    // });
}


//function VerGrafico(idpreg) {

//    var dtoObj = Sys.Serialization.JavaScriptSerializer.serialize(idpreg);
//    var dataToSend = "{'intIdPregunta': " + dtoObj + "}";

//    $.ajax({
//        type: 'POST',
//        contentType: 'application/json;charset=utf-8',
//        url: 'ListadoEncuestas.aspx/BuscarGrafico',
//        data: dataToSend,
//        success: function(result) {
//            $('#mask').remove();
//            $(FilterDom.Grafico).append('<div id="mask">' + result.d + '</div>');

//        }
//    });

//}

function VerGrafico(idpreg) {

    var dtoObj = Sys.Serialization.JavaScriptSerializer.serialize(idpreg);
    var dataToSend = "{'intIdPregunta': " + dtoObj + "}";

    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: 'ResultadoEncuesta.aspx/BuscarGrafico',
        data: dataToSend,
        success: function(result) {
            //$('#mask').remove();
            //$('#popup').fadeOut('slow');
            $('#popup').fadeIn('slow');
            // $('.popup-overlay').fadeIn('slow');
            // $('.popup-overlay').height($(window).height());
            // alert(result.d);
            $('#mask').remove();
            $('#MuestraGrafico').append('<div id="mask">' + result.d + '</div>');
            //$(FilterDom.Grafico).append('<div id="popup" style="display: none;"> <div class="content-popup"><div class="close"><a href="#" id="close"><img src="images/close.png"/></a></div><div>' + result.d + '</div></div></div>');

        }
    });

}

function VerResultado(idpreg) {




    window.open('ResultadoEncuesta.aspx?IdPr=' + idpreg);
    //window.open('Reports.aspx?reporname=reporte1', '', 'height=200,width=400,status=yes,toolbar=no,menubar=no,location=no');

    //window.location.href("ResultadoEncuesta.aspx?IdPr=" +d idpreg);
    //window.open('http://www.google.com');



}