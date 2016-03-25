Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Libreria.QueryString
Imports System.IO
Imports ParaLideres

Partial Public Class Register
    Inherits System.Web.UI.Page
    Dim ListadoPaises As New List(Of InfoPais)
    Dim strMensajeNoRegistrado As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("MensajeNoRegistrado"))
    Dim oUsuario As New InfoUsuario()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            ListadoPaises = Pais.ListarPaises()
            LlenaComboPaises(ListadoPaises)
            Dim intImageNumber = Funcion.GetRandomNumber(10000, 99999)
            'imgCaptchaReg.Src = "CaptchaImage.aspx?x=" & intImageNumber
            imgCaptchaReg.Src = "CreateCaptcha.aspx?New=" & intImageNumber
            HttpContext.Current.Session("Captcha") = intImageNumber
        End If

        Dim strparametro As String = "1"
        Try
            strparametro = Request.QueryString("Registrado").ToString
        Catch ex As Exception
        End Try



        If strparametro = 0 Then 'VIENE DE TRATAR DE SUBIR ARCHIVO PERO NO ESTA REGISTRADO
            oUsuario = Session("UsuarioConectado")

            If oUsuario Is Nothing Then
                Response.Write("<script language = 'javascript'>alert('" & strMensajeNoRegistrado & "'); </script>")

            End If
        End If

    End Sub
    Protected Sub LlenaComboPaises(ByVal Listado As List(Of InfoPais))
        Dim valor As Integer = 0
        'Establece el primer elemento del combo
        Country.Items.Add(New ListItem("[Seleccione una opción]", ""))
        For Each Resultado As InfoPais In Listado
            valor = Convert.ToInt32(Resultado.Id.ToString)
            Dim item As ListItem = New ListItem(Resultado.Nombre.ToString, valor.ToString)
            Country.Items.Add(item)
        Next
    End Sub

    Protected Sub btnRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistro.Click
        Dim strmensaje As String = ""
        Dim EmailAdmin As New InfoAdminEmails()
        Try
            Dim boCaptchaOk As Boolean = False
            'Dim intCaptcha As Integer = Convert.ToInt32(HttpContext.Current.Session("Captcha"))
            Dim _Ambiente As String = System.Configuration.ConfigurationManager.AppSettings("PL_ENVIRONMENT")
            Dim strintruduceCaptcha As String = txtImagenCaptchaReg.Value
            If strintruduceCaptcha <> "" Then
                If Session("CaptchaCode") IsNot Nothing AndAlso _
                    txtImagenCaptchaReg.Value.ToString() = Session("CaptchaCode").ToString() Then
                    boCaptchaOk = True

                Else
                    boCaptchaOk = False
                    'LblImagenCaptchaRerPersonal.Visible = True
                    'LblImagenCaptchaRerPersonal.InnerText = "Código Captcha erroneo, intentelo nuevamente!!"
                End If


                If boCaptchaOk = True Then
                    Dim oUsuario As New InfoUsuario
                    oUsuario.RegNombre = FirstName.Value
                    oUsuario.RegApellido = LastName.Value
                    oUsuario.Clave = Clave.Value
                    oUsuario.Email = Email.Value
                    oUsuario.Ciudad = City.Value
                    oUsuario.Estado = State.Value
                    oUsuario.IdPais = Country.SelectedItem.Value
                    oUsuario.PublicarPerfil = ShowInfo.SelectedItem.Value
                    oUsuario.RecibirNoticias = ReceiveEmails.SelectedItem.Value
                    oUsuario.EstadoUsuario = 0 'Inactivo
                    oUsuario.SecurityLevel = 7 'Inactivo
                    oUsuario.Bday = "01-01-1900"

                    Try
                        If Sistema.PL.Negocio.Usuario.ExisteUsuarioConMismoEmail(oUsuario.Email) > 0 Then
                            strmensaje = "Su E-mail :" & oUsuario.Email.ToString() & " ya se encuentra resgistrado en nuestra base de datos, Favor de ir a recurperar contraseña ingresando su E-mail"
                            Response.Write("<script language = 'javascript'>alert('" & strmensaje & "'); </script>")
                            Exit Sub
                        End If

                    Catch ex As Exception

                    End Try


                    Try
                        'oUsuario.Bday = strFechaNAC.Value.ToString.Replace("/", "-") '"01-01-1900"
                        Dim strTxtFechaNac = strFechaNAC.Value.ToString

                        Dim anio As String '= cadena.substring(0, 4)
                        Dim mes As String '= cadena.substring(3, 2)
                        Dim dia As String '= cadena.substring(5, 2)
                        dia = Now().Day.ToString
                        mes = Now().Month.ToString
                        anio = Now().Year.ToString

                        Dim strSplitFecha As String()

                        If strTxtFechaNac.IndexOf("/") > 0 Then
                            strSplitFecha = strTxtFechaNac.Split("/")
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
                        ElseIf strTxtFechaNac.IndexOf("-") > 0 Then
                            strSplitFecha = strTxtFechaNac.Split("-")
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

                        oUsuario.Dia = agregaCeroaIzq(dia)
                        oUsuario.Mes = agregaCeroaIzq(mes)
                        oUsuario.Anno = anio
                        oUsuario.FechaNac = strTxtFechaNac.Trim

                    Catch ex As Exception

                        If _Ambiente = "PRODUCCION" Then
                            'Dim oEmail As New InfoEnvioMail()
                            'oEmail.De = EmailAdmin.EmailSupportAccount
                            'oEmail.Para = EmailAdmin.EmailDeveloperAccount
                            'oEmail.Asunto = _Ambiente & " Error Convertir Fecha : " & ex.Message
                            'oEmail.EsHtml = True
                            'oEmail.DesplieguedelNombre = "Ambiente :  " & _Ambiente
                            'oEmail.Contenido = _Ambiente & " Error Convertir Fecha : " & ex.Message & vbCrLf

                            Dim oLog As New InfoLog()
                            oLog.Descripcion = _Ambiente & " Error Convertir Fecha : " & ex.Message
                            oLog.Error = 0
                            oLog.Url = "Error Convertir Fecha "
                            AdminLog.RegistrarLog(oLog)

                            'Sistema.PL.Negocio.EMail.Enviar(oEmail)
                        End If
                    End Try


                    Dim intID As Integer = 0
                    Try
                        intID = Usuario.RegistrarUsuario(oUsuario)



                        strmensaje = "Registra Usuario"
                        Dim oLog As New InfoLog()
                        oLog.Descripcion = "Si Registra Usuario, Datos : " & oUsuario.RegNombre.ToString & ", " & oUsuario.RegApellido & ", " & oUsuario.Clave & ", " & oUsuario.Email & ", " & oUsuario.Ciudad & ", " & oUsuario.Estado & ", " & oUsuario.IdPais & ", " & oUsuario.PublicarPerfil & ", " & oUsuario.RecibirNoticias & ", " & oUsuario.EstadoUsuario & ", " & oUsuario.SecurityLevel & ", " & oUsuario.Bday & ", " & oUsuario.FechaNac
                        oLog.Error = 1
                        oLog.Url = "Register.aspx"
                        AdminLog.RegistrarLog(oLog)
                    Catch ex As Exception
                        strmensaje = "No Registra Usuario"
                        Dim oLog As New InfoLog()
                        oLog.Descripcion = strmensaje & ", " & ex.Message & ", Datos : " & oUsuario.RegNombre.ToString & ", " & oUsuario.RegApellido & ", " & oUsuario.Clave & ", " & oUsuario.Email & ", " & oUsuario.Ciudad & ", " & oUsuario.Estado & ", " & oUsuario.IdPais & ", " & oUsuario.PublicarPerfil & ", " & oUsuario.RecibirNoticias & ", " & oUsuario.EstadoUsuario & ", " & oUsuario.SecurityLevel & ", " & oUsuario.Bday & ", " & oUsuario.FechaNac
                        oLog.Error = 2
                        oLog.Url = "Register.aspx"
                        AdminLog.RegistrarLog(oLog)

                    End Try

                    If intID > 0 Then

                        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
                        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
                        Dim strAnio As String = Now().Year.ToString

                        Dim oEmail As New InfoEnvioMail
                        Dim StrNombreUsuario As String = oUsuario.RegNombre & " " & oUsuario.RegApellido
                        Dim StrPassword As String = Clave.Value
                        Dim strUrl As String
                        Dim project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath")
                        oEmail.De = EmailAdmin.EmailSupportAccount
                        oEmail.Para = Email.Value
                        oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("DespliegueNombreAuto")
                        oEmail.Asunto = System.Configuration.ConfigurationManager.AppSettings("AsuntoCorreoAuto") '"Bienvenido a ParaLideres"
                        strUrl = "http://" & HttpContext.Current.Request.ServerVariables("HTTP_HOST")
                        'sb.Append("<p align=""center""><a href=" & strUrl & project_path & "Register.aspx>Activar</a></p>")
                        Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)
                        valores.Add("ID_USU", intID.ToString)
                        valores.Add("Nombre", oUsuario.RegNombre.ToString)
                        valores.Add("Apellido", oUsuario.RegApellido.ToString)
                        valores.Add("Clave", Clave.Value.ToString)
                        valores.Add("Hoy", strAnio & strMes & strDia)


                        'Dim QS As New QueryString("")
                        Dim strUrlActivar As String = ""
                        Try
                            Dim QS = New QueryString(valores)
                            strmensaje = "encripta"

                            strUrlActivar = strUrl & project_path & "ActiveAccount.aspx?action=" & QS.QSEncriptada.ToString
                        Catch ex As Exception
                            strmensaje = "No encripta"
                        End Try




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

                    End If

                    Response.Redirect("RegisterOK.aspx")
                Else
                    LblImagenCaptchaRerPersonal.Visible = True
                    LblImagenCaptchaRerPersonal.InnerText = "Código Captcha erroneo, intentelo nuevamente!!" '"Número ingresado es distinto a la imagen"
                End If
            Else
                LblImagenCaptchaRerPersonal.Visible = True
                LblImagenCaptchaRerPersonal.InnerText = "* Obligatorio"
            End If


        Catch ex As Exception
            Response.Write(ex.Message & " Decripcion: " & strmensaje)
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