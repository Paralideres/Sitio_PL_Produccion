<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="PLWeb4_7.Register" %>


<asp:Content ID="Register1_head" ContentPlaceHolderID="head" Runat="Server">
<title>Registro | ParaLideres.org</title>
    <script language="javascript" type="text/javascript">
// <!CDATA[


        function validarFormulario() {


            var oNombre = '<%=FirstName.ClientID%>';
            var oApellidos = '<%=LastName.ClientID%>';
            var oClave = '<%=Clave.ClientID%>';
            var oReClave = '<%=ReClave.ClientID%>';
            var oEmail = '<%=Email.ClientID%>';
            var oEmail2 = '<%=Email2.ClientID%>';
            var oCountry = '<%=Country.ClientID%>';
            var oFechaNAC = '<%=strFechaNAC.ClientID%>';

            var indice = document.all(oCountry).selectedIndex;
            var valor = document.all(oCountry).options[indice].value; 
            
            var oCity = '<%=City.ClientID%>';

            document.all("ErrorNombre").style.visibility = "hidden";
            document.all("ErrorApellido").style.visibility = "hidden";
            document.all("ErrorFecha").style.visibility = "hidden";
            document.all("ErrorClave").style.visibility = "hidden";
            document.all("ErrorReClave").style.visibility = "hidden";
            document.all("ErrorReClavePersonalizado").style.visibility = "hidden";
            document.all("ErrorEmail").style.visibility = "hidden";
            document.all("ErrorEmailPersonalizado1").style.visibility = "hidden";
            document.all("ErrorEmail2").style.visibility = "hidden";
            document.all("ErrorEmail2Personalizado").style.visibility = "hidden";
            document.all("ErrorEmail2Personalizado2").style.visibility = "hidden";
            document.all("ErrorCountry").style.visibility = "hidden";
            document.all("ErrorCity").style.visibility = "hidden";

            document.all("ErrorNombre").style.display = 'none';
            document.all("ErrorApellido").style.display = 'none';
            document.all("ErrorFecha").style.display = 'none';
            document.all("ErrorClave").style.display = 'none';
            document.all("ErrorReClave").style.display = 'none';
            document.all("ErrorReClavePersonalizado").style.display = 'none';
            document.all("ErrorEmail").style.display = 'none';
            document.all("ErrorEmailPersonalizado1").style.display = 'none';
            document.all("ErrorEmail2").style.display = 'none';
            document.all("ErrorEmail2Personalizado").style.display = 'none';
            document.all("ErrorEmail2Personalizado2").style.display = 'none';  
            document.all("ErrorCountry").style.display = 'none';
            document.all("ErrorCity").style.display = 'none';
 
            


            if (document.all(oNombre).value == '') {
                document.all("ErrorNombre").style.display = 'block';
                document.all("ErrorNombre").style.visibility = "visible";
                document.all(oNombre).focus();
                //alert('1');
                return false;
            }
            else if (document.all(oApellidos).value == '') {
            document.all("ErrorApellido").style.display = 'block';            
                document.all("ErrorApellido").style.visibility = "visible";
                document.all(oApellidos).focus();
                //alert('2');
                return false;
            }
            else if (document.all(oClave).value == '') {
            document.all("ErrorClave").style.display = 'block';
                document.all("ErrorClave").style.visibility = "visible";
                document.all(oClave).focus();
                //alert('3');
                return false;
            }
            else if (document.all(oFechaNAC).value == '') {
                document.all("ErrorFecha").style.display = 'block';
                document.all("ErrorFecha").style.visibility = "visible";
                document.all(oFechaNAC).focus();
                return false;
            }
            else if (document.all(oReClave).value == '') {
            document.all("ErrorReClave").style.display = 'block';                
                document.all("ErrorReClave").style.visibility = "visible";
                document.all(oReClave).focus();
                //alert('42');
                return false;
            }
            else if (document.all(oClave).value != document.all(oReClave).value) {
            document.all("ErrorReClavePersonalizado").style.display = 'block';            
                document.all("ErrorReClavePersonalizado").style.visibility = "visible";
                document.all(oReClave).focus();
                //alert('5');
                return false;
            }
            else if (document.all(oEmail).value == '') {
            document.all("ErrorEmail").style.display = 'block';            
                document.all("ErrorEmail").style.visibility = "visible";
                document.all(oEmail).focus();
                //alert('6');
                return false;
            }
            else if (validarEmail(document.all(oEmail).value) == false) {
            document.all("ErrorEmailPersonalizado1").style.display = 'block';            
                document.all("ErrorEmailPersonalizado1").style.visibility = "visible";
                document.all(oEmail).focus();
                //alert('6.1');
                return false;
            }
            else if (document.all(oEmail2).value == '') {
            document.all("ErrorEmail2").style.display = 'block';            
                document.all("ErrorEmail2").style.visibility = "visible";
                document.all(oEmail2).focus();
                //alert('7');
                return false;
            }
            else if (validarEmail(document.all(oEmail2).value) == false) {
            document.all("ErrorEmail2Personalizado2").style.display = 'block';            
                document.all("ErrorEmail2Personalizado2").style.visibility = "visible";
                document.all(oEmail2).focus();
                //alert('7.1');
                return false;
            }
            else if (document.all(oEmail).value != document.all(oEmail2).value) {
            document.all("ErrorEmail2Personalizado").style.display = 'block';            
                document.all("ErrorEmail2Personalizado").style.visibility = "visible";
                document.all(oEmail2).focus();
                //alert('8');
                return false;

            }


            else if (valor == '') {
            document.all("ErrorCountry").style.display = 'block';            
                document.all("ErrorCountry").style.visibility = "visible";
                document.all(oCountry).focus();
                //alert('9');
                //alert(indice);
                //alert(valor);
                return false;
            }
            else if (document.all(oCity).value == '') {
            document.all("ErrorCity").style.display = 'block';            
                document.all("ErrorCity").style.visibility = "visible";
                document.all(oCity).focus();
                //alert('10');
                return false;
            }

   
        }


        function validarEmail(valor) {
            //alert(valor);
            if (/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/.test(valor)) {
                return (true)
            }
            else {
                return (false);
            }
        }

        function ValidarFecha(fecha) {
            var dia_nac;
            var mes_nac;
            var anno_nac;
            var valorFecha = fecha;
            var array_fecha = valorFecha.split("/")

            //Si el array no tiene tres partes, intentar con "-"
            if (array_fecha.length != 3)
                array_fecha = valorFecha.split("-")

            //Si el array no tiene tres partes, la fecha es incorrecta
            if (array_fecha.length == 3) {
                //Comprueba que los ano, mes, dia son correctos
                var anno_nac = 0;
                var mes_nac = 0;
                var dia_nac = 0;
                anno_nac = array_fecha[2];
                mes_nac = array_fecha[1];
                dia_nac = array_fecha[0];
                // Si mes_nac tiene 0 a la izquierda, omitirlo                       
                if (mes_nac.substring(0, 1) == 0)
                    mes_nac = mes_nac.substring(1, 2);
                // Si dia_nac tiene 0 a la izquierda, omitirlo                       
                if (dia_nac.substring(0, 1) == 0)
                    dia_nac = dia_nac.substring(1, 2);
                // Asegurarse que sean numéricos:
                anno_nac = Math.round(anno_nac);
                mes_nac = Math.round(mes_nac);
                dia_nac = Math.round(dia_nac);

                // Fecha Nacimiento                                               
                var mydate = new Date();
                var anno_act = 0;
                var mes_act = 0;
                var dia_act = 0;

                var anno_act = mydate.getYear();
                var mes_act = mydate.getMonth();
                mes_act++; // Comienza en cero, por eso se le suma 1.
                var dia_act = mydate.getDate();


                // Asegurarse que sean numéricos:
                anno_nac = Math.round(anno_nac);
                mes_nac = Math.round(mes_nac);
                dia_nac = Math.round(dia_nac);
                anno_act = Math.round(anno_act);
                mes_act = Math.round(mes_act);
                dia_act = Math.round(dia_act);


                // En caso de que los valores no sean numericos
                if ((isNaN(mes_nac)) || (isNaN(anno_nac)) || (isNaN(dia_nac)))
                    return false;
                if (anno_nac < 1800)
                    return false;
                if ((mes_nac < 1) || (mes_nac > 12))
                    return false;
                if ((dia_nac < 1) || (dia_nac > 31))
                    return false;
                if ((mes_nac == 2) && (dia_nac > 29))
                    return false;


                // Si la fecha de nacimiento es mayor a la actual 
                if (anno_nac > anno_act) {
                    return false;
                }
                else {
                    if (anno_nac >= anno_act) {
                        if (mes_nac >= mes_act) {
                            if (dia_nac > dia_act) {
                                return false;
                            }
                        }
                    }
                }

                if ((anno_nac == anno_act) && (mes_nac > mes_act)) {
                    return false;
                }
            }

            // Si la fecha esta OK    
            return true;
        }

        $(function() {
            $("#ctl00_ContenidoCentral_strFechaNAC").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
                monthNamesShort: ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"]
            });

        });


