Imports Sistema.PL.Entidad
Imports Libreria.QueryString
Imports System.IO
Imports Sistema.PL.Negocio

Partial Public Class EnvioEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MensajedelEnvio.InnerText = ""
        cnt_contentGuardar.Visible = False
        cnt_contentMail.Visible = True
    End Sub

    Protected Sub btnRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistro.Click
        Dim strTexto As String = ""
        Dim EmailAdmin As New InfoAdminEmails()
        Dim oEmail As New InfoEnvioMail
        Dim strUrl As String
        Dim project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath")
        oEmail.De = EmailAdmin.EmailSupportAccount
        oEmail.Para = Email.Value

        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("OlvidoContra_Titulo_DespliegueNombreAuto")
        oEmail.Asunto = System.Configuration.ConfigurationManager.AppSettings("OlvidoContra_Asunto_CorreoAuto")
        strUrl = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")

        strTexto = strTexto & " Paso 1 "


        Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
        Dim strAnio As String = Now().Year.ToString

        strTexto = strTexto & " Paso 2 "
        valores.Add("Hoy", strAnio & strMes & strDia)


        valores.Add("Email", Email.Value.ToString())
        Dim strUrlActivar As String = ""
        strTexto = strTexto & " Paso 3 "
        Try
            Dim QS = New QueryString(valores)
            strTexto = strTexto & " Paso 4 "
            strUrlActivar = strUrl & project_path & "NuevaContrasena.aspx?action=" & QS.QSEncriptada.ToString
            strTexto = strTexto & " Paso 5 "
            Dim strOlvidoCMailRespuestaEnvio As String = System.Configuration.ConfigurationManager.AppSettings("OlvidoCMailRespuestaEnvio")
            Dim fp As StreamReader
            Dim strLinea As String = " "
            Dim strmailContenido As String = ""
            Try
                fp = File.OpenText(Server.MapPath(".\") & "EstructuraEmailOlvidoClave.htm")

                While Not strLinea Is Nothing
                    strLinea = fp.ReadLine()
                    If strLinea.IndexOf("link:") > 0 Then
                        strmailContenido = strmailContenido & strLinea
                        strmailContenido = strmailContenido & "<a href=" & strUrlActivar & " target='_blank'> " & strUrlActivar & " </a> <br/>"
                    Else
                        strmailContenido = strmailContenido & strLinea
                    End If


                End While
                fp.Close()
            Catch err As Exception
            End Try
            strTexto = strTexto & " Paso 6 "
            oEmail.Contenido = strmailContenido
            Try
                strTexto = strTexto & " Paso 7 "
                Sistema.PL.Negocio.EMail.Enviar(oEmail)
                strTexto = strTexto & " Paso 8 "
                MensajedelEnvio.InnerText = strOlvidoCMailRespuestaEnvio
                cnt_contentGuardar.Visible = True
                cnt_contentMail.Visible = False
                Dim strmensaje As String = "Si Envió para Recuperar contraseña "
                Dim oLog As New InfoLog()
                oLog.Descripcion = strmensaje & ", Datos :para " & oEmail.Para & ", " & oEmail.Asunto
                oLog.Error = 7
                oLog.Url = "EnvioEmail.aspx"
                strTexto = strTexto & " Paso 9 "
                AdminLog.RegistrarLog(oLog)
                strTexto = strTexto & " Paso 10 "
            Catch ex As Exception
                Dim strmensaje As String = "No Envió para Recuperar contraseña "
                Dim oLog As New InfoLog()
                oLog.Descripcion = strmensaje & ", " & ex.Message & ", Datos :para " & oEmail.Para & ", " & oEmail.Asunto
                oLog.Error = 8
                oLog.Url = "EnvioEmail.aspx"
                strTexto = strTexto & " Paso 11 "
                AdminLog.RegistrarLog(oLog)
                strTexto = strTexto & " Paso 12 "
            End Try

            'Response.Write(strTexto.ToString)
        Catch ex As Exception
            MensajedelEnvio.InnerText = "Error al tratar de enviar E-mail"
        End Try





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
End Class