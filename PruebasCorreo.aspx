<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PruebasCorreo.aspx.vb" Inherits="PLWeb4_7.PruebasCorreo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <label>Ingrese Contraseña:</label>
    <asp:TextBox ID="txtcontrasena" runat="server" Width="190px"></asp:TextBox>
    <asp:Button ID="btnVer" runat="server" Text="Visualizar  Prueba" />
    <br />
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    
    
    <table runat="server" id="Tabla_Principal">
        <tr>
            <td>
            <table border="1" width="50%">
                    <tr align="center">
                        <td colspan="2"><h3>Prueba de envio de Correo con servidor de mail, en el servidor nuevo</h3></td>
                        
                    </tr>
                    <tr>
                        <td>MailServer:</td>
                        <td><asp:TextBox ID="txtServidorN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>PuertoMail:</td>
                        <td>
                            <asp:TextBox ID="txtPuertoN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>CredentialMail:</td>
                        <td>
                            <asp:TextBox ID="txtCredenciaMailN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>CrendetialPass:</td>
                        <td>
                            <asp:TextBox ID="txtCrendetialPassN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                                
                    <tr>
                        <td>De:</td>
                        <td>
                            <asp:TextBox ID="txtDeN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Para:</td>
                        <td>
                            <asp:TextBox ID="txtParaN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Asunto:</td>
                        <td>
                            <asp:TextBox ID="txtAsuntoN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>                        
                    <tr>
                        <td>Contenido:</td>
                        <td>
                            <asp:TextBox ID="txtContenidoN" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>                                    
                    <tr align="center">
                        <td colspan="2">
                            <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" />
                        </td>
                    </tr>                                    
                    
                </table>         
            </td>
            <td>
         <table border="1" width="50%">
                    <tr align="center">
                        <td colspan="2"><h3>Prueba de envio de Correo con servidor de mail, en el servidor antiguo</h3></td>
                        
                    </tr>
                    <tr>
                        <td>MailServer:</td>
                        <td><asp:TextBox ID="txtServidorOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>PuertoMail:</td>
                        <td>
                            <asp:TextBox ID="txtPuertoOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>CredentialMail:</td>
                        <td>
                            <asp:TextBox ID="txtCredenciaMailOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>CrendetialPass:</td>
                        <td>
                            <asp:TextBox ID="txtCrendetialPassOut" runat="server" Width="190px" ></asp:TextBox>
                        </td>
                    </tr>
                                
                    <tr>
                        <td>De:</td>
                        <td>
                            <asp:TextBox ID="txtDeOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Para:</td>
                        <td>
                            <asp:TextBox ID="txtParaOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Asunto:</td>
                        <td>
                            <asp:TextBox ID="txtAsuntoOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>                        
                    <tr>
                        <td>Contenido:</td>
                        <td>
                            <asp:TextBox ID="txtContenidoOut" runat="server" Width="190px"></asp:TextBox>
                        </td>
                    </tr>                                    
                    <tr align="center">
                        <td colspan="2">
                            <asp:Button ID="BtnEnviarOut" runat="server" Text="Enviar" />
                        </td>
                    </tr>                                    
                    
                </table>            
            </td>
        </tr>
    </table>
    
    <asp:Label ID="lblErrorEnvioMail" runat="server" Text="" ForeColor="Red"></asp:Label>   

    
    </div>
    </form>
</body>
</html>
