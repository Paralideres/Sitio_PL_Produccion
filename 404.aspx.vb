Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio

Partial Class _404
    Inherits System.Web.UI.Page
    Private Shared _Ambiente As String = System.Configuration.ConfigurationManager.AppSettings("PL_ENVIRONMENT")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strUrl As String = ""
        Dim strUbicacion As String = ""
        Dim strReferrer As String = ""
        Dim strNewUrl As String = ""
        'Dim EmailAdmin As New InfoAdminEmails()
        'Dim oEmail As New InfoEnvioMail
        Dim oLog As New InfoLog()
        Dim strIpAddress = Request.UserHostAddress()
        Try
            strUrl = Request("aspxerrorpath")
            strUbicacion = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")

            'oEmail.De = EmailAdmin.EmailSupportAccount
            'oEmail.Para = EmailAdmin.EmailDeveloperAccount
            'oEmail.DesplieguedelNombre = "Ambiente : " & _Ambiente & "Ubicacion: " & strUbicacion & ", Paralideres, ErrorAutomatico "
            'oEmail.Asunto = "Ubicacion: " & strUbicacion & "Ambiente : " & _Ambiente & ": Error en Para Lideres, 404"
            'oEmail.Contenido = "404.aspx " & strUrl.ToString & vbCrLf & " Direccion IP=" & strIpAddress & vbCrLf & " Path : " & strUbicacion.ToString
            'oEmail.EsHtml = True
            oLog.Descripcion = "Ubicacion: " & strUbicacion & "Ambiente : " & _Ambiente & ": Error en Para Lideres, 404"
            oLog.Error = 404
            oLog.Url = "404.aspx " & strUrl.ToString & vbCrLf & " Direccion IP=" & strIpAddress & vbCrLf & " Path : " & strUbicacion.ToString

            If _Ambiente = "PRODUCCION" Then
                AdminLog.RegistrarLog(oLog)
                'EMail.Enviar(oEmail)
            End If
        Catch ex As Exception
            Dim oLogex As New InfoLog()
            oLogex.Descripcion = ex.Message
            oLogex.Error = 404
            oLogex.Url = "404.aspx"
            AdminLog.RegistrarLog(oLogex)
        End Try

        
    End Sub

End Class
