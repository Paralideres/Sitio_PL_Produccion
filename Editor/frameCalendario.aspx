<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frameCalendario.aspx.vb" Inherits="PLWeb4_7.frameCalendario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Calendario&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</title>
		

        <link href="./estilos/Calendario.css" rel="stylesheet" type="text/css" />

		<script type="text/javascript" id="clientEventHandlersJS" language="javascript">
            <!--

            function window_onload() {
                param = "strFecha=" + frmCalendario.myFecha.value;
                //alert(param);
		            iFrameCalendario.document.location = "Calendar1.aspx?"+param
            }

             //-->
        </script>
	</head>
	<body language="javascript" onload="return window_onload()">
		<form id="frmCalendario" method="post" runat="server">
			<table width="100%" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<iframe name="iFrameCalendario" src="" width="100%" height="250px" frameborder="0" scrolling="no">
						</iframe>
					</td>
				</tr>
			</table>
			<input id="myFecha" type="hidden" name="myFecha" runat="server"/>
					
		</form>
	</body>
</html>

