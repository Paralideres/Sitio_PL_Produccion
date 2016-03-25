'ImportsParaLideres
Imports Sistema.PL
Imports Sistema.PL.Entidad
Imports System.IO
Imports ParaLideres

Partial Public Class Contactenos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            cnt_contentDespuesdeGuardar.Visible = False
            cnt_contentAntesdeGuardar.Visible = True

            Dim intImageNumber = Funcion.GetRandomNumber(10000, 99999)
            imgCaptchaReg.Src = "CaptchaImage.aspx?x=" & intImageNumber
            HttpContext.Current.Session("CaptchaContactenos") = intImageNumber
        End If
    End Sub
    Protected Sub btnEnviarComentario_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarComentario.Click
        Dim intCaptcha As Integer = Convert.ToInt32(HttpContext.Current.Session("CaptchaContactenos"))
        Dim strintruduceCaptcha As String = txtImagenCaptchaReg.Value
        If strintruduceCaptcha <> "" Then
            If IsNumeric(strintruduceCaptcha) Then
                If intCaptcha = Convert.ToInt32(txtImagenCaptchaReg.Value) Then

                    Try
                        Dim EmailAdmin As New InfoAdminEmails()
                        Dim oEmail As New InfoEnvioMail

                        oEmail.De = EmailAdmin.EmailSupportAccount
                        oEmail.Para = EmailAdmin.EmailContactAccount
                        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Contactenos_Titulo_DespliegueNombreAuto")
                        oEmail.Asunto = System.Configuration.ConfigurationManager.AppSettings("contactenos_Asunto_CorreoAuto")

                        Dim fp As StreamReader
                        Dim strLinea As String = " "
                        Dim strmailContenido As String = ""
                        Try
                            fp = File.OpenText(Server.MapPath(".\") & "EstructuraEmailContactenos.htm")

                            While Not strLinea Is Nothing
                                strLinea = fp.ReadLine()
                                If strLinea.IndexOf("E-mail :") > 0 Then
                                    strmailContenido = strmailContenido & strLinea
                                    strmailContenido = strmailContenido & " " & Email.Value.ToString
                                ElseIf strLinea.IndexOf("reemplaza1") > 0 Then
                                    strmailContenido = strmailContenido & " " & TextoComentario.Text.ToString
                                Else
                                    strmailContenido = strmailContenido & strLinea
                                End If


                            End While
                            fp.Close()
                        Catch err As Exception
                        End Try
                        oEmail.Contenido = strmailContenido
                        Sistema.PL.Negocio.EMail.Enviar(oEmail)

                        cnt_contentDespuesdeGuardar.Visible = True
                        cnt_contentAntesdeGuardar.Visible = False

                    Catch ex As Exception

                    End Try
                Else
                    LblImagenCaptchaRerPersonal.Visible = True
                    LblImagenCaptchaRerPersonal.InnerText = "Número ingresado es distinto a la imagen"
                End If
            Else
                LblImagenCaptchaRerPersonal.Visible = True
                LblImagenCaptchaRerPersonal.InnerText = "Ingrese solo numeros"


            End If
        Else
            LblImagenCaptchaRerPersonal.Visible = True
            LblImagenCaptchaRerPersonal.InnerText = "* Obligatorio"
        End If



    End Sub
End Class