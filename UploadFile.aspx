
<%@ Page UICulture="es" Culture="es-ES" Title=""  Language="vb" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeBehind="UploadFile.aspx.vb" Inherits="PLWeb4_7.UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Colaborar | ParaLideres.org</title>
<script language="javascript" type="text/javascript">

    function validarFormulario() {
        var oTitulo = '<%=Titulo.ClientID%>';
        var oResumen = '<%=Resumen.ClientID%>';
        var oTextoColaboracion = '<%=TextoColaboracion.ClientID%>';
        var oFile = '<%=File_U.ClientID%>';
        var oPublicacion = '<%=Publicacion.ClientID%>';
        var indice = document.all(oPublicacion).selectedIndex;
        var valor = document.all(oPublicacion).options[indice].value;

        document.all("ErrorTitulo").style.visibility = "hidden";
        document.all("ErrorResumen").style.visibility = "hidden";
        document.all("ErrorTextoColaboracion").style.visibility = "hidden";
        document.all("ErrorPublicacion").style.visibility = "hidden";
        //        document.all("ErrorSubirArchivo").style.visibility = "hidden";
        //        document.all("ErrorSubirArchivo2").style.visibility = "hidden";

        document.all("ErrorTitulo").style.display = 'none';
        document.all("ErrorResumen").style.display = 'none';
        document.all("ErrorPublicacion").style.display = 'none';
        document.all("ErrorTextoColaboracion").style.visibility = "none";
        //        document.all("ErrorSubirArchivo").style.display = 'none';
        //        document.all("ErrorSubirArchivo2").style.display = 'none';

        if (document.all(oTitulo).value == '') {
            document.all("ErrorTitulo").style.display = 'block';
            document.all("ErrorTitulo").style.visibility = "visible";
            document.all(oTitulo).focus();
            return false;
        }
        else if (document.all(oResumen).value == '') {
            document.all("ErrorResumen").style.display = 'block';
            document.all("ErrorResumen").style.visibility = "visible";
            document.all(oResumen).focus();
            return false;
        }
        else if (valor == '') {
            document.all("ErrorPublicacion").style.display = 'block';
            document.all("ErrorPublicacion").style.visibility = "visible";
            document.all(oPublicacion).focus();
            return false;
        }
        else if (verificar(document.all(oFile).value) == false) {
             if (document.all(oTextoColaboracion).value == '') {
                 document.all("ErrorTextoColaboracion").style.display = 'block';
                 document.all("ErrorTextoColaboracion").style.visibility = "visible";
                 document.all(oTextoColaboracion).focus();
      
                 document.all("ErrorSubirArchivo2").style.display = 'block';
                    document.all("ErrorSubirArchivo2").style.visibility = "visible";
                    document.all(oFile).focus();
                    return false;
             }
        

        }
    }

    function verificar(file) {

        var archivo = file;

        debugger;
        var extension = (archivo.substring(archivo.lastIndexOf("."))).toLowerCase();
        //Aqui escriben la extensión que desean aceptar
        if (extension == ".doc" || extension == ".pdf" || extension == ".docx" || extension == ".ppt" || extension == ".pptx") {
            return true
        }
        else {
            //alert('Elija un archivo del tipo PDF')
            return false;
        }
    }
    
    
     </script>





</asp:Content>
<asp:Content ID="Upload_Inicial" ContentPlaceHolderID="ContenidoInicial" Runat="Server">

</asp:Content>
<asp:Content ID="Upload_Central" ContentPlaceHolderID="ContenidoCentral" Runat="Server">
    <div id="breadcrumb" class="breadcrumbs">
    	<a href="Default.aspx">Inicio</a>&raquo;<a class="actual">Colaborar</a>
    </div>
     <div id="central_content">
        <div id="cnt_header">
            <h1>Participa con tu Colaboración</h1>
        </div>
      <div id="cnt_contentDespuesdeGuardar" runat="Server" visible=false>
          <h3>Gracias, se envió un email a tu correo, avisandote que hemos recibido tu colaboración!</h3>
          <p>en poco tiempo, el equipo de ParaLideres activará tu colaboración. </p>
      </div> 
      <div id="cnt_contentAntesdeGuardar" runat="Server" visible=false> 
        <div id="cnt_content">
    	
      <h3>Ingresa los datos de tu colaboración y luego presiona el botón "Enviar".</h3>
    	
      <p>Tu colaboración no va a ser publicada inmediatamente ya que primero debe ser aprobada por el equipo de Para Líderes. Este proceso tomará uno o dos días.</p>
      <p>Si vas a adjuntar un archivo, recuerda que los formatos permitidos son: Word (doc - docx), PowerPoint (ppt - pptx) y PDF.</p>
      <p>Los campos con ater&iacute;sco(*) son obligatorios.</p>
      
       <div class="reg_fields_box">
       
      <h2>Tu Colaboración</h2>
      <p><label>*Título: <br/>
        <input type="text" name="Titulo" id="Titulo" runat="server" value="" size=45 maxlength=50 title="*Ingresa el título de tu colaboración" class="frmInput"></label>
       <label id="ErrorTitulo"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      <p>*Resumen: <br/>
      <asp:TextBox ID="Resumen" runat="server"  maxlength=256  TextMode="MultiLine" 
              ToolTip="Ingresa un pequeño resumen de tu colaboración (máximo 255 caracteres.)" 
              Height="78px" Width="275px"></asp:TextBox>
      <label id="ErrorResumen"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>       
      <p>Texto: <br/>
      <asp:TextBox ID="TextoColaboracion" runat="server"  maxlength=256  TextMode="MultiLine" ToolTip="Ingresa aquí el texto de tu colaboración" Height="150px" Width="275px"></asp:TextBox>
            <label id="ErrorTextoColaboracion"   style="visibility:hidden; color:Red">Debe agregar un texto o subir un archivo</label>
      </p>       
      <p><label for="Country">*Publicar en:</label><br/>
			<asp:DropDownList ID="Publicacion" style="font-size:x-small" runat="server" Width="200px" ></asp:DropDownList>
			<label id="ErrorPublicacion"   style="visibility:hidden; color:Red">* Obligatorio</label>
      </p>
      <p><label>Subir Archivo (max. 4MB): </label> <br/>
       <input type="file" name="File_U" id="File_U" runat="server" size=45 maxlength=50  class=frmInput>
       <label id="ErrorSubirArchivo"   style="visibility:hidden; color:Red">El archivo excede el tamaño máximo de 4MB.</label>
       <label id="ErrorSubirArchivo2"   style="visibility:hidden; color:Red">(Elija un archivo del tipo DOC, PPT o PDF)</label>
      </p>      
       		<p><img src="" id="imgCaptchaReg" runat="server" />
		<input type="text" name="txtImagenCaptchaReg" id="txtImagenCaptchaReg"  runat="server"  value=""  class="frmInput" title="Ingresa los numero que aparecen en la imagen" >
	    <label id="LblImagenCaptchaReg"   style="visibility:hidden; color:Red">* Obligatorio</label>
	    <label id="LblImagenCaptchaRerPersonal" runat="server"  style="color:Red"></label>
		</p>
       <asp:Button ID="btnEnviarColaboracion" runat="server" Text="Enviar"  CssClass ="link_btn_round_md" OnClientClick="return validarFormulario();"  /><br/><br/>
       </div>
      </div>
      </div>
     </div>
     <input id="hidEstaRegistrado" name="hidEstaRegistrado" type="hidden" runat="server" clientidmode="Static" />
  
</asp:Content>
<asp:Content ID="Upload_Final" ContentPlaceHolderID="ContenidoFinal" Runat="Server">
</asp:Content>
