<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="404.aspx.vb" Inherits="_404" %>

<asp:Content ID="ErrorPage404_head" ContentPlaceHolderID="head" Runat="Server">
<title>Error | ParaLideres.org</title>
</asp:Content>
<asp:Content ID="ErrorPage404_Incial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>
    </div>
    
    <div id="central_content">
      <div id="cnt_header">
        <h1>Error!</h1>
      </div>
      <div id="cnt_content">
    	
      <h3>La pagina que estas buscando no ha sido encontrada!</h3>
    	
                
      </div><!--Ends cnt_content -->
      
    </div>
</asp:Content>
<asp:Content ID="ErrorPage404_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
</asp:Content>
<asp:Content ID="ErrorPage404_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>

