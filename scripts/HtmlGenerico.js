var FilterDom = {
    btnVotar: '#BtnVotar',
};



$(function() {

    //$("#tabs").tabs({fx:{opacity: "toggle"}}).tabs("rotate", 5000);

    // Dialog
    $('#user_log_form').dialog({
        autoOpen: false,
        width: 300,
        modal: true,
        title: 'Ingreso'
    }).dialog('widget').position({ of: $('#main_wrapper') });

    //If Submited open to show errors
    if ($('#ctl00_hidMostrarLogin').val() == 1) {
        $('#user_log_form').dialog('open');
    }

    // Dialog Link
    $('#userbox_log_link').click(function() {
        $('#user_log_form').dialog('open');
        return false;
    });

    //Cancel Btn for Dialogs
    $('#dialog-cancel').click(function() {
        $('#user_log_form').dialog('close');
        return false;
    });

    $('.reg_fields_box input[type="text"], .reg_fields_box select').tooltip();



});

/*
function jsonpcallback(rtndata) {

    console.log(rtndata);

    // Get the id from the returned JSON string and use it to reference the target jQuery object.
    var ul = $('<ul>').appendTo('#blog_stream');
    var json = rtndata;
    var count = 0;
    var insertText = '';
    $(json.posts).each(function(index, post) {
        post.title = post.title.replace('&#8211;', '-');

        insertText += '<li>';
        insertText += '<div class="nws_stream">';
        //-- To Show Images 
        if (count == 0) {
            $(post.attachments).each(function(index, attch) {

                insertText += '<a href="' + post.url + '" rel="bookmark" title="Ir a ' + post.title + '" target="_blank">';
                insertText += '<img src="' + attch.images.thumbnail.url + '" alt="' + post.title + '" />';
                insertText += '</a>';

            });
        }

        insertText += '<div>';
        insertText += '<h3><a href="' + post.url + '" target="_blank" title=" Ir a ' + post.title + '">' + post.title + '</a></h3>';
        insertText += '<span>Autor: ' + post.author.name + ' | ' + post.date + '</span>';
        insertText += '</div>';
        insertText += '</li>';
    });

    ul.append(insertText);

}*/

function jsonpcallback(e) {
    var t = $("<ul>").appendTo("#blog_stream");
    var n = e;
    var r = 0;
    var i = "";
    $(n.posts).each(function (e, t) {
        t.title = t.title.replace("&#8211;", "-");
        i += "<li>";
        i += '<div class="nws_stream">';
        if (r == 0) {
            $(t.attachments).each(function (e, n) {
                i += '<a href="' + t.url + '" rel="bookmark" title="Ir a ' + t.title + '" target="_blank">';
                i += '<img src="' + n.images.thumbnail.url + '" alt="' + t.title + '" />';
                i += "</a>"
            })
        }
        i += "<div>";
        i += '<h3><a href="' + t.url + '" target="_blank" title=" Ir a ' + t.title + '">' + t.title + "</a></h3>";
        i += "<span>Autor: " + t.author.name + " | " + t.date + "</span>";
        i += "</div>";
        i += "</li>"
    });
    t.append(i)
}



function IraSeccion(e) { window.location.href = "Secciones.aspx?Ide=" + e + "&Pag=1"; }

function IraEtiqueta(e) { window.location.href = "Tag.aspx?Ide=" + e + "&Pag=1" }



function validarRespuesta() {


    var Resp1 = '<%=sv_radio_opt_1.ClientID%>';
    var Resp2 = '<%=sv_radio_opt_2.ClientID%>';
    var Resp3 = '<%=sv_radio_opt_3.ClientID%>';
    var Resp4 = '<%=sv_radio_opt_4.ClientID%>';
    var Resp5 = '<%=sv_radio_opt_5.ClientID%>';
    var Resp6 = '<%=sv_radio_opt_6.ClientID%>';
    var Resp7 = '<%=sv_radio_opt_7.ClientID%>';
    var Resp8 = '<%=sv_radio_opt_8.ClientID%>';
    var Resp9 = '<%=sv_radio_opt_9.ClientID%>';
    var Resp10 = '<%=sv_radio_opt_10.ClientID%>';

    document.all("ErrorRespuesta").style.visibility = "hidden";
    document.all("ErrorRespuesta").style.display = 'none';

    var boHayRespuesta = 0;

    // alert(document.all(Resp1).checked);    
    if (document.all(Resp1).checked == true) {
        // alert('1');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp2).checked == true) {
        //alert('2');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp3).checked == true) {
        //alert('3');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp4).checked == true) {
        // alert('4');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp5).checked == true) {
        //alert('5');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp6).checked == true) {
        //alert('6');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp7).checked == true) {
        //alert('7');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp8).checked == true) {
        // alert('8');
        boHayRespuesta = 1;
    }
    else if (document.all(Resp9).checked == true) {
        //alert('9');
        boHayRespuesta = 1;
    }
    else (document.all(Resp10).checked == true)
    {
        //alert('10');
        boHayRespuesta = 1;
    }

    //alert('hola');
    if (boHayRespuesta == 0) {
        document.all("ErrorRespuesta").style.display = 'block';
        document.all("ErrorRespuesta").style.visibility = "visible";
        return false;
    }
    else {
        return true;
    }
}

$(document).ready(function() {

    //BuscarMenu();
    //CargarPregunta();
    BuscarEtiquetas();





    //$(document).ready(function() {
    //$('#blog_stream').load('http://lab.paralideres.org/pl-wp-list.php');

    var surl = "http://lab.paralideres.org/api/get_recent_posts/?count=7";
    var id = 1;
    $.ajax({
        url: surl,
        data: { id: id },
        dataType: "jsonp",
        jsonp: "callback",
        jsonpCallback: "jsonpcallback"
    });
    //});






});

function BuscarEtiquetas() {
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: 'Default.aspx/ListarEtiquetas',
        success: function(result) {
            $('#tblResultadoEtiquetas td').remove();

            if (result.d != null) {
                var grid = $('#tblResultadoEtiquetas');

                var row = "<tr>";
                row += "<td>" + result.d;
                row += "</td>";
                row += "</tr>"
                grid.find('> tbody').append(row);
                grid.show();
            }
        }
    });
}


function BuscarMenu() {
    $.ajax({
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        url: 'Default.aspx/ListarTablaMenu',
        success: function(result) {
            //$('#menu_bar').innerHTML = result.d;
            //$('#menu_bar').html(result.d);
            //$('#menu_bar').append(result.d);
            $('#menu').append('<div id="menu_bar">' + result.d + '</div>');
            //$('#MuestraGrafico').append('<div id="mask">' + result.d + '</div>');
            //alert(result.d);
        }
    });
}