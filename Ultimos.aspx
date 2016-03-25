<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.master" CodeBehind="Ultimos.aspx.vb" Inherits="PLWeb4_7.Ultimos" %>

<asp:Content ID="Ultimos_head" ContentPlaceHolderID="head" Runat="Server">
<title id="LblUltimosTituloPrincipal" runat="server"> </title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">

         function IraArticulo(id, id_Autor) {
            window.location = './VerArticulo.aspx?Idp=' + id //+ '&Ida=' + id_Autor;
        }

    </script>
</asp:Content>
<asp:Content ID="Ultimos_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

</asp:Content>
<asp:Content ID="Ultimos_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
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
</asp:Content>
<asp:Content ID="Ultimos_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>

