<%@ Page Title="" Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="EnvioEmail.aspx.vb" Inherits="PLWeb4_7.EnvioEmail" %>


    <asp:Content ID="EnvioEmail_head" ContentPlaceHolderID="head" Runat="Server">
<title>Recuperar contraseña | ParaLideres.org</title>
    <script language="javascript" type="text/javascript">

     function validarFormulario() 
     {
         var oEmail = '<%=Email.ClientID%>';

         document.all("ErrorEmail").style.visibility = "hidden";
         document.all("ErrorEmailPersonalizado").style.visibility = "hidden";
         document.all("ErrorEmail").style.display = 'none';
         document.all("ErrorEmailPersonalizado").style.display = 'none';

        if (document.all(oEmail).value == '') {
             document.all("ErrorEmail").style.display = 'block';
             document.all("ErrorEmail").style.visibility = "visible";
             document.all(oEmail).focus();
             return false;
         }
         else if (validarEmail(document.all(oEmail).value) == false) {
             document.all("ErrorEmailPersonalizado").style.display = 'block';
             document.all("ErrorEmailPersonalizado").style.visibility = "visible";
             document.all(oEmail).focus();
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
<asp:Content ID="EnvioEmail_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="EnvioEmail_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual"><label id="NombreTipoEnvio" runat="server">Olvido Contraseña</label></a>
    </div>
    <div id="central_content">
      <div id="cnt_content">
    	 <div id="cnt_contentGuardar" runat="Server" visible=false>
          <h3><label id="MensajedelEnvio" runat="server"></label>!</h3>
        </div> 
        <div id="cnt_contentMail" runat="Server" visible=true>
          
          <div class="reg_fields_box">
              <h2>Recuperar Contraseña</h2>
               <p>Ingresa tu Email y te enviaremos un link donde puedes restablecer tu contraseña.</p>
	          <p><label for="Email">*Email:</label> <br/>
              <input type="text" name="Email" id="Email" value=""  runat="server"  size=45 maxlength=100  class="frmInput"  title="Inserta tu dirección de E-mail ( tucorreo@ejemplo.com )" />
              <label id="ErrorEmail"   style="visibility:hidden; color:Red">* Obligatorio</label>
              <label id="ErrorEmailPersonalizado"   style="visibility:hidden; color:Red">* Direccion Email Incorrecta</label>
              </p>
              <asp:Button ID="btnRegistro" runat="server" Text="Enviar"  CssClass ="link_btn_round_md" OnClientClick="return validarFormulario();" /><br/><br/>
          </div><!--Ends cnt_content -->
      </div>
    </div>
  </div>
</asp:Content>
<asp:Content ID="EnvioEmail_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>

