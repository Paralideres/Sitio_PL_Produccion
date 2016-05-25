<%@ Page Language="vb" MasterPageFile ="~/Principal.master" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="PLWeb4_7._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Inicio | ParaLideres.org</title>
</asp:Content>
<asp:Content ID="Inicio_Inicial" ContentPlaceHolderID ="ContenidoInicial" runat="server">

</asp:Content>
<asp:Content ID="Inicio_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
  <div id="central_content">
    <div class="main_announcer_box">
      <div class="home-slider">
        <ul class="bxslider">
          <li>
            <a href="http://paralideres.org/UploadFile.aspx">
              <img src="/assets/imgs/slider/compartir.jpg" />
            </a>
          </li>
          <li>
            <a href="http://paralideres.org/Secciones.aspx?Ide=29&Pag=1">
              <img src="/assets/imgs/slider/paleta_recursos.jpg" />
            </a>
          </li>
          <li>
            <a target="_blank" href="http://www.youtube.com/watch?v=B2P3anFyNNg&feature=share&list=PLjcT2vLdd9Q2i__NJRMxdnWHncgmXVgwX">
              <img src="/assets/imgs/slider/slider-tips1.png" />
            </a>
          </li>
          <li>
            <a href="http://www.paralideres.org/VerArticulo.aspx?Idp=6509">
              <img src="/assets/imgs/slider/slider_elcamino2.png" />
            </a>
          </li>
        </ul>
      </div>
    </div>
    <!-- Starts last_updates widget -->
    <div id="last_updates">
      <div id="tabs">
        <ul>
          <li><a href="Lista_LoUltimo.aspx">Lo Último</a></li>
          <li><a href="Lista_LoDestacado.aspx" >Destacado</a></li>
          <li><a href="Lista_LoPopular.aspx">Popular</a></li>
        </ul>
      </div>
    </div>
  </div>
</asp:Content>
<asp:Content ID="Inicio_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">

<div id="extra-content">
  <!-- Starts Stream's Box -->
  <div id="news_stream_box" class="clearfix">
    <div class="nws_header">
      <h1>BLOG STREAM</h1>
    </div>
    <div class="nws_option_selector">
      <a href="http://feeds.feedburner.com/Paralideres/BlogColaborativo"
        target="_blank" class="nws_suscribe">SUSCR&Iacute;BETE</a>
      <a class="nws_more" href="http://blog.paralideres.org" target="_blank"
        title="Ir al Blog Colaborativo">VER M&Aacute;S</a>
    </div>
    <div id="blog_stream" class="nws_content">
    </div>
  </div>
  <!-- Ends NewsStreaBox -->
  <!-- Starts Author's Widget box -->
  <div id="content_stream_box" class="clearfix">
    <div class="cnt_header">
    <h1>Redes Sociales</h1>
    </div>
    <div class="cnt_option_selector">
      <a class="cnt_more" href="#"></a>
    </div>
    <div class="cnt_content">
      <ul>
        <!-- stream -->
        <li>
          <div class="cnt_stream">
            <script src="https://apis.google.com/js/platform.js"></script>
            <div class="g-ytsubscribe" data-channel="ParaLideres" data-layout="full" data-count="default"></div>
            <iframe
              allowfullscreen
              frameborder="0"
              height="170"
              src="https://www.youtube.com/embed/videoseries?list=PLjcT2vLdd9Q3qdPFhMAi7F6Cos0TVpWlm"
              width="295"/>
            </iframe>
          </div>
          <div class="cnt_stream">
            <div class='likeboxwrap'>
              <iframe
                src="//www.facebook.com/plugins/likebox.php?href=https://www.facebook.com/paralideres?fref=ts;width=260&amp;height=260&amp;show_faces=true&amp;colorscheme=light&amp;stream=false&amp;border_color&amp;header=false&amp;appId=137352931037"
                scrolling="no"
                frameborder="0"
                style="border:none; overflow:hidden; width:300px; height:220px;"
                allowTransparency="true">
              </iframe>
            </div>
            <style type='text/css'>
              div.likeboxwrap {
                width:288px; /* Quitar 2px al ancho del gadget */
                height:210px; /* Quitar 25px al alto del gadget */
                margin-top: 10px;
                background-color: transparent; /* Color de fondo del gadget */
                overflow: hidden;
              }
              div.likeboxwrap iframe { margin:-1px; }
            </style>
          </div>
        </li>
        <!-- end stream -->
      </ul>
    </div>
  </div>
  <!-- ends Author's Widget Box -->
</div>


</asp:Content>
