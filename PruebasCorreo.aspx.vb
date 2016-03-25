Imports Sistema.PL.Entidad

Partial Public Class PruebasCorreo
    Inherits System.Web.UI.Page
    Private Shared _CredentialMail As String = System.Web.Configuration.WebConfigurationManager.AppSettings("CredentialMail")
    Private Shared _CrendetialPass As String = System.Web.Configuration.WebConfigurationManager.AppSettings("CrendetialPass")
    Private Shared _HabilitaSSL As String = System.Web.Configuration.WebConfigurationManager.AppSettings("HabilitaSSL")
    Private Shared _PuertoMail As String = System.Web.Configuration.WebConfigurationManager.AppSettings("PuertoMail")
    Private Shared _MailServer As String = System.Web.Configuration.WebConfigurationManager.AppSettings("MailServer")

    Private Shared _CredentialMailOut As String = System.Web.Configuration.WebConfigurationManager.AppSettings("CredentialMailOut")
    Private Shared _CrendetialPassOut As String = System.Web.Configuration.WebConfigurationManager.AppSettings("CrendetialPassOut")
    Private Shared _HabilitaSSLOut As String = System.Web.Configuration.WebConfigurationManager.AppSettings("HabilitaSSLOut")
    Private Shared _PuertoMailOut As String = System.Web.Configuration.WebConfigurationManager.AppSettings("PuertoMailOut")
    Private Shared _MailServerOut As String = System.Web.Configuration.WebConfigurationManager.AppSettings("MailServerOut")


    Dim EmailAdmin As New InfoAdminEmails()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtCrendetialPassN.TextMode = TextBoxMode.Password
        'txtCrendetialPassOut.TextMode = TextBoxMode.Password



        If (Not IsPostBack) Then
            Tabla_Principal.Visible = False
            txtServidorN.Text = _MailServer.ToString
            txtPuertoN.Text = _PuertoMail.ToString
            txtCredenciaMailN.Text = _CredentialMail.ToString
            txtCrendetialPassN.Text = _CrendetialPass.ToString
            txtDeN.Text = EmailAdmin.EmailSupportAccount
            txtParaN.Text = "kcoglezz@gmail.com"
            txtAsuntoN.Text = "pruebas en servidor nuevo"
            txtContenidoN.Text = "contenido de prueba servidor nuevo"

            txtServidorOut.Text = _MailServerOut.ToString
            txtPuertoOut.Text = _PuertoMailOut.ToString
            txtCredenciaMailOut.Text = _CredentialMailOut.ToString
            txtCrendetialPassOut.Text = _CrendetialPassOut.ToString
            txtDeOut.Text = EmailAdmin.EmailSupportAccount
            txtParaOut.Text = "kcoglezz@gmail.com"
            txtAsuntoOut.Text = "pruebas en servidor antiguo"
            txtContenidoOut.Text = "contenido de prueba servidor antiguo"


        End If
    End Sub

    Protected Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviar.Click

        Dim oEmail As New InfoEnvioMail
        lblErrorEnvioMail.Text = ""
        Dim oEmailServer As New InfoEMailServer

        oEmail.De = txtDeN.Text
        oEmail.Para = txtParaN.Text
        oEmail.Asunto = txtAsuntoN.Text
        oEmail.Contenido = txtContenidoN.Text

        oEmailServer.MailServer = txtServidorN.Text
        oEmailServer.PuertoMail = txtPuertoN.Text
        oEmailServer.CredentialMail = txtCredenciaMailN.Text
        oEmailServer.CrendetialPass = txtCrendetialPassN.Text
        oEmailServer.HabilitaSSL = _HabilitaSSL.ToString
        Try
            Library_PL_Editor.ParaLideres.Funcion.EnviarCorreo(oEmail, oEmailServer)
            lblErrorEnvioMail.ForeColor = Drawing.Color.Green
            lblErrorEnvioMail.Text = "Se Envio correctamente el Mail desde el servidor de email actual : " + oEmailServer.MailServer
        Catch ex As Exception
            lblErrorEnvioMail.ForeColor = Drawing.Color.Red
            lblErrorEnvioMail.Text = "Error enviando email en el servior Actual: " + ex.Message
            'Response.Write("Error enviando email en el servior Actual: " + ex.Message)
        End Try



    End Sub

    Protected Sub BtnEnviarOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEnviarOut.Click
        Dim oEmail As New InfoEnvioMail
        lblErrorEnvioMail.Text = ""
        Dim oEmailServer As New InfoEMailServer

        oEmail.De = txtDeOut.Text
        oEmail.Para = txtParaOut.Text
        oEmail.Asunto = txtAsuntoOut.Text
        oEmail.Contenido = txtContenidoOut.Text

        oEmailServer.MailServer = txtServidorOut.Text
        oEmailServer.PuertoMail = txtPuertoOut.Text
        oEmailServer.CredentialMail = txtCredenciaMailOut.Text
        oEmailServer.CrendetialPass = txtCrendetialPassOut.Text
        oEmailServer.HabilitaSSL = _HabilitaSSLOut.ToString

        Try
            Library_PL_Editor.ParaLideres.Funcion.EnviarCorreo(oEmail, oEmailServer)
            lblErrorEnvioMail.ForeColor = Drawing.Color.Green
            lblErrorEnvioMail.Text = "Se Envio correctamente el Mail desde el servidor de email antiguo : " + oEmailServer.MailServer
        Catch ex As Exception
            'Response.Write("Error enviando email en el servior antiguo: " + ex.Message)
            lblErrorEnvioMail.ForeColor = Drawing.Color.Red
            lblErrorEnvioMail.Text = "Error enviando email en el servior antiguo: " + ex.Message

        End Try


    End Sub

    Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVer.Click
        If txtcontrasena.Text = "p4r4lideres" Then
            Tabla_Principal.Visible = True
            lblError.Text = ""
        Else
            lblError.Text = "*Contraseña Incorrecta"
            Tabla_Principal.Visible = False
        End If
    End Sub
End Class