Imports Sistema.PL.Entidad
Imports Libreria.QueryString
Imports System.IO
Imports Sistema.PL.Negocio

Partial Public Class AccountFail
    Inherits System.Web.UI.Page
    Dim oUsuario As New InfoUsuario()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim parametro As String
        Dim IdUsuario As Integer
        'If Not IsPostBack Then
        parametro = Request.QueryString("IuAc")
        IdUsuario = Convert.ToInt32(parametro)

        oUsuario = Usuario.TraerUsuarioCompleto(IdUsuario)
        NombreUsuario.InnerHtml = oUsuario.RegNombre.ToString & " " & oUsuario.RegApellido.ToString & " "
        'End If
    End Sub

    Protected Sub btnActivar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnActivar.Click
        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
        Dim strAnio As String = Now().Year.ToString
        Dim oEmail As New InfoEnvioMail
        Dim EmailAdmin As New InfoAdminEmails()
        Dim strmensaje As String = ""
        Dim StrNombreUsuario As String = oUsuario.RegNombre & " " & oUsuario.RegApellido
        Dim StrPassword As String = oUsuario.Clave.ToString
        Dim strUrl As String
        Dim project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath")
        oEmail.De = EmailAdmin.EmailSupportAccount
        oEmail.Para = oUsuario.Email.ToString()
        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("DespliegueNombreAuto")
        oEmail.Asunto = System.Configuration.ConfigurationManager.AppSettings("AsuntoCorreoAuto") '"Bienvenido a ParaLideres"
        strUrl = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")
        Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)
        valores.Add("ID_USU", oUsuario.IdUsuario.ToString)
        valores.Add("Nombre", oUsuario.RegNombre.ToString)
        valores.Add("Apellido", oUsuario.RegApellido.ToString)
        valores.Add("Clave", oUsuario.Clave.ToString)
        valores.Add("Hoy", strAnio & strMes & strDia)
        Dim QS As New QueryString("")
        Try
            QS = New QueryString(valores)
            strmensaje = "encripta"
        Catch ex As Exception
            strmensaje = "No encripta"
        End Try


        Dim strUrlActivar As String = ""
        strUrlActivar = strUrl & project_path & "ActiveAccount.aspx?action=" & QS.QSEncriptada.ToString

        Dim fp As StreamReader
        Dim strLinea As String = " "
        Dim strmailContenido As String = ""
        Try
            fp = File.OpenText(Server.MapPath(".\") & "EstructuraEmailRegistro.htm")

            While Not strLinea Is Nothing
                strLinea = fp.ReadLine()
                If strLinea.IndexOf("usuario es:") > 0 Then
                    strmailContenido = strmailContenido & strLinea
                    strmailContenido = strmailContenido & StrNombreUsuario
                ElseIf strLinea.IndexOf("contraseña es:") > 0 Then
                    strmailContenido = strmailContenido & strLinea
                    strmailContenido = strmailContenido & StrPassword
                ElseIf strLinea.IndexOf("link:") > 0 Then
                    strmailContenido = strmailContenido & strLinea
                    strmailContenido = strmailContenido & "<a href=" & strUrlActivar & " target='_blank'> " & strUrlActivar & " </a> <br/>"
                Else
                    strmailContenido = strmailContenido & strLinea
                End If


            End While
            fp.Close()
        Catch err As Exception
        End Try

        oEmail.Contenido = strmailContenido
        Try
            Sistema.PL.Negocio.EMail.Enviar(oEmail)
            strmensaje = "Envia mail"
            Dim oLog As New InfoLog()
            oLog.Descripcion = "Si Envia mail, Datos,  Para: " & oEmail.Para.ToString & ", " & oEmail.Asunto.ToString
            oLog.Error = 3
            oLog.Url = "Register.aspx"
            AdminLog.RegistrarLog(oLog)

        Catch ex As Exception
            strmensaje = "No Envia mail"
            Dim oLog As New InfoLog()
            oLog.Descripcion = strmensaje & ", " & ex.Message & ", Datos : Para" & oEmail.Para.ToString & ", " & oEmail.Asunto.ToString
            oLog.Error = 4
            oLog.Url = "Register.aspx"
            AdminLog.RegistrarLog(oLog)
        End Try


        btnActivar.Visible = False
        MensajeError.Visible = True
        MensajeError.InnerHtml = "Te hemos enviado un e-mail a tu correo!.(Si no te llega, revisa tambien en los spam)"
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