// ]]>
    </script>
</asp:Content>
<asp:Content ID="Register1_inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

</asp:Content>
<asp:Content ID="Register1_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Registro</a>
    </div>
    
    <div id="central_content">
      <div id="cnt_header">
        <h1>Registro</h1>
      </div>
      <div id="cnt_content">
    	
      <h3>Bienvenido, y gracias por tu interés en la juventud!</h3>
    	
      <p>Como usuario registrado podras publicar y bajar materiales, además podrás tener acceso a otras secciones de ParaLíderes como Directorios y Foros.</p>
      <p>Los campos con ater&iacute;sco(*) son obligatorios.</p>
      
      <div class="reg_fields_box">
      <h2>Tus datos</h2>
      <p><label>*Nombre(s): <br/><input type="text" name="FirstName" id="FirstName" runat="server" value="" size=45 maxlength=50 title="Inserta tu nombre(s) (Luis, Luis Miguel, Maria, Maria Elena, Ma. Elena, etc.)" class="frmInput"></label>
       <label id="ErrorNombre"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      
      
    	
      <p>*Apellido(s): <br/>
      <input type="text" name="LastName" id="LastName"  runat="server"  value="" size=45 maxlength=50  class="frmInput" title="Inserta tu apellido(s) (León, León Gonzalez, etc.)">
      <label id="ErrorApellido"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      <p><label>*Fecha de Nacimiento:</label> <br />
      <input id="strFechaNAC" name="strFechaNAC" type="text" size="45"  maxlength=10 runat="server" class="frmInput" title="Ingresa tu Fecha de Nacimiento"/>
      <img alt="Calendario" id="ImgstrFechaNAC" width="20" height="20" onclick="calendario(ctl00$ContenidoCentral$strFechaNAC)" src="./Editor/images/calendar.gif" name="ImgstrFechaNAC" runat="server" visible="false" onmouseover="this.style.cursor='hand'"/>&nbsp;
      <label id="ErrorFecha"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      
      <p><label>*Contraseña:(maximo caracteres 10)</label> <br />
      <input type=password name="Clave" id="Clave" runat="server" value="" size=45 maxlength=20 class="frmInput" />
      <label id="ErrorClave"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      <p><label>*Repite tu Contraseña:</label> <br />
      <input type=password name="ReClave id="Reclave" runat="server" value="" size=45 maxlength=20 class="frmInput"/>   
      <label id="ErrorReClave"   style="visibility:hidden; color:Red">* Obligatorio</label>
      <label id="ErrorReClavePersonalizado"   style="visibility:hidden; color:Red">* Contraseña distintos</label>
      </p>     
            
	  <p><label for="Email">*Email:</label> <br/>
      <input type="text" name="Email" id="Email" value=""  runat="server"  size=45 maxlength=100  class="frmInput"  title="Inserta tu dirección de E-mail ( tucorreo@ejemplo.com )" />
      <label id="ErrorEmail"   style="visibility:hidden; color:Red">* Obligatorio</label>
      <label id="ErrorEmailPersonalizado1"   style="visibility:hidden; color:Red">* Direccion Email Incorrecta</label>
      </p>
			
      <p><label for="Email2">*Verifica Email:</label><br/>
	  <input type="text" name="Email2" id="Email2"  runat="server"  value="" size=45 maxlength=100 class="frmInput" title="Inserta nuevamente tu dirección de E-mail para verificar que no hay errores" >
	  <label id="ErrorEmail2"   style="visibility:hidden; color:Red">* Obligatorio</label>
	  <label id="ErrorEmail2Personalizado"   style="visibility:hidden; color:Red">* Email distintos</label>
	  <label id="ErrorEmail2Personalizado2"   style="visibility:hidden; color:Red">* Direccion Email Incorrecta</label>
      </p>
      
      </div>
      
      <div class="reg_fields_box">
      <h2>Tu Ubicaci&oacute;n</h2>
      <p><label for="Country">*País:</label><br/>
			<asp:DropDownList ID="Country" style="font-size:x-small" runat="server" Width="200px" ></asp:DropDownList>
			<label id="ErrorCountry"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      
      <p><label for="State">Estado:</label><br/>
			<input type="text" name="State" id="State" value=""  runat="server"  size=45 maxlength=100  class="frmInput" title="Escribe el estado/provincia donde vives">
      </p>
      
      <p><label for="City">*Ciudad:</label> <br/>
            <input type="text" name="City" id="City" value="" runat="server" size=45 maxlength=50 class="frmInput" title="La ciudad donde vives">
             <label id="ErrorCity"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
			</div>
      
      <div class="reg_fields_box">
			<p><label for="ShowInfo">¿Quieres publicar tu Perfíl en el Directorio?:</label><br/>
        <asp:DropDownList ID="ShowInfo" runat="server" >
            <asp:ListItem Value="0">No</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
        </asp:DropDownList>
			</p>
      
      <p><label for="ReceiveEmails">¿Deseas Recibir Noticias de ParaLíderes?:</label><br/>
        <asp:DropDownList ID="ReceiveEmails" runat="server" >
            <asp:ListItem Value="0">No</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
        </asp:DropDownList>
			</p>
		
		<p>
	
		<table>
		<tr>
		    <td>
		        <img src="" id="imgCaptchaReg" runat="server" />
		    </td>
		</tr>
		<tr>
		    <td>
		        <input type="text" name="txtImagenCaptchaReg" id="txtImagenCaptchaReg"  runat="server"  value=""  class="frmInput" title="Ingresa el Código(letras y/o numeros) que aparece en la imagen" >
	    
		    </td>
		 </tr>
		 <tr>
		    <td>
		        <label id="LblImagenCaptchaReg"   style="visibility:hidden; color:Red">* Obligatorio</label>
	        </td>
	     </tr> 
	     <tr>
	        <td>  
	             <label id="LblImagenCaptchaRerPersonal" runat="server"  style="color:Red"></label>
		    </td>
		</tr>
		</table>
		
	    
		</p>
	    </div>
      
          <asp:Button ID="btnRegistro" runat="server" Text="Registrarme"  CssClass ="link_btn_round_md" OnClientClick="return validarFormulario();" /><br/><br/>
			
      <p class="meta_notes">
      Al hacer clic en Registrame, muestras tu conformidad con nuestras Condiciones y aceptas haber leído nuestra Política de uso de datos.
      </p>
			<input type="hidden" name="reg_user_id" value="0">
      </div><!--Ends cnt_content -->
      
    </div>
</asp:Content>
<asp:Content ID="Register_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>

