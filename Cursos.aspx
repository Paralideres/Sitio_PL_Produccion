<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Cursos.aspx.vb" Inherits="PLWeb4_7.Cursos" %>

<asp:Content ID="Cursos_Head" ContentPlaceHolderID="head" Runat="Server">
    <title>Clases Interactivas | ParaLideres.org</title>
</asp:Content>
<asp:Content ID="Cursos_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Clases Interactivas</a>
</div>


<div id="central_content">
  <div id="cnt_header" class="sections_header">
    <h1>Clases Interactivas On-line y descargar: <span class="s_result_keyword"></span></h1>
  </div>
  <div id="cnt_content">              
         <asp:Table ID="tblResultado" runat="server" CssClass="SearchTbl" TabIndex="7"></asp:Table>
  </div>
</div>

 <!-- Starts Sidebar -->	
<div id="sidebar_box">
  <div class="sb_box 1234" id="sb_ad_box">
      <!-- starts sidebar adbox -->
      <div class="sb_ad"></div>
        <!-- ends sidebar adbox -->
    </div>
</div>
</asp:Content>
<asp:Content ID="Cursos_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
</asp:Content>
<asp:Content ID="Cursos_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>
