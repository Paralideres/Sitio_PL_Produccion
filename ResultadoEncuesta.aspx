<%@ Page Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="ResultadoEncuesta.aspx.vb" Inherits="PLWeb4_7.ResultadoEncuesta" %>

<asp:Content ID="ResultadoEnc_head" ContentPlaceHolderID="head" Runat="Server">
<title>Resultado | ParaLideres.org</title>
    <script type="text/javascript"  language="javascript" id="clientEventHandlersJS">
        function IraListaEncuestas() {
            window.location.href = "ListadoEncuestas.aspx";
        }        
       
    </script>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <link href="css/PopUp.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="./css/jqpagination.css" />


</asp:Content>
<asp:Content ID="ResultadoEnc_inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
   <%-- <script src="./scripts/jquery-1.7.2.min.js" type="text/javascript"></script>--%>
	<script src="./scripts/jquery.jqpagination.js" type="text/javascript"></script>
    <script src="./scripts/ListadoEncuestas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="ResultadoEnc_central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
<div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Resultado Encuesta</a>
</div>
<div id="central_content" class="clearfix">
                
  <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->    
  <!-- OJO!!!! toda esta seccion es la que cambia, el resto permanece igual -->
  <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx --> 
  <!-- xxxxxxxxxxxxx  Empieza encabezado para todas las paginas id=cnt_header  xxxxxxxxxxx --> 
  <div id="cnt_header" class="clearfix">
    <h1>Resultados de la Encuesta</h1>
  </div>
  <!-- xxxxxxxxxxxxx  Termina encabezado  xxxxxxxxxxx --> 
  <!-- Start Resource box -->
  <div id="cnt_content" class="resource_box clearfix">

  <label id="lblResultado" runat="server"> </label>
  
  </div>
  
  <div>
    <!--input id="btnVerMas" type="button" value="Ver Mas..." onclick="IraListaEncuestas()"  onmouseover="this.style.cursor='pointer'" class="link_btn_round_md sv_votar"   />-->
      <table class="tablas" width="70%">
      <tr>
            <td colspan="3">
                 <table id="tbResultadoBusqueda" class="grid" width="100%" >
                    <thead>
                        <tr>
                            <th >
                                Encuesta Anteriores
                            </th>
                            <th> Fecha </th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>           
            </td>
        </tr>
        <tr align="center">
            <td colspan="3" align="center">
               <div class="pagination" >
                <a href="#" class="first" data-action="first">&laquo;</a>
                <a href="#" class="previous" data-action="previous">&lsaquo;</a>
                <input type="text" readonly="readonly" data-max-page="40" />
                <a href="#" class="next" data-action="next">&rsaquo;</a>
                <a href="#" class="last" data-action="last">&raquo;</a>
              </div>
            </td>
        </tr>
      </table>
  </div>

  <!-- end Resource box -->
  
  <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->    
  <!-- OJO!!!! aca termina la seccion -->
  <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx --> 
      

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

<div id="popup" style="display:none">
    <div class="content-popup">
        <div class="close">
            <a href="#" id="close">
                <img src="images/close.png"/>
            </a>
        </div>
        <div id="MuestraGrafico">
        </div>
    </div>
  </div>

    
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                </asp:ScriptManager>



</asp:Content>
<asp:Content ID="ResultadoEnc_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>



