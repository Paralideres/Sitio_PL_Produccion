<%@ Page Title=""  Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="UploadFileThank.aspx.vb" Inherits="PLWeb4_7.UploadFileThank" %>


<asp:Content ID="Upload_HeadThank" ContentPlaceHolderID="head" Runat="Server">
<title>Colaborar | ParaLideres.org</title>
</asp:Content>

<asp:Content ID="Upload_InicialThank" ContentPlaceHolderID="ContenidoInicial" Runat="Server" ></asp:Content>
<asp:Content ID="Upload_CentralThank" ContentPlaceHolderID="ContenidoCentral"  Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Colaborar</a>
    </div>
     <div id="central_content">
          <div id="cnt_header">
            <h1>Participa con tu Colaboración</h1>
          </div>
          <div id="cnt_contentDespuesdeGuardar">
              <h3>Gracias, se envió un email a tu correo, avisandote que hemos recibido tu colaboración!</h3>
              <p>en poco tiempo, el equipo de ParaLideres activará tu colaboración. </p>
          </div> 
      </div>
  
</asp:Content>
<asp:Content ID="Upload_FinalThank" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>

