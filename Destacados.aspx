<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Destacados.aspx.vb" Inherits="PLWeb4_7.Destacados" %>

<asp:Content ID="Destacados_head" ContentPlaceHolderID="head" Runat="Server">
<title id="LblDestacadoTituloPrincipal" runat="server"> </title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">

         function IraArticulo(id, id_Autor) {
            window.location = './VerArticulo.aspx?Idp=' + id //+ '&Ida=' + id_Autor;
        }
       
    </script>
</asp:Content>
<asp:Content ID="Destacados_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="Destacados_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	    <a href="Default.aspx">Inicio</a><label id="lblSigno1" runat="server" visible="false">&raquo;</label>
    	    <a class="actual" id="hrefTitulo1" runat="server" visible="false">Registro</a><label id="lblSigno2" runat="server" visible="false">&raquo;</label>
    	    <a class="actual" id="hrefTitulo2" runat="server" visible="false">Registro</a><label id="lblSigno3" runat="server" visible="false">&raquo;</label>
    	    <a class="actual" id="hrefTitulo3" runat="server" visible="false">Registro</a><label id="lblSigno4" runat="server" visible="false">&raquo;</label>
    	    <a class="actual" id="hrefTitulo4" runat="server" visible="false">Registro</a><label id="lblSigno5" runat="server" visible="false">&raquo;</label>
    	    <a class="actual" id="hrefTitulo5" runat="server" visible="false">Registro</a>
    </div>
<div id="central_content">
    <div id="cnt_content">              
        <asp:Table ID="tblResultadoArticulos" runat="server" CssClass="ArticlesTbl" HorizontalAlign="Center"
        TabIndex="7">
        </asp:Table>
        <label id="TagPaginacion" Runat="Server"></label>
     </div>
  </div>
<!-- Starts Sidebar -->	
        <div id="sidebar_box">
            	<div class="sb_box" id="sb_ad_box">
             	<!-- starts sidebar adbox -->
            	
               <!-- ends sidebar adbox -->
      			 </div>
        </div>  


</asp:Content>
<asp:Content ID="Destacados_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>



