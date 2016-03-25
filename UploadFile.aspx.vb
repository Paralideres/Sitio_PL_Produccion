Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.IO

Partial Public Class UploadFile
    Inherits System.Web.UI.Page
    Dim oUsuario As New InfoUsuario()
    Dim ListadoRecurso As New List(Of InfoRecurso)
    Dim bo_mostrar_captcha As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oUsuario = Session("UsuarioConectado")



        If (Not IsPostBack) Then
            'cnt_contentGuardar.Visible = False
            'cnt_contentEditar.Visible = True
            ListadoRecurso = NegRecurso.ListarRecursos()
            LlenaComboRecurso(ListadoRecurso)
            cnt_contentDespuesdeGuardar.Visible = False
            cnt_contentAntesdeGuardar.Visible = True


            If oUsuario Is Nothing Then
                Response.Redirect("Register.aspx?Registrado=0")
            Else
                txtImagenCaptchaReg.Visible = False
                bo_mostrar_captcha = False
            End If

            If Not oUsuario Is Nothing Then
                bo_mostrar_captcha = False
                'Dim intImageNumber = Functions.GetRandomNumber(10000, 99999)
                'imgCaptchaReg.Src = "CaptchaImage.aspx?x=" & intImageNumber
                'HttpContext.Current.Session("CaptchaUpLoad") = intImageNumber

            Else
                bo_mostrar_captcha = True
                'Dim intImageNumber = Functions.GetRandomNumber(10000, 99999)
                'imgCaptchaReg.Src = "CaptchaImage.aspx?x=" & intImageNumber
                'HttpContext.Current.Session("CaptchaUpLoad") = intImageNumber
            End If

        End If




    End Sub
    Protected Sub LlenaComboRecurso(ByVal Listado As List(Of InfoRecurso))
        Dim valor As Integer = 0
        'Establece el primer elemento del combo
        Publicacion.Items.Add(New ListItem("[Seleccione una opción]", ""))
        For Each Resultado As InfoRecurso In Listado
            valor = Convert.ToInt32(Resultado.Id.ToString)
            Dim item As ListItem = New ListItem(Resultado.Nombre.ToString, valor.ToString)
            Publicacion.Items.Add(item)
        Next
    End Sub

    Protected Sub btnEnviarColaboracion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviarColaboracion.Click
        Dim strNombreDeLaSeccion = ""
        Dim intIdSecciondeColaboracion As Integer = 0
        intIdSecciondeColaboracion = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("IdSecciondeColaboracion"))

        If bo_mostrar_captcha = True Then
            Dim intCaptcha As Integer = Convert.ToInt32(HttpContext.Current.Session("CaptchaUpLoad"))
            Dim strintruduceCaptcha As String = txtImagenCaptchaReg.Value

            If strintruduceCaptcha <> "" Then
                If intCaptcha = Convert.ToInt32(txtImagenCaptchaReg.Value) Then
                    Dim oColaboracion As New InfoColaboracion
                    oColaboracion.intUserId = oUsuario.IdUsuario

                    oColaboracion.strPageTitle = Titulo.Value
                    oColaboracion.strBlurb = Resumen.Text
                    oColaboracion.strBody = TextoColaboracion.Text
                    If intIdSecciondeColaboracion = 0 Then
                        intIdSecciondeColaboracion = Publicacion.SelectedItem.Value
                    End If
                    oColaboracion.intSectionId = intIdSecciondeColaboracion
                    strNombreDeLaSeccion = Publicacion.SelectedItem.Text.ToString()



                    If Not File_U.PostedFile Is Nothing And File_U.PostedFile.ContentLength > 0 Then
                        Dim strArchivo As String = File_U.Value.ToString()
                        Dim strTipoArchivo As String() = strArchivo.Split(".")
                        oColaboracion.strPic = "pic_" & oUsuario.IdUsuario & "." & strTipoArchivo(1)
                    End If
                    oColaboracion.dtPosted = Now()
                    Dim fn As String = System.IO.Path.GetFileName(File_U.PostedFile.FileName)
                    File_U.PostedFile.SaveAs(Server.MapPath(".\") & "files\" & oColaboracion.strPic.ToString) 'fn

                    Try
                        If Pagina.RegistrarColaboracion(oColaboracion) > 0 Then
                            Dim EmailAdmin As New InfoAdminEmails()
                            Dim oEmail As New InfoEnvioMail

                            oEmail.De = EmailAdmin.EmailSupportAccount
                            oEmail.Para = oUsuario.Email.ToString()

                            oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Colabora_Titulo_DespliegueNombreAuto")
                            oEmail.Asunto = System.Configuration.ConfigurationManager.AppSettings("Colabora_Asunto_CorreoAuto")

                            Dim fp As StreamReader
                            Dim strLinea As String = " "
                            Dim strmailContenido As String = ""
                            Try
                                fp = File.OpenText(Server.MapPath(".\") & "EstructuraEmaildeColaboracion.htm")

                                While Not strLinea Is Nothing
                                    strLinea = fp.ReadLine()
                                    If strLinea.IndexOf("Colaboración,") > 0 Then
                                        strmailContenido = strmailContenido & strLinea
                                        strmailContenido = strmailContenido & oUsuario.Nombre.ToString
                                    ElseIf strLinea.IndexOf("Título:") > 0 Then
                                        strmailContenido = strmailContenido & strLinea
                                        strmailContenido = strmailContenido & " " & oColaboracion.strPageTitle.ToString
                                    ElseIf strLinea.IndexOf("Resumen:") > 0 Then
                                        strmailContenido = strmailContenido & strLinea
                                        strmailContenido = strmailContenido & " " & oColaboracion.strBlurb.ToString
                                    ElseIf strLinea.IndexOf("Documento:") > 0 Then
                                        strmailContenido = strmailContenido & strLinea
                                        strmailContenido = strmailContenido & " " & File_U.PostedFile.FileName.ToString & " y se va a publicar en: " & Publicacion.SelectedItem.Text.ToString
                                    Else
                                        strmailContenido = strmailContenido & strLinea
                                    End If


                                End While
                                fp.Close()
                            Catch err As Exception
                            End Try
                            oEmail.Contenido = strmailContenido

                            Sistema.PL.Negocio.EMail.Enviar(oEmail)
                            'MensajedelEnvio.InnerText = strOlvidoCMailRespuestaEnvio
                            cnt_contentDespuesdeGuardar.Visible = True
                            cnt_contentAntesdeGuardar.Visible = False
                        End If




                    Catch ex As Exception

                    End Try
                Else
                    LblImagenCaptchaRerPersonal.Visible = True
                    LblImagenCaptchaRerPersonal.InnerText = "Número ingresado es distinto a la imagen"
                End If
            Else
                LblImagenCaptchaRerPersonal.Visible = True
                LblImagenCaptchaRerPersonal.InnerText = "* Obligatorio"
            End If

        Else
            Dim oColaboracion As New InfoColaboracion
            oColaboracion.intUserId = oUsuario.IdUsuario

            Dim strNombreArchivo As String = ""
            strNombreDeLaSeccion = Publicacion.SelectedItem.Text.ToString()

            oColaboracion.strPageTitle = Titulo.Value & ", para publicar en:" & strNombreDeLaSeccion
            'objArticle.setPageTitle(ParaLideres.Functions.FormatCase(ParaLideres.Functions.FormatString(Request("Title")), True) & " para publicar en:" & ParaLideres.Functions.FormatString(Request("Section")))
            oColaboracion.strBlurb = Resumen.Text
            oColaboracion.strBody = TextoColaboracion.Text
            'If TextoColaboracion.Text.ToString <> "" Then
            oColaboracion.intTypeofarticle = 1
            'End If

            If intIdSecciondeColaboracion = 0 Then
                intIdSecciondeColaboracion = Publicacion.SelectedItem.Value
            End If

            oColaboracion.intSectionId = intIdSecciondeColaboracion 'Publicacion.SelectedItem.Value


            Dim strTxtFecha = Now().ToString()

            Dim anio As String '= cadena.substring(0, 4)
            Dim mes As String '= cadena.substring(3, 2)
            Dim dia As String '= cadena.substring(5, 2)
            dia = Now().Day.ToString
            mes = Now().Month.ToString
            anio = Now().Year.ToString

            Dim strSplitFecha As String()

            If strTxtFecha.IndexOf("/") > 0 Then
                strSplitFecha = strTxtFecha.Split("/")
                If strSplitFecha(0).Length = 2 Then
                    'entonces esta colocando el dia primero
                    dia = strSplitFecha(0)
                    mes = strSplitFecha(1)
                    anio = strSplitFecha(2)
                End If
                If strSplitFecha(0).Length = 4 Then
                    'entonces esta colocando el año primero
                    anio = strSplitFecha(0)
                    mes = strSplitFecha(1)
                    dia = strSplitFecha(2)
                End If
            ElseIf strTxtFecha.IndexOf("-") > 0 Then
                strSplitFecha = strTxtFecha.Split("-")
                If strSplitFecha(0).Length = 2 Then
                    'entonces esta colocando el dia primero
                    dia = strSplitFecha(0)
                    mes = strSplitFecha(1)
                    anio = strSplitFecha(2)
                End If
                If strSplitFecha(0).Length = 4 Then
                    'entonces esta colocando el año primero
                    anio = strSplitFecha(0)
                    mes = strSplitFecha(1)
                    dia = strSplitFecha(2)
                End If
            End If


            dia = agregaCeroaIzq(dia)
            mes = agregaCeroaIzq(mes)
            anio = anio.Substring(0, 4)
            Dim dtNuevafecha As DateTime

            dtNuevafecha = New DateTime(anio, mes, dia, 0, 0, 0)

            oColaboracion.dtPosted = dtNuevafecha

            If Not File_U.PostedFile Is Nothing And File_U.PostedFile.ContentLength > 0 Then
                Dim strArchivo As String = File_U.Value.ToString()
                Dim strTipoArchivo As String() = strArchivo.Split(".")
                oColaboracion.strPic = "pic_" & oUsuario.IdUsuario & "." & strTipoArchivo(1)
                oColaboracion.intTypeofarticle = 2

            Else
                strNombreArchivo = ""

            End If


            Try
                Dim strSplitTipos As String()
                Dim strExt_Tipo_Archivos As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Ext_Tipo_Archivos"))
                strSplitTipos = strExt_Tipo_Archivos.Split(",")
                'busca si el tipo de archivo puede existir en la configuracion conocida webconfig
                Dim strArchivo As String = File_U.Value.ToString()
                Dim strTipoArchivo As String() = strArchivo.Split(".")
                Dim boArchivoPermitido As Boolean = False
                For Each strElemento As String In strSplitTipos
                    If (strTipoArchivo(1) = strElemento Or UCase(strTipoArchivo(1)) = UCase(strElemento)) Then
                         boArchivoPermitido = True
                        Exit For
                    End If
                Next


                If boArchivoPermitido = True Then


                    Dim intIdPage As Integer = 0
                    intIdPage = Pagina.RegistrarColaboracion(oColaboracion)

                    If intIdPage > 0 Then
                        If oColaboracion.intTypeofarticle = 2 Then
                            'Dim strArchivo As String = File_U.Value.ToString()
                            'Dim strTipoArchivo As String() = strArchivo.Split(".")
                            Dim strnuevoNombre = "pic_" & intIdPage & "." & strTipoArchivo(1)
                            Dim fn As String = System.IO.Path.GetFileName(File_U.PostedFile.FileName)
                            File_U.PostedFile.SaveAs(Server.MapPath(".\") & "files\" & strnuevoNombre) 'fn
                            strNombreArchivo = File_U.PostedFile.FileName.ToString

                        End If
                        Dim EmailAdmin As New InfoAdminEmails()
                        Dim oEmail As New InfoEnvioMail
                        oEmail.De = EmailAdmin.EmailSupportAccount
                        oEmail.Para = oUsuario.Email.ToString()
                        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Colabora_Titulo_DespliegueNombreAuto")
                        oEmail.Asunto = System.Configuration.ConfigurationManager.AppSettings("Colabora_Asunto_CorreoAuto")

                        Dim fp As StreamReader
                        Dim strLinea As String = " "
                        Dim strmailContenido As String = ""
                        Try
                            fp = File.OpenText(Server.MapPath(".\") & "EstructuraEmaildeColaboracion.htm")

                            While Not strLinea Is Nothing
                                strLinea = fp.ReadLine()
                                If strLinea Is Nothing Then
                                    Exit While
                                End If
                                If strLinea.IndexOf("Colaboración,") > 0 Then
                                    strmailContenido = strmailContenido & strLinea
                                    strmailContenido = strmailContenido & oUsuario.Nombre.ToString
                                ElseIf strLinea.IndexOf("Título:") > 0 Then
                                    strmailContenido = strmailContenido & strLinea
                                    strmailContenido = strmailContenido & " " & oColaboracion.strPageTitle.ToString
                                ElseIf strLinea.IndexOf("Resumen:") > 0 Then
                                    strmailContenido = strmailContenido & strLinea
                                    strmailContenido = strmailContenido & " " & oColaboracion.strBlurb.ToString
                                ElseIf strLinea.IndexOf("Documento:") > 0 Then

                                    If strNombreArchivo = "" Then
                                        'strmailContenido = strmailContenido & strLinea
                                        strmailContenido = strmailContenido & "<p> se va a publicar en: " & Publicacion.SelectedItem.Text.ToString & " </p>"
                                    Else
                                        strmailContenido = strmailContenido & strLinea
                                        strmailContenido = strmailContenido & " " & strNombreArchivo & " y se va a publicar en: " & Publicacion.SelectedItem.Text.ToString
                                    End If

                                Else
                                    strmailContenido = strmailContenido & strLinea
                                End If


                            End While
                            fp.Close()
                        Catch err As Exception
                            Response.Write("<script language = 'javascript'>alert('error1: " + err.Message.ToString() + " '); </script>")
                        End Try
                        oEmail.Contenido = strmailContenido
                        'Try
                        Sistema.PL.Negocio.EMail.Enviar(oEmail)

                        Dim oEmail2 As New InfoEnvioMail

                        oEmail2.De = EmailAdmin.EmailSupportAccount
                        oEmail2.Para = EmailAdmin.EmailContactAccount
                        'oUsuario.Email.ToString()

                        oEmail2.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Colabora_Titulo_DespliegueNombreAuto")
                        oEmail2.Asunto = System.Configuration.ConfigurationManager.AppSettings("contactenos_Asunto_CorreoAutoConcact") & oUsuario.Nombre.ToString

                        oEmail2.Contenido = oEmail.Contenido
                        Sistema.PL.Negocio.EMail.Enviar(oEmail2)

                        'Catch ex As Exception
                        'Response.Write("<script language = 'javascript'>alert('error2: " + ex.Message.ToString() + " '); </script>")
                        'End Try

                        'MensajedelEnvio.InnerText = strOlvidoCMailRespuestaEnvio
                        'cnt_contentDespuesdeGuardar.Visible = True

                        'Try
                        Response.Redirect("UploadFileThank.aspx")
                        'Catch ex As Exception
                        'Response.Write("<script language = 'javascript'>alert('error3: " + ex.Message.ToString() + " '); </script>")
                        'End Try

                        cnt_contentAntesdeGuardar.Visible = False

                    End If
                Else
                    Response.Write("<script language = 'javascript'>alert('Tipo de Archivo No Permitido! (" + strArchivo.ToString() + ") '); </script>")
                    'Response.Redirect("UploadFileThank.aspx")
                    'cnt_contentAntesdeGuardar.Visible = False

                End If


            Catch ex As Exception
                Response.Write("<script language = 'javascript'>alert('error4: " + ex.Message.ToString() + " '); </script>")
            End Try
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
End Class
