var Idp = ObtenerValorParametroUrl('Idp');
var ValorUsuario;
var ValorEstrella;

var FilterDom = {
    Estrella_on1: '#Estrella_on1',
    Estrella_on2: '#Estrella_on2',
    Estrella_on3: '#Estrella_on3',
    Estrella_on4: '#Estrella_on4',
    Estrella_on5: '#Estrella_on5',
    Estrella_off1: '#Estrella_off1',
    Estrella_off2: '#Estrella_off2',
    Estrella_off3: '#Estrella_off3',
    Estrella_off4: '#Estrella_off4',
    Estrella_off5: '#Estrella_off5',

    EstrellaBloq_0: '#EstrellaBloq_0',
    EstrellaBloq_1: '#EstrellaBloq_1',
    EstrellaBloq_2: '#EstrellaBloq_2',
    EstrellaBloq_3: '#EstrellaBloq_3',
    EstrellaBloq_4: '#EstrellaBloq_4',
    EstrellaBloq_5: '#EstrellaBloq_5'



};

$(window).load(function() {
    //alert('hola')
    //    var CantDescarga = ObtenerDescargas();
    //    //alert(CantDescarga);
    //    if (CantDescarga > 0) {
    //        $('#liDescargas').text("Descargas " + CantDescarga );
    //    }
});


$(document).ready(function() {

    var CantDescarga = ObtenerDescargas();
    //alert(CantDescarga);
    if (CantDescarga > 0) {
        $('#liDescargas').text(CantDescarga + " Descargas ");
    }

    // OcultarEstrellas();

    ObtenerValorUsuario(ValorUsuario);
    //alert(ValorUsuario);
    ObtenerValorEstrella();
    //alert(ValorEstrella);

    OcultarEstrellas();
    if (ValorUsuario > 0) {
        MostrarEstrellas();
    }
    else {
        MostrarEstrellasBloqueadas()
        $(FilterDom.EstrellaBloq_0).click(function() {
            $('#popup').fadeIn('slow');
        });
        $(FilterDom.EstrellaBloq_1).click(function() {
            $('#popup').fadeIn('slow');
        });
        $(FilterDom.EstrellaBloq_2).click(function() {
            $('#popup').fadeIn('slow');
        });
        $(FilterDom.EstrellaBloq_3).click(function() {
            $('#popup').fadeIn('slow');
        });
        $(FilterDom.EstrellaBloq_4).click(function() {
            $('#popup').fadeIn('slow');
        });
        $(FilterDom.EstrellaBloq_5).click(function() {
            $('#popup').fadeIn('slow');
        });
    }
    //alert(ValorEstrella);


    $(FilterDom.Estrella_on1).click(function() {
        //alert('on1');
        ValorarArticulo(1);
    });
    $(FilterDom.Estrella_on2).click(function() {
        //alert('on2');
        ValorarArticulo(2);
    });
    $(FilterDom.Estrella_on3).click(function() {
        //alert('on3');
        ValorarArticulo(3);
    });
    $(FilterDom.Estrella_on4).click(function() {
        //alert('on4');
        ValorarArticulo(4);
    });
    $(FilterDom.Estrella_on5).click(function() {
        //alert('on5');
        ValorarArticulo(5);
    });
    $(FilterDom.Estrella_off1).click(function() {
        //alert('off1');
        ValorarArticulo(1);
    });
    $(FilterDom.Estrella_off2).click(function() {
        //alert('off2');
        ValorarArticulo(2);
    });
    $(FilterDom.Estrella_off3).click(function() {
        //alert('off3');
        ValorarArticulo(3);
    });
    $(FilterDom.Estrella_off4).click(function() {
        //alert('off4');
        ValorarArticulo(4);
    });
    $(FilterDom.Estrella_off5).click(function() {
        //alert('off5');
        ValorarArticulo(5);
    });

    $('#close').click(function() {
        $('#popup').fadeOut('slow');
        // $('.popup-overlay').fadeOut('slow');
        // $('#user_log_form').hide();
        return false;
    });


    $('#img_descargar_Doc').click(function() {
        // alert('1');
        RegistarDescarga();
        var CantDescarga = ObtenerDescargas();
        //alert(CantDescarga);
        if (CantDescarga > 0) {
            $('#liDescargas').text(CantDescarga + " Descargas ");
        }
        // alert('Doc ' + CantDescarga);
    });


    $('#img_descargar_Pdf').click(function() {
        // alert('1');
        RegistarDescarga();
        var CantDescarga = ObtenerDescargas();
        //alert(CantDescarga);
        if (CantDescarga > 0) {
            $('#liDescargas').text(CantDescarga + " Descargas ");
        }
        // alert('Pdf ' + CantDescarga);
    });


    $('#img1').click(function() {
        // alert('1');
        RegistarDescarga();
        var CantDescarga = ObtenerDescargas();
        //alert(CantDescarga);
        if (CantDescarga > 0) {
            $('#liDescargas').text(CantDescarga + " Descargas ");
        }
        // alert('img1 ' + CantDescarga);
    });





});

