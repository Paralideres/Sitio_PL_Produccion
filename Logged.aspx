<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Logged.aspx.vb" Inherits="PLWeb4_7.Logged" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Inicio | ParaLideres.org</title>
        <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">

        function IraSeccion(intId) {
            window.location.href = "Secciones.aspx?Ide=" + intId + "&Pag=1";
        }
       
    </script>
</asp:Content>
<asp:Content ID="Logged_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>
<asp:Content ID="Logged_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
		<div id="breadcrumb" class="clearfix breadcrumbs">
        <a href="Default.aspx">Inicio</a>
    </div>
        <div id="central_content" class="content_trigger_box">
    	<div class="cnt_trgr_title">Estas buscando algo en especial?</div>
        <div class="cnt_trgr_content">
             <ul class="list">
                <li>
                    <ul id="ulColumna1" runat="server">

                    </ul>
                </li>
                <li>
                    <ul id="ulColumna2" runat="server">

                    </ul>
                </li>
                <li>
                    <ul id="ulColumna3" runat="server">
                                 
                    </ul>
                </li>
            </ul>
        </div>
        
        <!-- Starts last_updates widget -->
        <div id="last_updates">
            <div id="tabs">
                <ul>
                    <li><a href="Lista_LoDestacado.aspx">RECOMENDADO PARA TI</a></li>
                </ul>
            </div>
        </div>        
    </div>
    
        <!-- Starts Sidebar -->	
  <div id="sidebar_box">
    <div class="sb_box" id="sb_ad_box">
        <!-- starts sidebar adbox -->
        <div class="sb_ad"></div>
        <!-- ends sidebar adbox -->
      </div>
  </div>

</asp:Content>
<asp:Content ID="Logged_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>


