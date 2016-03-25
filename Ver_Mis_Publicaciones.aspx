<%@ Page Title="" Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Ver_Mis_Publicaciones.aspx.vb" Inherits="PLWeb4_7.Ver_Mis_Publicaciones" %>

<asp:Content ID="Publicaciones_Head" ContentPlaceHolderID="head" Runat="Server">
<title>Publicaciones | ParaLideres.org</title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">

        function IraSeccion(intId) {
            window.location.href = "Secciones.aspx?Ide=" + intId + "&Pag=1";
        }
        function IraArticulo(id, id_Autor) {
            window.location = './VerArticulo.aspx?Idp=' + id //+ '&Ida=' + id_Autor;
        }
       
    </script>
</asp:Content>
<asp:Content ID="Publicaciones_inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="Publicaciones_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
<div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual" id="hrefTitulo1" runat="server"><label id="lblNombreNivel1" runat="server">Mi Registro</label></a>&raquo;<a class="actual" id="hrefTitulo2" runat="server"> <label id="lblNombreNivel2" runat="server">Mis Publicaciones</label></a>
</div>
<br />
<br />
<br />
    <table id="Table1" style="height:100px">
        <tr>
            <td>
                <p align=center><font size=3><b><label id="LblPublicacionTitulo" runat="server"></label></b></font></p> <br />
                <br />
                <asp:Table ID="tblResultadoPublicacion" runat="server" CssClass="tabs-2" HorizontalAlign="Center"
                    TabIndex="7" width="750px">
                </asp:Table>
                <label id="TagPaginacion" Runat="Server"></label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Publicaciones_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


