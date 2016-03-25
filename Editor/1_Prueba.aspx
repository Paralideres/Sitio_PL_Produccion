<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="1_Prueba.aspx.vb" Inherits="PLWeb4_7._1_Prueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <img src="../images/calendar.gif" />
     <%--<a>
        <img src=" & _project_path & "images/calendar.gif onclick='calendario(document." & _form_name & "." & strFldName & ")' border=0 align=top alt=""Presiona imagen para abrir el calendario."">
     </a>--%>
 <img src="/PLWeb4_7/images/calendar.gif" onclick="calendario(document.frmpages.posted)" border="0" align="top" alt="Presiona imagen para abrir el calendario."/>
    </div>
    </form>
</body>
</html>
