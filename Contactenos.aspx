<%@ Page Title="" Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Contactenos.aspx.vb" Inherits="PLWeb4_7.Contactenos" %>

<asp:Content ID="Contactenos_Head" ContentPlaceHolderID="head" Runat="Server">
    <title>Colaborar | ParaLideres.org</title>
<script language="javascript" type="text/javascript">

    function validarFormulario() {
        var oEmail = '<%=Email.ClientID%>';
        var oTexto = '<%=TextoComentario.ClientID%>';
        document.all("ErrorEmail").style.visibility = "hidden";
        document.all("ErrorEmailPersonalizado1").style.visibility = "hidden";
        document.all("ErrorTexto").style.visibility = "hidden";


        document.all("ErrorEmail").style.display = 'none';
        document.all("ErrorEmailPersonalizado1").style.display = 'none';
        document.all("ErrorTexto").style.display = 'none';

        if (document.all(oEmail).value == '') {
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
        if (document.all(oTexto).value == '') {
            document.all("ErrorTexto").style.display = 'block';
            document.all("ErrorTexto").style.visibility = "visible";
            document.all(oTexto).focus();
            //alert('1');
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

    
     </script>

</asp:Content>
<asp:Content ID="Contactenos_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

</asp:Content>
<asp:Content ID="Contactenos_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Contáctenos</a>
    </div>
     <div id="central_content">
      <div id="cnt_header">
        <h1>Envia tus comentarios o sugerencias</h1>
      </div>
      <div id="cnt_contentDespuesdeGuardar" runat="Server" visible=false>
            <p>
            <h4>     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     Muchas Gracias!, por escribirnos .</h3>
            </p>
      </div> 
      <div id="cnt_contentAntesdeGuardar" runat="Server" visible=false> 
      
      <div id="cnt_content">
    	

    	
      <p>Es muy importante para nosotros saber tus comentarios y/o sugerencias para así poderte servirte mejor.</p>
      <p>Los campos con ater&iacute;sco(*) son obligatorios.</p>
      
       <div class="reg_fields_box">
  	      <p><label for="Email">*Email:</label> <br/>
          <input type="text" name="Email" id="Email" value=""  runat="server"  size=45 maxlength=100  class="frmInput"  title="Inserta tu dirección de E-mail ( tucorreo@ejemplo.com )" />
          <label id="ErrorEmail"   style="visibility:hidden; color:Red">* Obligatorio</label>
          <label id="ErrorEmailPersonalizado1"   style="visibility:hidden; color:Red">* Direccion Email Incorrecta</label>
          </p>
     
      <p>*Comentarios/Sugerencias: <br/>
      <asp:TextBox ID="TextoComentario" runat="server"  maxlength=256  TextMode="MultiLine" ToolTip="Ingresa los comentarios o sugerencias que quieras compartir con nosotros." Height="150px" Width="275px"></asp:TextBox>
       <label id="ErrorTexto"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>       
         
       		<p><img src="" id="imgCaptchaReg" runat="server" />
		<input type="text" name="txtImagenCaptchaReg" id="txtImagenCaptchaReg"  runat="server"  value=""  class="frmInput" title="Ingresa los numero que aparecen en la imagen" >
	    <label id="LblImagenCaptchaReg"   style="visibility:hidden; color:Red">* Obligatorio</label>
	    <label id="LblImagenCaptchaRerPersonal" runat="server"  style="color:Red"></label>
		</p>
       <asp:Button ID="btnEnviarComentario" runat="server" Text="Enviar"  CssClass ="link_btn_round_md" OnClientClick="return validarFormulario();"  /><br/><br/>
       </div>
      </div>
      
     </div>
     </div>
     <!-- Starts Sidebar -->	
        <div id="sidebar_box">
            	<div class="sb_box" id="sb_ad_box">
             	<!-- starts sidebar adbox -->
            	<div class="sb_ad">
              	<a href="./register.aspx" rel="register" title="Aprende, Crece y Comparte en ParaLideres.org">
                	<img src="http://paralideres.org/assets/ads/banner2_30-10-12.jpg" alt="Participa en una de las mayores comunidades de recursos para l&iacute;deres juveniles, padres y maestros de Am&eacute;rica Latina."  />
                </a>
              </div>
               <!-- ends sidebar adbox -->
      			 </div>
        </div>
</asp:Content>
<asp:Content ID="Contactenos_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>