function RegistarDescarga() {
    //alert('2');
    var resultado;
    var Cantidad = 1;
    //alert('3');
    var dataToSend = "{'IdPagina': " + Idp + ", 'Valor': " + Cantidad + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/RegistarDescargaRecurso",
        data: dataToSend,
        //data: { elemento1: valorSelect1, elemento2: valorSelect2 },
        success: function(result) {
            resultado = result.d;
            //            if (resultado > 0) {
            //                Ocultar(valor);
            //            }
        }
    });
    return resultado;
}
function ValorarArticulo(valor) {
    var resultado;
    //var filtroDto2 = new Sistema.PL.Filtros.FiltroPagina();
    //alert(ValorUsuario);
    //Idp;
    //ValorUsuario;
    //valor;

    //var dtoObj = Sys.Serialization.JavaScriptSerializer.serialize(filtroDto2);
    //var dataToSend = "{'oPagina': " + dtoObj + "}";

    var dataToSend = "{'IdPagina': " + Idp + ", 'IdUser': " + ValorUsuario + ", 'Valor': " + valor + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/ValorarArticulo",
        data: dataToSend,
        //data: { elemento1: valorSelect1, elemento2: valorSelect2 },
        success: function(result) {
            resultado = result.d;
            if (resultado > 0) {
                Ocultar(valor);
                Mostrar(valor);
                //                if (valor == 1) {
                //                    Ocultar(valor);
                //                    Mostrar(Valor);
                //                    $(FilterDom.Estrella_off1).hide();
                //                    $(FilterDom.Estrella_on1).show();
                //                    $(FilterDom.Estrella_on2).show();
                //                    $(FilterDom.Estrella_off2).show();
                //                    $(FilterDom.Estrella_off3).show();
                //                    $(FilterDom.Estrella_off4).show();
                //                    $(FilterDom.Estrella_off5).show();
                //                }
                //                else if (valor == 2) {
                //                    $(FilterDom.Estrella_off1).hide();
                //                    $(FilterDom.Estrella_on1).show();

                //                    $(FilterDom.Estrella_off2).hide();
                //                    $(FilterDom.Estrella_on2).show();
                //                    $(FilterDom.Estrella_off3).show();
                //                    $(FilterDom.Estrella_off4).show();
                //                    $(FilterDom.Estrella_off5).show();
                //                }
                //                else if (valor == 3) {
                //                    $(FilterDom.Estrella_off1).hide();
                //                    $(FilterDom.Estrella_on1).show();
                //                    $(FilterDom.Estrella_off2).hide();
                //                    $(FilterDom.Estrella_on2).show();
                //                    $(FilterDom.Estrella_off3).hide();
                //                    $(FilterDom.Estrella_on3).show();
                //                }
                //                else if (valor == 4) {
                //                    $(FilterDom.Estrella_off1).hide();
                //                    $(FilterDom.Estrella_on1).show();
                //                    $(FilterDom.Estrella_off2).hide();
                //                    $(FilterDom.Estrella_on2).show();
                //                    $(FilterDom.Estrella_off3).hide();
                //                    $(FilterDom.Estrella_on3).show();
                //                    $(FilterDom.Estrella_off4).hide();
                //                    $(FilterDom.Estrella_on4).show();
                //                    $(FilterDom.Estrella_off4).show();
                //                    $(FilterDom.Estrella_off5).show();
                //                }
                //                else if (valor == 5) {
                //                    $(FilterDom.Estrella_off1).hide();
                //                    $(FilterDom.Estrella_on1).show();
                //                    $(FilterDom.Estrella_off2).hide();
                //                    $(FilterDom.Estrella_on2).show();
                //                    $(FilterDom.Estrella_off3).hide();
                //                    $(FilterDom.Estrella_on3).show();
                //                    $(FilterDom.Estrella_off4).hide();
                //                    $(FilterDom.Estrella_on4).show();
                //                    $(FilterDom.Estrella_off5).hide();
                //                    $(FilterDom.Estrella_on5).show();
                //                }

            }
        }
    });
    return resultado;
}

