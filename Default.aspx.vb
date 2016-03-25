Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.Web.Services

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Dim oUsuario As New InfoUsuario()
    Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPrincipal"))
    Dim intTiempoEt As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEtiquetas"))
    Dim intTiempoPiePag As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPiePagina"))
    Dim intTiempoEnc As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEncuesta"))
    Dim intParamSiUsaMin_Dia As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("intParamSiUsaMin_Dia"))
    Dim intTiempoEncMin As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEncuestaMinutos"))


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Expires As DateTime
        If (Not IsPostBack) Then
            oUsuario = Session("UsuarioConectado")

            Expires = DateAdd(DateInterval.Day, intTiempo, Now)
            Dim ListadoMenu As New List(Of InfoMenu)
            ListadoMenu = CType(Cache("MiListadoMenu"), List(Of InfoMenu))

            If Cache("MiListadoMenu") Is Nothing Then
                ListadoMenu = MenuPL.BuscarMenuPrincipal()
                Cache.Insert("MiListadoMenu", ListadoMenu, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            End If

            '' ''Expires = DateAdd(DateInterval.Day, intTiempoEt, Now)
            '' ''Dim ListadoEtiqueta As New List(Of InfoEtiqueta)
            '' ''ListadoEtiqueta = CType(Cache("ListadoEtiqueta"), List(Of InfoEtiqueta))
            '' ''If Cache("ListadoEtiqueta") Is Nothing Then
            '' ''    ListadoEtiqueta = Etiqueta.BuscarEtiquetas()
            '' ''    Cache.Insert("ListadoEtiqueta", ListadoEtiqueta, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            '' ''End If


            Dim oPregunta As New InfoPregunta

            'Expires = DateAdd(DateInterval.Day, intTiempoEnc, Now)

            If intParamSiUsaMin_Dia = 1 Then
                Expires = DateAdd(DateInterval.Minute, intTiempoEncMin, Now)
            Else
                Expires = DateAdd(DateInterval.Day, intTiempoEnc, Now)
            End If

            oPregunta = CType(HttpRuntime.Cache("Pregunta"), InfoPregunta)

            If HttpRuntime.Cache("Pregunta") Is Nothing Then
                oPregunta = Pregunta.TraerPreguntaActual()
                HttpRuntime.Cache.Insert("Pregunta", oPregunta, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            End If



            Expires = DateAdd(DateInterval.Day, intTiempoPiePag, Now)

            Dim ListadoRecursosPie As New List(Of InfoSeccionPadre)
            ListadoRecursosPie = CType(Cache("ListadoRecursoPiePag"), List(Of InfoSeccionPadre))
            If Cache("ListadoRecursoPiePag") Is Nothing Then
                ListadoRecursosPie = NegSeccion.BuscarSeccionRecursos("Recursos")
                Cache.Insert("ListadoRecursoPiePag", ListadoRecursosPie, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            End If




        End If

    End Sub

    <WebMethod()> Public Shared Function ListarTablaMenu() As String
        Dim strHtml_Completo As String = ""
        Dim strHtml_UL_Inicial As String = "<ul>"
        Dim strHtml_UL_Final As String = "</ul>"
        Dim strHtml_LI_Inicial As String = "<li>"
        Dim strHtml_LI_Final As String = "</li>"

        Dim strHtml_Ahref_Inicial As String = "<a "
        Dim strHtml_Ahref_Inicial_Com As String = "<a href="
        Dim strHtml_Ahref_Final As String = "</a>"

        Dim strHtml_Interno_Encabezado As String = ""
        Dim strHtml_Interno_Detalle As String = ""
        Dim strHtml_Final As String = ""
        Dim intIndex As Integer = 1
        Dim intCantidadPadres As Integer
        Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPrincipal"))
        Dim strListaMenuConfig As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaMENU"))
        Dim strListaTipoBotonConfig As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaBotonMENU"))
        Dim strUrlComunidad As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("UrlComunidad"))



        Dim Expires As DateTime

        Expires = DateAdd(DateInterval.Day, intTiempo, Now)
        Dim ListadoMenu As New List(Of InfoMenu)
        ListadoMenu = CType(HttpRuntime.Cache("MiListadoMenu"), List(Of InfoMenu))
        If HttpRuntime.Cache("MiListadoMenu") Is Nothing Then
            ListadoMenu = MenuPL.BuscarMenuPrincipal()
            HttpRuntime.Cache.Insert("MiListadoMenu", ListadoMenu, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If



        Dim strListaMenu As String() = strListaMenuConfig.ToString.Split(",")
        Dim strListaTipoBoton As String() = strListaTipoBotonConfig.ToString.Split(",")
        Dim boEncontrado As Boolean = False
        intCantidadPadres = ListadoMenu.Count

        For Each resultadoMenu As InfoMenu In ListadoMenu
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

        strHtml_Completo = strHtml_UL_Inicial & strHtml_Final & strHtml_UL_Final
        Return strHtml_Completo
    End Function



    Public Shared Function recorrerListado(ByVal oListadoPadre As List(Of InfoSeccionPadre)) As String
        Dim strMENU_Curso As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("ListaMENU_Curso"))
        Dim strPaginaMENU_Curso As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("PaginaMENU_Curso"))

        Dim strHtml_UL_Inicial As String = "<ul>"
        Dim strHtml_UL__Final As String = "</ul>"
        Dim strHtml_LI_Inicial As String = "<li>"
        Dim strHtml_LI_Final As String = "</li>"

        Dim strHtml_Ahref_Inicial As String = "<a "
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
                    strHtml_Interno_Encabezado = strHtml_LI_Inicial & strHtml_Ahref_Inicial & "'" & strPaginaMENU_Curso.ToString & "' >" & resultadoPadres.Descripcion & strHtml_Ahref_Final & strHtml_LI_Final
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


    <WebMethod()> Public Shared Function ListarEtiquetas() As String

        Dim strHtml_Completo As String = " "
        Dim Expires As DateTime
        Dim intEtiqueta_Tipo_Font1 As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_Tipo_Font1"))
        Dim intEtiqueta_Tipo_Font2 As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_Tipo_Font2"))
        Dim intEtiqueta_Listado_Maximo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_Listado_Maximo"))
        Dim intEtiqueta_ValorMasUsado As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("Etiqueta_ValorMasUsado"))
        Dim intTiempoEt As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEtiquetas"))


        Expires = DateAdd(DateInterval.Day, intTiempoEt, Now)
        Dim ListadoEtiqueta As New List(Of InfoEtiqueta)
        ListadoEtiqueta = CType(HttpRuntime.Cache("ListadoEtiqueta"), List(Of InfoEtiqueta))
        If HttpRuntime.Cache("ListadoEtiqueta") Is Nothing Then
            ListadoEtiqueta = Etiqueta.BuscarEtiquetas()
            HttpRuntime.Cache.Insert("ListadoEtiqueta", ListadoEtiqueta, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If


        Dim intIndice As Integer = 0
        Dim intX As Integer = 0
        Dim oListadoEtiquetas As New List(Of String)
        Dim oListadoCantidadXEtiquetas As New List(Of String)

        For Each resultado As InfoEtiqueta In ListadoEtiqueta
            Dim strEtiquetas As String()
            strEtiquetas = resultado.Etiqueta.Split(" ")
            If oListadoEtiquetas.Count < intEtiqueta_Listado_Maximo Then
                For intX = 0 To strEtiquetas.Length - 1
                    If oListadoEtiquetas.Count < intEtiqueta_Listado_Maximo Then
                        If strEtiquetas(intX).Length > 0 Then
                            oListadoEtiquetas.Add(strEtiquetas(intX))
                        End If
                    Else
                        Exit For
                    End If

                Next
            Else
                Exit For
            End If
        Next


        For Each resultado As InfoEtiqueta In ListadoEtiqueta
            Dim strEtiquetas As String()
            strEtiquetas = resultado.MasUsoTag.Split("|")
            If oListadoCantidadXEtiquetas.Count < intEtiqueta_Listado_Maximo Then
                For intX = 0 To strEtiquetas.Length - 1
                    If oListadoCantidadXEtiquetas.Count < intEtiqueta_Listado_Maximo Then
                        If strEtiquetas(intX).Length > 0 Then
                            oListadoCantidadXEtiquetas.Add(strEtiquetas(intX))
                        End If
                    Else
                        Exit For
                    End If

                Next
            Else
                Exit For
            End If
        Next


        Dim strHtml_Font1 As String
        Dim strHtml_Font2 As String
        Dim strHtml_2 As String
        Dim strHtml_3 As String

        strHtml_Font1 = "<span><a style='font-size:" + intEtiqueta_Tipo_Font1.ToString() + "px;' onclick=IraEtiqueta('"
        strHtml_Font2 = "<span><a style='font-size:" + intEtiqueta_Tipo_Font2.ToString() + "px;' onclick=IraEtiqueta('"

        strHtml_2 = "')> "
        strHtml_3 = " </a> " & " " & " </span>"

        Dim intIndiceX As Integer = 0
        For Each resultado As String In oListadoEtiquetas
            Dim strHtml_Interno As String = ""
            intIndice = intIndice + 1
            If (intIndice Mod 2) = 0 Then

                If oListadoCantidadXEtiquetas(intIndiceX) > intEtiqueta_ValorMasUsado Then
                    strHtml_Interno = strHtml_Font2 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
                Else
                    strHtml_Interno = strHtml_Font1 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
                End If
            Else
                If oListadoCantidadXEtiquetas(intIndiceX) > intEtiqueta_ValorMasUsado Then
                    strHtml_Interno = strHtml_Font2 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
                Else
                    strHtml_Interno = strHtml_Font1 & resultado.ToString() & strHtml_2 & resultado.ToString() & strHtml_3
                End If
            End If
            strHtml_Completo = strHtml_Completo & strHtml_Interno
            intIndiceX = intIndiceX + 1
        Next


        Expires = DateAdd(DateInterval.Day, 30, Now)
        Dim strHtmlEtiquetas As String
        strHtmlEtiquetas = CType(HttpRuntime.Cache("strHtmlEtiquetas"), String)
        If HttpRuntime.Cache("strHtmlEtiquetas") Is Nothing Then
            strHtmlEtiquetas = strHtml_Completo
            HttpRuntime.Cache.Insert("strHtmlEtiquetas", strHtmlEtiquetas, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If


        Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEncuesta"))
        Dim oPregunta As New InfoPregunta

        Expires = DateAdd(DateInterval.Day, intTiempo, Now)
        oPregunta = CType(HttpRuntime.Cache("Pregunta"), InfoPregunta)

        If HttpRuntime.Cache("Pregunta") Is Nothing Then
            oPregunta = Pregunta.TraerPreguntaActual()
            HttpRuntime.Cache.Insert("Pregunta", oPregunta, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If


        intTiempo = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPrincipal"))
        Expires = DateAdd(DateInterval.Day, intTiempo, Now)
        Dim ListadoMenu As New List(Of InfoMenu)
        ListadoMenu = CType(HttpRuntime.Cache("MiListadoMenu"), List(Of InfoMenu))

        If HttpRuntime.Cache("MiListadoMenu") Is Nothing Then
            ListadoMenu = MenuPL.BuscarMenuPrincipal()
            HttpRuntime.Cache.Insert("MiListadoMenu", ListadoMenu, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If

        Return strHtml_Completo
    End Function



End Class