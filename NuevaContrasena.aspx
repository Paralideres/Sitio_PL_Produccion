<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="NuevaContrasena.aspx.vb" Inherits="PLWeb4_7.NuevaContrasena" %>

<asp:Content ID="NuevaContrasena_Head" ContentPlaceHolderID="head" Runat="Server">
<title>Cambiar contraseña | ParaLideres.org</title>
<script language="javascript" type="text/javascript">

     function validarFormulario() {
          var oClave = '<%=Clave.ClientID%>';
          document.all("ErrorClave").style.visibility = "hidden";
          document.all("ErrorClave").style.display = 'none';

        if (document.all(oClave).value == '') {
             document.all("ErrorClave").style.display = 'block';
             document.all("ErrorClave").style.visibility = "visible";
             document.all(oClave).focus();
             //alert('3');
             return false;
         }
      }
     </script>
</asp:Content>
<asp:Content ID="NuevaContrasena_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="NuevaContrasena_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual"><label id="NombreTipoEnvio" runat="server">Restablecer Contraseña</label></a>
    </div>
    <div id="central_content">
      <div id="cnt_content">
    	 <div id="cnt_contentGuardar" runat="Server" visible=false>
          <h3><label id="MensajedelEnvio" runat="server"></label>!</h3>
        </div> 
        <div id="cnt_contentMail" runat="Server" visible=true>
          
          <div class="reg_fields_box">
              <h2>Restablecer Contraseña</h2>
               <p>Ingresa tu nueva contraseña.</p>
               <p><label>*Contraseña:(maximo caracteres 20)</label> <br />
               <asp:TextBox ID="Clave"  runat="server" size=45 maxlength=20 class="frmInput" TextMode=Password ></asp:TextBox>
               <label id="ErrorClave"   style="visibility:hidden; color:Red">* Obligatorio</label>
               </p>
              <asp:Button ID="btnRegistro" runat="server" Text="Cambiar"  CssClass ="link_btn_round_md" OnClientClick="return validarFormulario();" /><br/><br/>
          </div><!--Ends cnt_content -->
      </div>
    </div>
  </div>
</asp:Content>
<asp:Content ID="NuevaContrasena_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


