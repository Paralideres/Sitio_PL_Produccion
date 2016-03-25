Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio

Partial Public Class RegisterEdit
    Inherits System.Web.UI.Page
    Dim strParamAutor As String = ""
    Dim ListadoPaises As New List(Of InfoPais)
    Dim ListadoIdiomas As New List(Of InfoIdioma)
    Dim ListadoSexo As New List(Of InfoSexo)
    Dim ListadoTipoTrabajo As New List(Of InfoTipoTrabajo)
    Dim ListadoEstadoCivil As New List(Of InfoEstadoCivil)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strParamAutor = Request.QueryString("Ida").ToString
        Dim oUsuario As New InfoUsuario()

        If (Not IsPostBack) Then
            cnt_contentGuardar.Visible = False
            cnt_contentEditar.Visible = True
            ListadoPaises = Pais.ListarPaises()
            ListadoIdiomas = NegIdioma.ListarIdioma()
            ListadoSexo = NegSexo.ListarSexo()
            ListadoEstadoCivil = NegEstadoCivil.ListarEstadoCivil()
            ListadoTipoTrabajo = NegTipoTrabajo.ListarTipoTrabajo()
            LlenaComboPaises(ListadoPaises)
            LlenaComboSexo(ListadoSexo)
            LlenaComboEstadoCivil(ListadoEstadoCivil)
            LlenaComboTipoTrabajo(ListadoTipoTrabajo)
            LlenaComboIdioma(ListadoIdiomas)
            LlenaComboPaises(ListadoPaises)

            Try

                oUsuario = Usuario.TraerUsuarioCompleto(Convert.ToInt32(strParamAutor))

                lblNombreRegistro.InnerHtml = "<h3> Bienvenido, " & oUsuario.RegNombre & " " & oUsuario.RegApellido & "</h3>"
                FirstName.Value = oUsuario.RegNombre
                LastName.Value = oUsuario.RegApellido
                Clave.Text = oUsuario.Clave
                'Clave.Attributes.Add("value", oUsuario.Clave.ToString())

                Email.Value = oUsuario.Email
                Email2.Value = oUsuario.Email
                strFechaNAC.Value = oUsuario.Bday.ToString("dd/MM/yyyy")

                DDLSexo.SelectedIndex = Convert.ToInt32(oUsuario.Sexo.ToString())
                DDLEstadoCivil.SelectedIndex = Convert.ToInt32(oUsuario.MStatus.ToString())
                DDLTTrabajo.SelectedIndex = Convert.ToInt32(oUsuario.WorkType.ToString())
                DDLIdioma.SelectedItem.Text = oUsuario.MainLanguage.ToString()
                Telefono.Value = oUsuario.Phone.ToString()
                'Perfil.Text = oUsuario.OtherInfo.ToString()
                OtherInfo.InnerHtml = oUsuario.OtherInfo.ToString()

                Country.SelectedValue = Convert.ToInt32(oUsuario.Pais.ToString())
                State.Value = oUsuario.Estado
                City.Value = oUsuario.Ciudad
                ShowInfo.SelectedIndex = Convert.ToInt32(oUsuario.PublicarPerfil.ToString())
                ReceiveEmails.SelectedIndex = Convert.ToInt32(oUsuario.RecibirNoticias.ToString())
                If oUsuario.Cantidad_Publicaciones > 0 Then
                    lblPublicaciones.Visible = True
                    hrefVerPublicaciones.HRef = "Ver_Mis_Publicaciones.aspx?Ida=" & strParamAutor & "&Idp=1"
                End If


            Catch ex As Exception

            End Try


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
    Protected Sub LlenaComboSexo(ByVal Listado As List(Of InfoSexo))
        Dim valor As Integer = 0
        'Establece el primer elemento del combo
        DDLSexo.Items.Add(New ListItem("[Seleccione una opción]", ""))
        For Each Resultado As InfoSexo In Listado
            valor = Convert.ToInt32(Resultado.Id.ToString)
            Dim item As ListItem = New ListItem(Resultado.Nombre.ToString, valor.ToString)
            DDLSexo.Items.Add(item)
        Next
    End Sub
    Protected Sub LlenaComboTipoTrabajo(ByVal Listado As List(Of InfoTipoTrabajo))
        Dim valor As Integer = 0
        'Establece el primer elemento del combo
        DDLTTrabajo.Items.Add(New ListItem("[Seleccione una opción]", ""))
        For Each Resultado As InfoTipoTrabajo In Listado
            valor = Convert.ToInt32(Resultado.Id.ToString)
            Dim item As ListItem = New ListItem(Resultado.Nombre.ToString, valor.ToString)
            DDLTTrabajo.Items.Add(item)
        Next
    End Sub
    Protected Sub LlenaComboIdioma(ByVal Listado As List(Of InfoIdioma))
        Dim valor As Integer = 0
        'Establece el primer elemento del combo
        DDLIdioma.Items.Add(New ListItem("[Seleccione una opción]", ""))
        For Each Resultado As InfoIdioma In Listado
            valor = Convert.ToInt32(Resultado.Id.ToString)
            Dim item As ListItem = New ListItem(Resultado.Nombre.ToString, valor.ToString)
            DDLIdioma.Items.Add(item)
        Next
    End Sub
    Protected Sub LlenaComboEstadoCivil(ByVal Listado As List(Of InfoEstadoCivil))
        Dim valor As Integer = 0
        'Establece el primer elemento del combo
        DDLEstadoCivil.Items.Add(New ListItem("[Seleccione una opción]", ""))
        For Each Resultado As InfoEstadoCivil In Listado
            valor = Convert.ToInt32(Resultado.Id.ToString)
            Dim item As ListItem = New ListItem(Resultado.Nombre.ToString, valor.ToString)
            DDLEstadoCivil.Items.Add(item)
        Next
    End Sub

    Protected Sub btnRegistro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistro.Click
        Dim strmensaje As String = ""
        Dim EmailAdmin As New InfoAdminEmails()
        Dim _Ambiente As String = System.Configuration.ConfigurationManager.AppSettings("PL_ENVIRONMENT")
        Dim oUsuario As New InfoUsuario
        oUsuario.IdUsuario = Convert.ToInt32(strParamAutor.ToString())
        oUsuario.RegNombre = FirstName.Value
        oUsuario.RegApellido = LastName.Value
        oUsuario.Clave = Clave.Text
        oUsuario.Email = Email.Value
        oUsuario.Ciudad = City.Value
        oUsuario.Estado = State.Value
        oUsuario.IdPais = Country.SelectedItem.Value
        oUsuario.PublicarPerfil = ShowInfo.SelectedItem.Value
        oUsuario.RecibirNoticias = ReceiveEmails.SelectedItem.Value
        Try
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




            'If _Ambiente = "PRODUCCION" Then
            '    Dim oEmail As New InfoEnvioMail()
            '    oEmail.De = EmailAdmin.EmailSupportAccount
            '    oEmail.Para = EmailAdmin.EmailDeveloperAccount
            '    oEmail.Asunto = _Ambiente & " Convertir Fecha : " & oUsuario.FechaNac & "  " & oUsuario.Dia & oUsuario.Mes & oUsuario.Anno
            '    oEmail.EsHtml = True
            '    oEmail.DesplieguedelNombre = "Ambiente :  " & _Ambiente
            '    oEmail.Contenido = _Ambiente & "Convertir Fecha : " & oUsuario.FechaNac & "  " & oUsuario.Dia & oUsuario.Mes & oUsuario.Anno & vbCrLf
            '    Sistema.PL.Negocio.EMail.Enviar(oEmail)
            'End If
        Catch ex As Exception

            If _Ambiente = "PRODUCCION" Then
                'Dim oEmail As New InfoEnvioMail()
                'oEmail.De = EmailAdmin.EmailSupportAccount
                'oEmail.Para = EmailAdmin.EmailDeveloperAccount
                'oEmail.Asunto = _Ambiente & " Error Convertir Fecha : " & ex.Message
                'oEmail.EsHtml = True
                'oEmail.DesplieguedelNombre = "Ambiente :  " & _Ambiente
                'oEmail.Contenido = _Ambiente & " Error Convertir Fecha : " & ex.Message & vbCrLf
                'Sistema.PL.Negocio.EMail.Enviar(oEmail)

                Dim oLog As New InfoLog()
                oLog.Descripcion = _Ambiente & "ReggisterEdit.aspx, Error Convertir Fecha : " & ex.Message
                oLog.Error = 0
                oLog.Url = "Error Convertir Fecha "
                AdminLog.RegistrarLog(oLog)
            End If
        End Try
        oUsuario.Sexo = DDLSexo.SelectedItem.Value

        oUsuario.Sexo = DDLSexo.SelectedItem.Value
        oUsuario.MStatus = DDLEstadoCivil.SelectedItem.Value
        oUsuario.WorkType = DDLTTrabajo.SelectedItem.Value
        oUsuario.MainLanguage = DDLIdioma.SelectedItem.Text
        oUsuario.Phone = Telefono.Value
        oUsuario.OtherInfo = OtherInfo.Value


        Dim intID As Integer = 0
        Try
            intID = Usuario.ActualizarUsuario(oUsuario)
            lblNombreRegistro.InnerHtml = "<h3> " & oUsuario.RegNombre & " " & oUsuario.RegApellido & "</h3>"
            cnt_contentGuardar.Visible = True
            cnt_contentEditar.Visible = False
            strmensaje = "Actualiza Usuario"
        Catch ex As Exception
            strmensaje = "No Actualiza Usuario"
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
    Protected Sub Clave_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Clave.PreRender
        Clave.Attributes("value") = Clave.Text
    End Sub
End Class
