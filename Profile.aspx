<%@ Page Language="vb"  MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="Profile.aspx.vb" Inherits="PLWeb4_7.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title id="TituloPerfil" runat="server">Perfil | ParaLideres.org</title>
</asp:Content>

<asp:Content ID="Profile_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">
</asp:Content>

<asp:Content ID="Profile_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
 <div id="breadcrumb" class="clearfix breadcrumbs">
        <a href="Default.aspx">Inicio</a> &raquo; <a class="actual" href="#bio">Perf&iacute;l</a>
    </div>
                
    <div id="central_content" class="clearfix">
                
    <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->    
            <!-- OJO!!!! toda esta seccion es la que cambia, el resto permanece igual -->
            <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx --> 
             
           	<!-- xxxxxxxxxxxxx  Empieza encabezado para todas las paginas id=cnt_header  xxxxxxxxxxx --> 
            <div id="cnt_header" class="clearfix">
            <h1 id="lblNombre" runat="server"></h1>
            </div>
            
            <!-- xxxxxxxxxxxxx  Termina encabezado  xxxxxxxxxxx --> 
            <!-- Start Resource box -->
            <div id="cnt_content" class="profile_box clearfix">
            
                    <div id="p_titlebar" class="left">

                         <div>
                             <img class="p_author_pic" id="ImgAutor" runat="server" src="assets/imgs/authors/author_md.jpg" />                           
                         </div>                            

                         <div class="p_author">
                             <span class="p_author_data">Ubicaci&oacute;n: <label id="LblCiudad" runat="server"></label> - <label id="LblPais" runat="server"></label></span><br />
                             <label id="LblEmail" runat="server" visible="false"></label>
                             <span class="p_author_data">Miembro desde: <label id="LblFecha" runat="server"></label></span><br />
                         </div>                            

                    </div>

                    <div id="sharebar" class="left">
                      
                      <div class="right">
                          <!-- AddThis Button BEGIN -->
                          <div class="social_bar addthis_toolbox addthis_default_style ">
                         <a class="addthis_button_facebook_like" <%="fb:like:send"%>="true"></a>
                          <a class="addthis_button_tweet"></a>
                          <a class="addthis_button_google_plusone" <%="g:plusone:size"%>="medium"></a>
                          </div>
                          <script type="text/javascript">var addthis_config = {"data_track_addressbar":true};</script>
                          <script type="text/javascript" src="http://s7.addthis.com/js/300/addthis_widget.js#pubid=paralideres"></script>
                          <!-- AddThis Button END -->
                     </div>	
                      
                    </div>
                   

                    <div class="p_review left">
                      <h2 class="p_review_title">Rese&ntilde;a</h2>
                      <div class="p_review_txt left" id="LblResena" runat="server">
                      </div>
                    </div>

           </div>  
                <!-- end Resource box -->
                
                <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->    
                <!-- OJO!!!! aca termina la seccion -->
                <!-- xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->         
    
     <!-- Starts last_updates widget -->
        <div id="last_updates">        
           <div id="tabs">
                        <ul>
                            <li><a id="Lst_delAutor" href="Lista_LoUltimo.aspx" runat="server">Del mismo Autor</a></li>
                        </ul>
                    </div>         
        </div>         
                
    </div>
		<!-- ends central_content-->
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
<asp:Content ID="Profile_Final" ContentPlaceHolderID="ContenidoFinal" runat="server">
</asp:Content>

