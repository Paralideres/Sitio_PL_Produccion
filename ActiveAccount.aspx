<%@ Page Title="" Language="vb"  MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="ActiveAccount.aspx.vb" Inherits="PLWeb4_7.ActiveAccount" %>


<asp:Content ID="Active_Head" ContentPlaceHolderID="head" Runat="Server">
<title>Activar Cuenta | ParaLideres.org</title>
</asp:Content>
<asp:Content ID="Active_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="Active_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Registro</a>
    </div>
    
    <div id="central_content">
      <div id="cnt_header">
        <h1>Activar tu cuenta</h1>
      </div>
      <div id="cnt_content">
    	
      <h3>Bienvenido <label id="NombreUsuario" runat="server"> </label>, y gracias por tu interés en la juventud!</h3>
    	
  
    	<p>Aqui podras Activar tu cuenta! </p> <br /><label id="MensajeError" runat="server" visible="false" style="color:Red"></label>
        <asp:Button ID="btnActivar" runat="server" Text="Activar"  CssClass ="link_btn_round_md"  /><br/><br/>
    
        <br />
        <div id="CuentaActivada" runat="server" visible="false">
            <h3>Felicidades, tu cuenta ya esta Activada!</h3>
        </div>
        
        
       
      </div><!--Ends cnt_content -->
      
    </div>
</asp:Content>
<asp:Content ID="Active_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


