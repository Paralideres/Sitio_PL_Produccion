<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="AccountFail.aspx.vb" Inherits="PLWeb4_7.AccountFail" %>

<asp:Content ID="AccountF_Head" ContentPlaceHolderID="head" Runat="Server">
<title>Activar Cuenta | ParaLideres.org</title>
</asp:Content>
<asp:Content ID="AccountF_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="AccountF_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Registro</a>
    </div>
    
    <div id="central_content">
      <div id="cnt_header">
        <h1>Activar tu cuenta</h1>
      </div>
      <div id="cnt_content">
    
      <h3> Estimado(a):&nbsp;  <label id="NombreUsuario" runat="server">  </label> </h3> 	
      <h3 style="color:Red">El tiempo para validar tu correo electrónico ha expirado.</h3>
    	
  
    	<p>Puedes enviar un nuevo link de validación a tu correo electrónico haciendo click 
            abajo!, (Recuerda que tienes 24 horas para hacer tu registro válido y empezar a publicar colaboraciones). </p> <asp:Button ID="btnActivar" runat="server" Text="ReEnviar"  CssClass ="link_btn_round_md"  />
    	<br />
    	<br />
    	<label id="MensajeError" runat="server" visible="false" style="color:Red"></label>
    	
        
    

        
        
       
      </div><!--Ends cnt_content -->
      
    </div>
</asp:Content>
<asp:Content ID="AccountF_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


