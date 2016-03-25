<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Secciones.aspx.vb" Inherits="PLWeb4_7.Secciones" %>
<asp:Content ID="Secciones_Head" ContentPlaceHolderID="head" Runat="Server">
<title id="LblSeccionTituloPrincipal" runat="server"> </title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">

        function IraSeccion(intId) {
            window.location.href = "Secciones.aspx?Ide=" + intId + "&Pag=1";
        }
        function IraArticulo(id, id_Autor) {
            window.location = './VerArticulo.aspx?Idp=' + id //+ '&Ida=' + id_Autor;
        }
       
    </script>

<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-51363103-1', 'paralideres.org');
  ga('require', 'displayfeatures');
  ga('send', 'pageview');
</script>

</asp:Content>
<asp:Content ID="Secciones_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

</asp:Content>
<asp:Content ID="Secciones_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
<div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a><label id="lblSigno1" runat="server" visible="false">&raquo;</label>
    	<a class="actual" id="hrefTitulo1" runat="server" visible="false">Registro</a><label id="lblSigno2" runat="server" visible="false">&raquo;</label>
    	<a class="actual" id="hrefTitulo2" runat="server" visible="false">Registro</a><label id="lblSigno3" runat="server" visible="false">&raquo;</label>
    	<a class="actual" id="hrefTitulo3" runat="server" visible="false">Registro</a><label id="lblSigno4" runat="server" visible="false">&raquo;</label>
    	<a class="actual" id="hrefTitulo4" runat="server" visible="false">Registro</a><label id="lblSigno5" runat="server" visible="false">&raquo;</label>
    	<a class="actual" id="hrefTitulo5" runat="server" visible="false">Registro</a>
</div>
<div id="central_content">
  <div id="cnt_header" class="sections_header">
    <h1 id="LblSeccionTitulo" runat="server"></h1>
    <p id="LblDescripcionSeccion" runat="server"></p>
  </div>
    <div id="cnt_content">              
     <asp:Table ID="tblResultadoArticulosSubSeccion" runat="server" CssClass="SubseccionesTbl" HorizontalAlign="Center"
     TabIndex="7">
     </asp:Table>
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
            	<div class="sb_ad">
              	
              </div>
               <!-- ends sidebar adbox -->
      			 </div>
        </div>  
</asp:Content>
<asp:Content ID="Secciones_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