//function Muestra_y_Oculta(valor) {
//    $(FilterDom.Estrella_off1).hide();
//    $(FilterDom.Estrella_off2).hide();
//    $(FilterDom.Estrella_off3).hide();
//    $(FilterDom.Estrella_off4).hide();
//    $(FilterDom.Estrella_off5).hide();

//    if (valor == 1) {


//    }

//}

function Ocultar(valor) {
    if (valor == 1) {
        $(FilterDom.Estrella_off1).hide();
        $(FilterDom.Estrella_off2).show();
        $(FilterDom.Estrella_off3).show();
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off5).show();
    }
    else if (valor == 2) {
        $(FilterDom.Estrella_off1).hide();
        $(FilterDom.Estrella_off2).hide();
        $(FilterDom.Estrella_off3).show();
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off5).show();
    }
    else if (valor == 3) {
        $(FilterDom.Estrella_off1).hide();
        $(FilterDom.Estrella_off2).hide();
        $(FilterDom.Estrella_off3).hide();
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off5).show();
    }
    else if (valor == 4) {
        $(FilterDom.Estrella_off1).hide();
        $(FilterDom.Estrella_off2).hide();
        $(FilterDom.Estrella_off3).hide();
        $(FilterDom.Estrella_off4).hide();
        $(FilterDom.Estrella_off5).show();
    }
    else if (valor == 5) {
        $(FilterDom.Estrella_off1).hide();
        $(FilterDom.Estrella_off2).hide();
        $(FilterDom.Estrella_off3).hide();
        $(FilterDom.Estrella_off4).hide();
        $(FilterDom.Estrella_off5).hide();
    }

}
function Mostrar(valor) {

    if (valor == 5) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on3).show();
        $(FilterDom.Estrella_on4).show();
        $(FilterDom.Estrella_on5).show();
    }
    else if (valor == 4) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on3).show();
        $(FilterDom.Estrella_on4).show();
        $(FilterDom.Estrella_on5).hide();
    }
    else if (valor == 3) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on3).show();
        $(FilterDom.Estrella_on4).hide();
        $(FilterDom.Estrella_on5).hide();
    }
    else if (valor == 2) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on3).hide();
        $(FilterDom.Estrella_on4).hide();
        $(FilterDom.Estrella_on5).hide();
    }
    else if (valor == 1) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on2).hide();
        $(FilterDom.Estrella_on3).hide();
        $(FilterDom.Estrella_on4).hide();
        $(FilterDom.Estrella_on5).hide();
    }


}


function OcultarEstrellas() {
    $(FilterDom.Estrella_on1).hide();
    $(FilterDom.Estrella_on2).hide();
    $(FilterDom.Estrella_on3).hide();
    $(FilterDom.Estrella_on4).hide();
    $(FilterDom.Estrella_on5).hide();
    $(FilterDom.Estrella_off1).hide();
    $(FilterDom.Estrella_off2).hide();
    $(FilterDom.Estrella_off3).hide();
    $(FilterDom.Estrella_off4).hide();
    $(FilterDom.Estrella_off5).hide();

    $(FilterDom.EstrellaBloq_0).hide();
    $(FilterDom.EstrellaBloq_1).hide();
    $(FilterDom.EstrellaBloq_2).hide();
    $(FilterDom.EstrellaBloq_3).hide();
    $(FilterDom.EstrellaBloq_4).hide();
    $(FilterDom.EstrellaBloq_5).hide();



}

function ObtenerValorParametroUrl(parametro) {
    hu = window.location.search.substring(1);
    gy = hu.split("&");
    for (i = 0; i < gy.length; i++) {
        ft = gy[i].split("=");
        if (ft[0] == parametro) {
            return ft[1];
        }
    }
}

function ObtenerValorUsuario() {
    $.ajax({
        type: "POST",
        url: "VerArticulo.aspx/ObtieneValorUsuarioSession",
        //data: '{IdPagina: "' + Idp + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function(result) {
            //alert(result.d);
            ValorUsuario = result.d;
        }
    });
    return ValorUsuario;
}

function ObtenerDescargas() {
    //alert('2');
    var resultado;
    var Cantidad = 1;
    //alert('3');
    var dataToSend = "{'IdPagina': " + Idp + "}";
    //alert(dataToSend);
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/Descargas",
        async: false,
        data: dataToSend,
        //data: { elemento1: valorSelect1, elemento2: valorSelect2 },
        success: function(result) {
            resultado = result.d;
        }
    });
    return resultado;
}

