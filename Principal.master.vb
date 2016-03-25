

Imports System.Data
'Imports Sistema.PL.ParaLideres.GenericDataHandler
Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Sistema.PL.Negocio.Util
Imports System.Web.Services


Partial Public Class Principal
    Inherits System.Web.UI.MasterPage
    Dim intEtiqueta_Tipo_Font1 As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_Tipo_Font1"))
    Dim intEtiqueta_Tipo_Font2 As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_Tipo_Font2"))
    Dim intEtiqueta_Listado_Maximo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_Listado_Maximo"))
    Dim intListaMaximoPiePagina As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoListaPiePagina"))
    Dim intMaximoCaract As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterMenu"))
    Dim strListaMenuConfig As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaMENU"))
    Dim strListaTipoBotonConfig As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaBotonMENU"))
    Dim strMensajeAlResponder As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("MensajeAlResponder"))
    Dim strMensajeEsperandoNuevaPregunta As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("MensajeEsperandoNuevaPregunta"))
    Dim intEtiqueta_ValorMasUsado As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_ValorMasUsado"))
    Dim strUrlComunidad As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("UrlComunidad"))
    Dim strUrlMENU_Curso As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaMENU_Curso"))
    Dim strMENU_Curso As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaMENU_Curso"))
    Dim strPaginaMENU_Curso As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("PaginaMENU_Curso"))

    Dim oUsuario As New InfoUsuario()
    Dim ListadoEtiqueta As New List(Of InfoEtiqueta)
    Dim strListaEtiqueta As String
    Dim oPregunta As New InfoPregunta
    Dim strIpAddress As String
    Dim strUrlPrincipal As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("UrlWeb"))


    Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPrincipal"))
    Dim intTiempoEt As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEtiquetas"))
    Dim intTiempoPiePag As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPiePagina"))
    Dim intTiempoEnc As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEncuesta"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Expires As DateTime
        strIpAddress = Request.UserHostAddress()
        Dim ListadoMenu As New List(Of InfoMenu)

        Dim ListadoRecursos As New List(Of InfoSeccionPadre)
        Expires = DateAdd(DateInterval.Day, intTiempo, Now)
        ListadoMenu = CType(Cache("MiListadoMenu"), List(Of InfoMenu))

        If Cache("MiListadoMenu") Is Nothing Then
            ListadoMenu = MenuPL.BuscarMenuPrincipal()
            Cache.Insert("MiListadoMenu", ListadoMenu, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If



        Expires = DateAdd(DateInterval.Day, intTiempoPiePag, Now)

        ListadoRecursos = CType(Cache("ListadoRecursoPiePag"), List(Of InfoSeccionPadre))

        If Cache("ListadoRecursoPiePag") Is Nothing Then
            ListadoRecursos = NegSeccion.BuscarSeccionRecursos("Recursos")
            Cache.Insert("ListadoRecursoPiePag", ListadoRecursos, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If




        hrefLogo.HRef = strUrlPrincipal

        Expires = DateAdd(DateInterval.Minute, intTiempoEnc, Now)
        'ListadoEtiqueta = CType(Cache("ListadoEtiqueta"), List(Of InfoEtiqueta))
        oPregunta = CType(Cache("Pregunta"), InfoPregunta)

        If HttpRuntime.Cache("Pregunta") Is Nothing Then
            oPregunta = Pregunta.TraerPreguntaActual()
            HttpRuntime.Cache.Insert("Pregunta", oPregunta, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If

        'HidIdPg.Value = oPregunta.Id_Pregunta




        ''========================================================
        '' Si es la 1� carga de la pagina (Si no es PostBack)
        ''========================================================
        If Not IsPostBack Then

            ValidarUsuario()

            CargarPregunta()
            listarTablaMenu(ListadoMenu)
            'ListarEtiqueta(ListadoEtiqueta)
            listarTablaRecursos(ListadoRecursos)

        End If









    End Sub

    Sub listarTablaMenu(ByVal Listado As List(Of InfoMenu))


        '<ul>
        '    <li><a href="#" id="rec_btn">RECURSOS</a></li>
        '    <li><a href="#" id="cap_btn">CAPACITACI&Oacute;N</a></li>
        '    <li><a href="#" id="com_btn">COMUNIDAD</a></li>
        '</ul>


        Dim strHtml_UL_Inicial As String = "<ul>"
        Dim strHtml_UL_Final As String = "</ul>"
        Dim strHtml_LI_Inicial As String = "<li>"
        Dim strHtml_LI_Final As String = "</li>"

        'Dim strHtml_Ahref_Inicial As String = "<a href="
        Dim strHtml_Ahref_Inicial As String = "<a "
        'Dim strHtml_Ahref_Inicial_Cap As String = "<a href="
        Dim strHtml_Ahref_Inicial_Com As String = "<a href="
        Dim strHtml_Ahref_Final As String = "</a>"

        Dim strHtml_Interno_Encabezado As String = ""
        Dim strHtml_Interno_Detalle As String = ""
        Dim strHtml_Final As String = ""
        Dim intIndex As Integer = 1
        Dim intCantidadPadres As Integer

        Dim strListaMenu As String() = strListaMenuConfig.ToString.Split(",")
        Dim strListaTipoBoton As String() = strListaTipoBotonConfig.ToString.Split(",")
        Dim boEncontrado As Boolean = False
        intCantidadPadres = Listado.Count

        For Each resultadoMenu As InfoMenu In Listado
            Dim oListadoPadre As New List(Of InfoSeccionPadre)
            oListadoPadre = resultadoMenu.Padres
            ''strHtml_UL_Inicial
            For intIndex = 0 To strListaMenu.Length - 1
                If strListaMenu(intIndex).ToString.ToUpper = resultadoMenu.Descripcion.ToUpper Then

                    If resultadoMenu.Descripcion.ToUpper = "COMUNIDAD" Then

                        strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial_Com & "'" & strUrlComunidad & "' id='" & strListaTipoBoton(intIndex) & "' target='_blank'>" & resultadoMenu.Descripcion.ToUpper & strHtml_Ahref_Final & strHtml_UL_Inicial
                    Else
                        strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial & " id='" & strListaTipoBoton(intIndex) & "' >" & resultadoMenu.Descripcion.ToUpper & strHtml_Ahref_Final & strHtml_UL_Inicial

                    End If

                    boEncontrado = True
                    Exit For

                End If

            Next
            If boEncontrado Then
                strHtml_Final = strHtml_Final & strHtml_Interno_Encabezado & recorrerListado(oListadoPadre) & strHtml_UL_Final & strHtml_LI_Final
                boEncontrado = False
            End If


        Next
        If strListaMenu.Length > intCantidadPadres Then
            strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial & " id='" & strListaTipoBoton(strListaMenu.Length - 1) & "' >" & strListaMenu(strListaMenu.Length - 1).ToString.ToUpper & strHtml_Ahref_Final & strHtml_LI_Final
            strHtml_Final = strHtml_Final & strHtml_Interno_Encabezado
        End If

        menu_bar.InnerHtml = strHtml_UL_Inicial & strHtml_Final & strHtml_UL_Final
    End Sub

    Function recorrerListado(ByVal oListadoPadre As List(Of InfoSeccionPadre)) As String
        Dim strHtml_UL_Inicial As String = "<ul>"
        Dim strHtml_UL__Final As String = "</ul>"
        Dim strHtml_LI_Inicial As String = "<li>"
        Dim strHtml_LI_Final As String = "</li>"

        'Dim strHtml_Ahref_Inicial As String = "<a href="
        Dim strHtml_Ahref_Inicial As String = "<a "
        Dim strHtml_Ahref_Inicial_cap As String = "<a href="
        Dim strHtml_Ahref_Final As String = "</a>"

        Dim strHtml_Interno_Encabezado As String = ""
        Dim strHtml_Interno_Detalle As String = ""
        Dim strHtml_Final As String = ""
        Dim intIndex As Integer = 1
        'Cursos.aspx
        For Each resultadoPadres As InfoSeccionPadre In oListadoPadre

            If intIndex > 1 Then
                strHtml_Final = strHtml_Final & strHtml_Interno_Encabezado
            End If
            strHtml_Interno_Encabezado = ""
            strHtml_Interno_Detalle = ""
            If resultadoPadres.Hijos.Count > 0 Then
                'Dim valores As Dictionary(Of String, String) = New Dictionary(Of String, String)
                'resultadoPadres.    

                strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial & " onclick=IraSeccion('" & resultadoPadres.IdMenu & "') >" & resultadoPadres.Descripcion & strHtml_Ahref_Final & strHtml_UL_Inicial

                Dim oListadoHijos As New List(Of InfoSeccionHijos)
                oListadoHijos = resultadoPadres.Hijos
                For Each resultadoHijos As InfoSeccionHijos In oListadoHijos
                    strHtml_Interno_Detalle = strHtml_Interno_Detalle & strHtml_LI_Inicial & strHtml_Ahref_Inicial & " onclick=IraSeccion('" & resultadoHijos.IdMenu & "') >" & resultadoHijos.Descripcion & strHtml_Ahref_Final & strHtml_LI_Final
                Next
                strHtml_Interno_Encabezado = strHtml_Interno_Encabezado & strHtml_Interno_Detalle & strHtml_UL__Final & strHtml_LI_Final
            Else
                'PaginaMENU_Curso

                If strMENU_Curso.ToString.ToUpper() = resultadoPadres.Descripcion.ToString.ToUpper Then
                    strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial_cap & "'" & strPaginaMENU_Curso.ToString & "' >" & resultadoPadres.Descripcion & strHtml_Ahref_Final & strHtml_LI_Final
                Else
                    strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial & " onclick=IraSeccion('" & resultadoPadres.IdMenu & "') >" & resultadoPadres.Descripcion & strHtml_Ahref_Final & strHtml_LI_Final
                End If


            End If
            intIndex = intIndex + 1
        Next
        If intIndex > 1 Then
            strHtml_Final = strHtml_Final & strHtml_Interno_Encabezado
        End If

        Return strHtml_Final
    End Function




    Sub ValidarUsuario()
        oUsuario = Session("UsuarioConectado")

        If oUsuario Is Nothing Then
            Div_con_Usuario_Bienvenido.Visible = False
            Div_con_Usuario_salir.Visible = False
            Div_sin_Usuario_Reg.Visible = True
            Div_sin_Usuario_Entrar.Visible = True

        Else
            If oUsuario.Encontrado = True Then
                lblUsuario.InnerText = oUsuario.Nombre
                userbox_profile_link.HRef = "RegisterEdit.aspx?Ida=" & oUsuario.IdUsuario.ToString
                Div_con_Usuario_Bienvenido.Visible = True
                Div_con_Usuario_salir.Visible = True
                Div_sin_Usuario_Reg.Visible = False
                Div_sin_Usuario_Entrar.Visible = False

            Else
                Div_con_Usuario_Bienvenido.Visible = False
                Div_con_Usuario_salir.Visible = False
                Div_sin_Usuario_Reg.Visible = True
                Div_sin_Usuario_Entrar.Visible = True
            End If
        End If
    End Sub

    Sub ListarEtiqueta(ByVal ListadoHtml As String)

    End Sub

    'Sub ListarEtiqueta(ByVal Listado As List(Of InfoEtiqueta))

    '    Dim intIndice As Integer = 0
    '    Dim intX As Integer = 0
    '    Dim oListadoEtiquetas As New List(Of String)
    '    Dim oListadoCantidadXEtiquetas As New List(Of String)

    '    For Each resultado As InfoEtiqueta In Listado
    '        Dim strEtiquetas As String()
    '        strEtiquetas = resultado.Etiqueta.Split(" ")
    '        If oListadoEtiquetas.Count < intEtiqueta_Listado_Maximo Then
    '            For intX = 0 To strEtiquetas.Length - 1
    '                If oListadoEtiquetas.Count < intEtiqueta_Listado_Maximo Then
    '                    If strEtiquetas(intX).Length > 0 Then
    '                        oListadoEtiquetas.Add(strEtiquetas(intX))
    '                    End If
    '                Else
    '                    Exit For
    '                End If

    '            Next
    '        Else
    '            Exit For
    '        End If
    '    Next


    '    For Each resultado As InfoEtiqueta In Listado
    '        Dim strEtiquetas As String()
    '        strEtiquetas = resultado.MasUsoTag.Split("|")
    '        If oListadoCantidadXEtiquetas.Count < intEtiqueta_Listado_Maximo Then
    '            For intX = 0 To strEtiquetas.Length - 1
    '                If oListadoCantidadXEtiquetas.Count < intEtiqueta_Listado_Maximo Then
    '                    If strEtiquetas(intX).Length > 0 Then
    '                        oListadoCantidadXEtiquetas.Add(strEtiquetas(intX))
    '                    End If
    '                Else
    '                    Exit For
    '                End If

    '            Next
    '        Else
    '            Exit For
    '        End If
    '    Next


    '    Dim strHtml_Font1 As String
    '    Dim strHtml_Font2 As String
    '    Dim strHtml_2 As String
    '    Dim strHtml_3 As String
    '    Dim strHtml_Completo As String = ""
    '    'strHtml_Font1 = "<span><a style='font-size:" + intEtiqueta_Tipo_Font1.ToString() + "px;' href='#' onclick=IraEtiqueta('"
    '    'strHtml_Font2 = "<span><a style='font-size:" + intEtiqueta_Tipo_Font2.ToString() + "px;' href='#' onclick=IraEtiqueta('"
    '    strHtml_Font1 = "<span><a style='font-size:" + intEtiqueta_Tipo_Font1.ToString() + "px;' onclick=IraEtiqueta('"
    '    strHtml_Font2 = "<span><a style='font-size:" + intEtiqueta_Tipo_Font2.ToString() + "px;' onclick=IraEtiqueta('"

    '    strHtml_2 = "')> "
    '    strHtml_3 = " </a> " & " " & " </span>"

    '    Dim intIndiceX As Integer = 0
    '    For Each resultado As String In oListadoEtiquetas
    '        Dim strHtml_Interno As String = ""
    '        intIndice = intIndice + 1
    '        If (intIndice Mod 2) = 0 Then

    '            If oListadoCantidadXEtiquetas(intIndiceX) > intEtiqueta_ValorMasUsado Then
    '                strHtml_Interno = strHtml_Font2 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
    '            Else
    '                strHtml_Interno = strHtml_Font1 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
    '            End If
    '        Else
    '            If oListadoCantidadXEtiquetas(intIndiceX) > intEtiqueta_ValorMasUsado Then
    '                strHtml_Interno = strHtml_Font2 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
    '            Else
    '                strHtml_Interno = strHtml_Font1 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
    '            End If
    '        End If
    '        strHtml_Completo = strHtml_Completo & strHtml_Interno
    '        intIndiceX = intIndiceX + 1
    '    Next


    '    Dim rowMenu As New TableRow()
    '    rowMenu.Cells.Add(Html.CrearCelda("100%", strHtml_Completo.ToString(), HorizontalAlign.Left, ""))
    '    Me.tblResultadoEtiquetas.Rows.Add(rowMenu)

    'End Sub

    Sub listarTablaRecursos(ByVal Listado As List(Of InfoSeccionPadre))

        Dim intIndice As Integer = 0
        Dim intX As Integer = 0
        Dim oListadoEtiquetas As New List(Of String)


        '<div class="ft_content">
        '        	<div class="ft_sitemap_col clearfix">
        '                <ul>
        '                	<li>RECURSOS</li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                </ul>
        '            </div>
        '            <div class="ft_sitemap_col clearfix">
        '                <ul>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                </ul>
        '            </div>
        '            <div class="ft_sitemap_col clearfix">
        '                <ul>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                    <li><a href="#1">Link</a></li>
        '                </ul>
        '            </div>
        '        </div>




        Dim strHtml_ul_Inicial As String = "<ul>"
        Dim strHtml_ul_Final As String = "</ul>"
        Dim strHtml_li_Titulo_Inicial As String = "<li class='Titulo'>"
        Dim strHtml_li_Titulo_Final As String = "</li>"
        Dim strHtml_li_Normal_Inicial As String = "<li>"
        Dim strHtml_li_Normal_Final As String = "</li>"
        Dim strHtml_href_Normal_Inicial As String = "<a href='#'"
        Dim strHtml_href_Normal_Final As String = "</a>"
        Dim strHtml_Interno_Encabezado As String = ""
        Dim strHtml_Interno_Detalle As String = ""

        Dim strHtml_Completo1 As String = ""
        Dim strHtml_Completo2 As String = ""
        Dim strHtml_Completo3 As String = ""

        Dim intPadreActual As Integer = 0
        Dim intPadreAnterior As Integer = 0
        Dim boTagAbierto As Boolean = False
        Dim intNumColumna As Integer = 1
        For Each resultado As InfoSeccionPadre In Listado
            intPadreAnterior = resultado.IdPadre

            If intPadreActual <> intPadreAnterior And resultado.Tipo = 1 Then ' es Padre
                If boTagAbierto = True Then
                    strHtml_Interno_Encabezado = strHtml_Interno_Encabezado & strHtml_Interno_Detalle & strHtml_ul_Final
                    If intNumColumna = 1 Then
                        strHtml_Completo1 = strHtml_Completo1 & strHtml_Interno_Encabezado
                        intNumColumna = intNumColumna + 1
                    ElseIf intNumColumna = 2 Then
                        strHtml_Completo2 = strHtml_Completo2 & strHtml_Interno_Encabezado
                        intNumColumna = intNumColumna + 1
                    ElseIf intNumColumna = 3 Then
                        strHtml_Completo3 = strHtml_Completo3 & strHtml_Interno_Encabezado
                        intNumColumna = 1
                    End If

                    strHtml_Interno_Detalle = ""
                    boTagAbierto = False
                End If
                strHtml_Interno_Encabezado = ""
                strHtml_Interno_Encabezado = strHtml_Interno_Encabezado & strHtml_ul_Inicial & strHtml_li_Titulo_Inicial & strHtml_href_Normal_Inicial & " onclick=IraSeccion('" & resultado.IdMenu.ToString() & "')>" & resultado.Descripcion.ToString() & strHtml_li_Titulo_Final
                intPadreActual = resultado.IdMenu
                boTagAbierto = True

            ElseIf intPadreActual = intPadreAnterior And resultado.Tipo = 2 Then 'hijos
                strHtml_Interno_Detalle = strHtml_Interno_Detalle & strHtml_li_Normal_Inicial & strHtml_href_Normal_Inicial & " onclick=IraSeccion('" & resultado.IdMenu.ToString() & "')>" & resultado.Descripcion.ToString() & strHtml_href_Normal_Final & strHtml_li_Normal_Final
            End If


        Next

        If boTagAbierto = True Then
            strHtml_Interno_Encabezado = strHtml_Interno_Encabezado & strHtml_Interno_Detalle & strHtml_ul_Final
            If intNumColumna = 1 Then
                strHtml_Completo1 = strHtml_Completo1 & strHtml_Interno_Encabezado
                intNumColumna = intNumColumna + 1
            ElseIf intNumColumna = 2 Then
                strHtml_Completo2 = strHtml_Completo2 & strHtml_Interno_Encabezado
                intNumColumna = intNumColumna + 1
            ElseIf intNumColumna = 3 Then
                strHtml_Completo3 = strHtml_Completo3 & strHtml_Interno_Encabezado
                intNumColumna = 1
            End If

            strHtml_Interno_Detalle = ""
            boTagAbierto = False
        End If

        RecursosColumna1.InnerHtml = strHtml_Completo1
        RecursosColumna2.InnerHtml = strHtml_Completo2
        RecursosColumna3.InnerHtml = strHtml_Completo3

    End Sub

    Sub CargarPregunta()

        
        lblPregunta.InnerHtml = oPregunta.Titulo_Pregunta.ToString()
        aVerResultado.HRef = "ResultadoEncuesta.aspx?IdPr=" & oPregunta.Id_Pregunta.ToString()
        If Respuesta.EstaRespondidaLaPregunta(oPregunta.Id_Pregunta, strIpAddress) Then
            MostrarPreguntas.Visible = False
            MostrarAgradecimiento.Visible = True
            MensajePersonalizado.InnerHtml = strMensajeEsperandoNuevaPregunta
        Else
            MostrarPreguntas.Visible = True
            MostrarAgradecimiento.Visible = False


            If oPregunta.Respuesta_Opcion_1.ToString().Length > 0 Then
                sv_radio_opt_1.Text = oPregunta.Respuesta_Opcion_1.ToString()
                sv_radio_opt_1.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_2.ToString().Length > 0 Then
                sv_radio_opt_2.Text = oPregunta.Respuesta_Opcion_2.ToString()
                sv_radio_opt_2.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_3.ToString().Length > 0 Then
                sv_radio_opt_3.Text = oPregunta.Respuesta_Opcion_3.ToString()
                sv_radio_opt_3.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_4.ToString().Length > 0 Then
                sv_radio_opt_4.Text = oPregunta.Respuesta_Opcion_4.ToString()
                sv_radio_opt_4.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_5.ToString().Length > 0 Then
                sv_radio_opt_5.Text = oPregunta.Respuesta_Opcion_5.ToString()
                sv_radio_opt_5.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_6.ToString().Length > 0 Then
                sv_radio_opt_6.Text = oPregunta.Respuesta_Opcion_6.ToString()
                sv_radio_opt_6.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_7.ToString().Length > 0 Then
                sv_radio_opt_7.Text = oPregunta.Respuesta_Opcion_7.ToString()
                sv_radio_opt_7.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_8.ToString().Length > 0 Then
                sv_radio_opt_8.Text = oPregunta.Respuesta_Opcion_8.ToString()
                sv_radio_opt_8.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_9.ToString().Length > 0 Then
                sv_radio_opt_9.Text = oPregunta.Respuesta_Opcion_9.ToString()
                sv_radio_opt_9.Visible = True
            End If
            If oPregunta.Respuesta_Opcion_10.ToString().Length > 0 Then
                sv_radio_opt_10.Text = oPregunta.Respuesta_Opcion_10.ToString()
                sv_radio_opt_10.Visible = True
            End If
        End If






    End Sub






    Protected Sub LBtnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnCerrar.Click
        'Session.Abandon()
        Session.Contents.RemoveAll()
        Response.Redirect("~/Default.aspx")
    End Sub

    Protected Sub LbtnValidarLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbtnValidarLogin.Click


    End Sub

    Protected Sub BtnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOK.Click

        oUsuario = Usuario.TraerUsuario(txtEmail.Value.ToString(), txtClave.Text.ToString())
        If oUsuario.Encontrado Then
            If oUsuario.EstadoUsuario = 1 Then
                Session("UsuarioConectado") = oUsuario
                Response.Redirect("Logged.aspx")
            ElseIf oUsuario.EstadoUsuario = 0 Then
                lblError.InnerText = "Usuario no esta activo!"
                hidMostrarLogin.Value = "1"
                txtEmail.Focus()
            ElseIf oUsuario.EstadoUsuario > 1 Then
                lblError.InnerText = "Usuario no esta desactivado!, por favor comuniquese con nosotros por Email"
                hidMostrarLogin.Value = "1"
                txtEmail.Focus()
            End If
        Else
            lblError.InnerText = "Verifique Email y clave."
            hidMostrarLogin.Value = "1"
            txtEmail.Focus()
        End If







    End Sub

    Protected Sub LinkbSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkbSalir.Click
        Session.Contents.RemoveAll()
        Response.Redirect("~/Default.aspx")
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim strPalabra As String = search_txt_input.Value.ToString()

        If strPalabra.Length > 3 And (strPalabra.ToString() <> "   " Or strPalabra.ToString() <> "  " Or strPalabra.ToString() <> " ") Then
            Response.Redirect("Search.aspx?Palabra=" & strPalabra & "&Pag=1")
        Else
            Response.Write("<script language = 'javascript'>alert('Debe ingresar alguna palabra, que tenga minimo 4 letras'); </script>")
        End If

    End Sub



    Protected Sub btnVotarPregunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVotarPregunta.Click
        Dim oRespuesta As New InfoRespuesta
        oRespuesta.IpAddress = strIpAddress

        oRespuesta.Id_Pregunta = oPregunta.Id_Pregunta
        Dim boHayRespuesta As Boolean = False
        If sv_radio_opt_1.Checked Then
            oRespuesta.Respuesta_1 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_2.Checked Then
            oRespuesta.Respuesta_2 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_3.Checked Then
            oRespuesta.Respuesta_3 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_4.Checked Then
            oRespuesta.Respuesta_4 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_5.Checked Then
            oRespuesta.Respuesta_5 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_6.Checked Then
            oRespuesta.Respuesta_6 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_7.Checked Then
            oRespuesta.Respuesta_7 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_8.Checked Then
            oRespuesta.Respuesta_8 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_9.Checked Then
            oRespuesta.Respuesta_9 = 1
            boHayRespuesta = True
        ElseIf sv_radio_opt_10.Checked Then
            oRespuesta.Respuesta_10 = 1
            boHayRespuesta = True
        End If

        If boHayRespuesta = True Then
            If Respuesta.InsertarRespuesta(oRespuesta) Then
                MostrarPreguntas.Visible = False
                MostrarAgradecimiento.Visible = True
                MensajePersonalizado.InnerHtml = strMensajeAlResponder

            End If
        Else
            Response.Write("<script language = 'javascript'>alert('Debe ingresar seleccionar alguna respuesta'); </script>")
        End If



    End Sub


End Class

