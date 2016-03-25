<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Tag.aspx.vb" Inherits="PLWeb4_7.Tag" %>

<asp:Content ID="Tag_Head" ContentPlaceHolderID="head" Runat="Server">
<title>Etiquetas | ParaLideres.org</title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">


            function IraArticulo(id, id_Autor) {
                window.location = './VerArticulo.aspx?Idp=' + id //+ '&Ida=' + id_Autor;
            }
            
    </script>
</asp:Content>
<asp:Content ID="Tag_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

   
</asp:Content>
<asp:Content ID="Tag_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
<div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Etiquetas</a>
</div>

<div id="central_content">
  <div id="cnt_header" class="sections_header">
    <h1 id="LblEtiquetaTitulo" runat="server">Art&#237;culos Marcado con Etiqueta : </h1>
  </div>
  <div id="cnt_content">              
     <asp:Table ID="tblResultado" runat="server" CssClass="TagsTbl" HorizontalAlign="Center" TabIndex="7">
    </asp:Table>
    <label id="TagPaginacion" Runat="Server"></label>
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
<asp:Content ID="Tag_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