function ObtenerValorEstrella() {
    $.ajax({
        type: "POST",
        contentType: "application/json;charset=utf-8",
        url: "VerArticulo.aspx/ValorEstrellas",
        data: '{IdPagina: "' + Idp + '" }',
        async: false,
        success: function(result) {
            ValorEstrella = result.d;
        }
    });

    return ValorEstrella;
}



function MostrarEstrellasBloqueadas() {

    if (ValorEstrella == 0) {
        $(FilterDom.EstrellaBloq_0).show();

    }
    else if (ValorEstrella == 1) {
        $(FilterDom.EstrellaBloq_1).show();
    }
    else if (ValorEstrella == 2) {
        $(FilterDom.EstrellaBloq_2).show();
    }
    else if (ValorEstrella == 3) {
        $(FilterDom.EstrellaBloq_3).show();
    }
    else if (ValorEstrella == 4) {
        $(FilterDom.EstrellaBloq_4).show();
    }
    else if (ValorEstrella == 5) {
        $(FilterDom.EstrellaBloq_5).show();
    }



}


function MostrarEstrellas() {
    if (ValorEstrella == 0) {
        $(FilterDom.Estrella_off1).show();
        $(FilterDom.Estrella_off1).css('cursor', 'pointer');
        $(FilterDom.Estrella_off2).show();
        $(FilterDom.Estrella_off2).css('cursor', 'pointer');
        $(FilterDom.Estrella_off3).show();
        $(FilterDom.Estrella_off3).css('cursor', 'pointer');
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off4).css('cursor', 'pointer');
        $(FilterDom.Estrella_off5).show();
        $(FilterDom.Estrella_off5).css('cursor', 'pointer');
    }
    else if (ValorEstrella == 1) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on1).css('cursor', 'pointer');
        $(FilterDom.Estrella_off2).show();
        $(FilterDom.Estrella_off2).css('cursor', 'pointer');
        $(FilterDom.Estrella_off3).show();
        $(FilterDom.Estrella_off3).css('cursor', 'pointer');
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off4).css('cursor', 'pointer');
        $(FilterDom.Estrella_off5).show();
        $(FilterDom.Estrella_off5).css('cursor', 'pointer');
    }
    else if (ValorEstrella == 2) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on1).css('cursor', 'pointer');
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on2).css('cursor', 'pointer');
        $(FilterDom.Estrella_off3).show();
        $(FilterDom.Estrella_off3).css('cursor', 'pointer');
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off4).css('cursor', 'pointer');
        $(FilterDom.Estrella_off5).show();
        $(FilterDom.Estrella_off5).css('cursor', 'pointer');
    }
    else if (ValorEstrella == 3) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on1).css('cursor', 'pointer');
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on2).css('cursor', 'pointer');
        $(FilterDom.Estrella_on3).show();
        $(FilterDom.Estrella_on3).css('cursor', 'pointer');
        $(FilterDom.Estrella_off4).show();
        $(FilterDom.Estrella_off4).css('cursor', 'pointer');
        $(FilterDom.Estrella_off5).show();
        $(FilterDom.Estrella_off5).css('cursor', 'pointer');
    }
    else if (ValorEstrella == 4) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on1).css('cursor', 'pointer');
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on2).css('cursor', 'pointer');
        $(FilterDom.Estrella_on3).show();
        $(FilterDom.Estrella_on3).css('cursor', 'pointer');
        $(FilterDom.Estrella_on4).show();
        $(FilterDom.Estrella_on4).css('cursor', 'pointer');
        $(FilterDom.Estrella_off5).show();
        $(FilterDom.Estrella_off5).css('cursor', 'pointer');
    }
    else if (ValorEstrella == 5) {
        $(FilterDom.Estrella_on1).show();
        $(FilterDom.Estrella_on1).css('cursor', 'pointer');
        $(FilterDom.Estrella_on2).show();
        $(FilterDom.Estrella_on2).css('cursor', 'pointer');
        $(FilterDom.Estrella_on3).show();
        $(FilterDom.Estrella_on3).css('cursor', 'pointer');
        $(FilterDom.Estrella_on4).show();
        $(FilterDom.Estrella_on4).css('cursor', 'pointer');
        $(FilterDom.Estrella_on5).show();
        $(FilterDom.Estrella_on5).css('cursor', 'pointer');
    }

}