<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SubirArchivo.aspx.vb" Inherits="PLWeb4_7.SubirArchivo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
 <link rel="Stylesheet" type="text/css" href="css/uploadify.css" />
 <script type="text/javascript" src="scripts/jquery-1.3.2.min.js"></script>
 <script type="text/javascript" src="scripts/jquery.uploadify.js"></script>
 <script type="text/javascript" src="scripts/JSPrueba.js" ></script>
</head>
<body>
        <form id="form1" runat="server">

            <div>
                
                <input id="fileToUpload" type="file" size="45" name="fileToUpload" class="input"/>
                <input id="btnSubir" type="button" name="btnSubir" value="Subir" />
               
            </div>
        </form>
</body>
</html>
