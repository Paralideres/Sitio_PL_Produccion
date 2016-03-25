<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Calendar1.aspx.vb" Inherits="PLWeb4_7.Calendar1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<html >
	<head>
		<title>Calendario</title>
		<%--<link href="./estilos/Calendario.css" type="text/css" rel="stylesheet">--%>
		<link href="../css/Calendario.css" rel="stylesheet" type="text/css" />
		<%--<link href="./estilos/prueba.css" rel="stylesheet" type="text/css" />--%>
        <style>
			A:link { COLOR: #ffff99; TEXT-DECORATION: none }
			A:visited { COLOR: #ffff99; TEXT-DECORATION: none }
			A:active { COLOR: #ffff99; TEXT-DECORATION: none }
			A:hover { COLOR: #ffff99; TEXT-DECORATION: none }
			.BotonImagen {FONT-FAMILY: Webdings; LETTER-SPACING: 0px; HEIGHT: 20px }
			.TextoYear {COLOR: black; font-family:Tahoma;font-weight:bold;font-size:20px;}
		</style>
		<script type="text/javascript" language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
	if (document.frmCalendario.boCerrar.value == "S")
	{
		top.returnValue = frmCalendario.myFecha.value ;
		top.close();
	}

}

function desplazar_anos(deplazamiento)
{
	document.frmCalendario.cantYear.value = deplazamiento;
	document.frmCalendario.submit();
}
//-->
		</script>
	</head>
	<body language="javascript" onload="return window_onload()"  MS_POSITIONING="GridLayout" >
		<form id="frmCalendario" method="post" runat="server">
			<table cellspacing="0" cellpadding="3" width="100%" border="0">
				<tr>
					<td valign="top">
						<table class="TablaEncabezado" cellspacing="0" cellpadding="0" width="100%">
							<tr>
								<td> 
									<table width="100%">
										<tr>
											<td width="10"><A href="javascript:desplazar_anos(-10)" class="BotonImagen">7</A></td>
											<td width="10"><A href="javascript:desplazar_anos(-1)" class="BotonImagen">3</A></td>
											<td align="middle"><asp:label id="LabelYear" runat="server" CssClass="TextoYear">2005</asp:label></td>
											<td width="10"><A href="javascript:desplazar_anos(1)" class="BotonImagen">4</A></td>
											<td width="10"><A href="javascript:desplazar_anos(10)" class="BotonImagen">8</A></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="middle"><asp:calendar id="Calendario" runat="server" ShowGridLines="True" FirstDayOfWeek="Monday" BorderWidth="1px" BorderColor="DarkGray" SelectedDate="2005-06-16" Font-Names="Verdana" Font-Size="8pt" Width="100%" ForeColor="Black" Height="150px">
										<TodayDayStyle Font-Bold="True" ForeColor="White" BackColor="#2763A5"></TodayDayStyle>
										<SelectorStyle BackColor="#4587C7"></SelectorStyle>
										<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
										<DayHeaderStyle Font-Bold="True" Height="1px" BackColor="#C4DC94"></DayHeaderStyle>
										<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
										<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#4587C7"></TitleStyle>
										<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
									</asp:calendar></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table class="FondoTabla" width="100%">
							<tr>
								<td align="middle">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input id="cantYear" type="hidden" name="cantYear" runat="server"/> <input id="myFecha" type="hidden" name="myFecha" runat="server"/>
			<input id="boCerrar" type="hidden" value="N" name="boCerrar" runat="server"/>
		</form>
	</body>
</html>
