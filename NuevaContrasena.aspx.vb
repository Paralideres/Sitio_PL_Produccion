Imports Sistema.PL.Negocio

Partial Public Class NuevaContrasena
    Inherits System.Web.UI.Page
    Dim liQS As Libreria.QueryString.QueryString
    Dim strEmail As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim strOlvidoCMailMinutosDuracion As String = System.Configuration.ConfigurationManager.AppSettings("OlvidoCMailMinutosDuracion")
        Dim parametro As String = Request.QueryString("action")
        Dim strHoy As String
        Dim IntNumeroLink As Integer
        Dim intNumeroActual As Integer
        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
        Dim strAnio As String = Now().Year.ToString

        liQS = New Libreria.QueryString.QueryString(parametro)
        strHoy = Convert.ToString(liQS.Item("Hoy"))
        strEmail = Convert.ToString(liQS.Item("Email"))

        IntNumeroLink = Convert.ToInt32(strHoy)
        intNumeroActual = Convert.ToInt32((strAnio & strMes & strDia).ToString())

        Dim intDiferencia = intNumeroActual - IntNumeroLink
        If intDiferencia <= Convert.ToInt32(strOlvidoCMailMinutosDuracion) Then
            cnt_contentMail.Visible = True
            cnt_contentGuardar.Visible = False
        Else

            cnt_contentMail.Visible = False
            cnt_contentGuardar.Visible = True
            MensajedelEnvio.InnerText = "Link Inactivo, por favor, debe hacer click en 'Olvide mi contraseña' y asi podremos darle un nuevo link"
        End If

    End Sub

    Function agregaCeroaIzq(ByVal texto As String) As String
        Dim nuevotexto As String = ""
        If texto.Length = 1 Then
            nuevotexto = "0" & texto
        Else
            nuevotexto = texto
        End If
        Return nuevotexto
    End Function

    Protected Sub btnRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistro.Click

        Dim intID As Integer = 0
        Try
            intID = Usuario.CambiarPassword(strEmail, Clave.Text.ToString())
            MensajedelEnvio.InnerText = "Su contraseña se actualizó correctamente!"
            cnt_contentGuardar.Visible = True
            cnt_contentMail.Visible = False

        Catch ex As Exception

        End Try


    End Sub

End Class