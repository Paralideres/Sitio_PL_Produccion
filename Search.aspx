<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Search.aspx.vb" Inherits="PLWeb4_7.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Buscar | ParaLideres.org</title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">
        function IraPerfil(id_Autor) {

            window.location='./Profile.aspx?Id_Autor='+id_Autor;
//            window.open(
//            Objeto = showModalDialog("./BuscadorGeneralReversar.aspx?" + args, null, "scroll:No;status:no;center:yes;help:no;minimize:no;maximize:no;border:no;statusbar:no;dialogWidth:500px;dialogHeight:180px");
//            ValidarDatos();
        }

         function IraSeccion(intId) {
            window.location.href = "Secciones.aspx?Ide=" + intId + "&Pag=1" ;
        }

        function IraArticulo(id, id_Autor) {
            window.location = './VerArticulo.aspx?Idp=' + id //+ '&Ida=' + id_Autor;
        }
       
    </script>
</asp:Content>
<asp:Content ID="Busqueda_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
       <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Buscar</a>
</div>


<div id="central_content">
  <div id="cnt_header" class="sections_header">
    <h1>Resultados de B&uacute;squeda para: <span class="s_result_keyword"><label id="LblPalabraBuscar" runat="server"></label></span></h1>
  </div>
  <div id="cnt_content">              
     <asp:Table ID="tblResultado" runat="server" CssClass="SearchTbl" TabIndex="7"></asp:Table>
    <label id="TagPaginacion" Runat="Server"></label>
  </div>
  <label id="LblMensaje" Runat="Server" style="color:Red; font-size:small" ></label>
</div>

 <!-- Starts Sidebar -->	
<div id="sidebar_box">
  <div class="sb_box 1234" id="sb_ad_box">
      <!-- starts sidebar adbox -->
      <div class="sb_ad"></div>
        <!-- ends sidebar adbox -->
    </div>
</div>
<!-- ends SideBar -->

<%--<br />
<br />
<br />
<div id="cnt_header" class="s_result_actual">
	<h1>Resultados de B&uacute;squeda para: <span class="s_result_keyword"><label id="LblPalabraBuscar" runat="server"></label></span></h1>
</div>

            <div id="cnt_content" class="s_result_box"> 
            	<div id="s_options_box" class="clearfix">
            	    <p class="left">
            	       
            	        <asp:Table ID="tblResultado" runat="server" CssClass="tabs-2" TabIndex="7" width="750px">
                        </asp:Table>
            	    </p>
                </div>

                <div id="s_options_box" class="clearfix">
               
                
                    <p id="s_pages" class="right">
                        <label id="TagPaginacion" Runat="Server"></label>
                     </p>
                </div>
            </div>--%>
 <%--<a href="#mejor_puntuadas" class="s_actual">Mejor Puntuadas</a> | <a href="#mas_relevante">Más Relevante</a> | <a href="#mas_reciente">Más Reciente</a></p><p id="s_advanced" class="right"><a href="#busqueda_avanzada">Búsqueda Avanzada</a>--%>
 <%--<p id="s_advanced" class="left"><a href="#busqueda_avanzada">Búsqueda Avanzada</a></p>--%>

</asp:Content>
<asp:Content ID="Busqueda_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
</asp:Content>
<asp:Content ID="Busqueda_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


