Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio

Partial Public Class Logged
    Inherits System.Web.UI.Page
    Dim oUsuario As New InfoUsuario()
    Dim intMaximoCaract As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterMenu"))
    Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheMenuPrincipal"))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        oUsuario = Session("UsuarioConectado")
        Dim oUsuarioIP As New InfoUsuarioIP
        oUsuarioIP.IdUsuario = oUsuario.IdUsuario
        oUsuarioIP.IpAddress = Request.UserHostAddress()


        Sistema.PL.Negocio.Usuario.Identifica_UsuarioXIp(oUsuarioIP)
        Dim IdPagina As Integer = 0
        IdPagina = Session("Idp")

        If IdPagina <> 0 Then
            Response.Redirect("VerArticulo.aspx?Idp=" & IdPagina)
            Exit Sub
        End If


        If (Not IsPostBack) Then
            Dim Expires As DateTime
            Expires = DateAdd(DateInterval.Minute, intTiempo, Now)
            Dim ListadoMenu As New List(Of InfoMenu)
            ListadoMenu = CType(Cache("ListadoMenu"), List(Of InfoMenu))

            If Cache("ListadoMenu") Is Nothing Then
                ListadoMenu = MenuPL.BuscarMenuPrincipal()
                Cache.Insert("ListadoMenu", ListadoMenu, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            End If
            listarTablaMenu(ListadoMenu)
        End If
    End Sub


    Sub listarTablaMenu(ByVal Listado As List(Of InfoMenu))

        '<li class="mdb_sec_title"><a href="#SeccionArte">Arte</a></li>
        '<li><a href="#Seccion">Guiones y Dramas</a></li>
        '<li><a href="#Seccion">Historietas</a></li>
        '<li><a href="#Seccion">Cuentos y Poemas</a></li>
        '<li><a href="#Seccion">Plantillas</a></li>





        Dim strHtml_li_Titulo_Inicial As String = "<li class='mdb_sec_title'><a href='#'"
        Dim strHtml_li_Titulo_Final As String = "</a></li>"
        Dim strHtml_li_Normal_Inicial As String = "<li><a href='#'"
        Dim strHtml_li_Normal_Final As String = "</a></li>"

        Dim strHtml_Interno_Encabezado As String = ""
        Dim strHtml_Interno_Detalle As String = ""

        Dim strHtml_Completo1 As String = ""
        Dim strHtml_Completo2 As String = ""
        Dim strHtml_Completo3 As String = ""

        Dim intPadreActual As Integer = 0
        Dim intPadreAnterior As Integer = 0
        Dim boTagAbierto As Boolean = False
        Dim intNumColumna As Integer = 1
        Dim strDescripcion As String = ""

        For Each resultadoMenu As InfoMenu In Listado
            Dim oListadoPadre As New List(Of InfoSeccionPadre)
            oListadoPadre = resultadoMenu.Padres
            For Each resultadoPadres As InfoSeccionPadre In oListadoPadre
                strHtml_Interno_Encabezado = ""
                strDescripcion = resultadoPadres.Descripcion.ToString()
                If strDescripcion.Length > intMaximoCaract Then
                    strDescripcion = strDescripcion.Substring(0, intMaximoCaract)
                End If
                strHtml_Interno_Encabezado = strHtml_Interno_Encabezado & strHtml_li_Titulo_Inicial & " onclick=IraSeccion('" & resultadoPadres.IdMenu.ToString() & "')>" & strDescripcion.ToString() & strHtml_li_Titulo_Final
                Dim oListadoHijos As New List(Of InfoSeccionHijos)
                oListadoHijos = resultadoPadres.Hijos
                For Each resultadoHijos As InfoSeccionHijos In oListadoHijos
                    strDescripcion = resultadoHijos.Descripcion.ToString()
                    If strDescripcion.Length > intMaximoCaract Then
                        strDescripcion = strDescripcion.Substring(0, intMaximoCaract)
                    End If
                    strHtml_Interno_Detalle = strHtml_Interno_Detalle & strHtml_li_Normal_Inicial & " onclick=IraSeccion('" & resultadoHijos.IdMenu.ToString() & "')>" & strDescripcion.ToString() & strHtml_li_Normal_Final

                Next
                strHtml_Interno_Encabezado = strHtml_Interno_Encabezado & strHtml_Interno_Detalle

                If intNumColumna = 1 Then
                    strHtml_Completo1 = strHtml_Completo1 & strHtml_Interno_Encabezado
                    strHtml_Interno_Detalle = ""
                    intNumColumna = intNumColumna + 1
                ElseIf intNumColumna = 2 Then
                    strHtml_Completo2 = strHtml_Completo2 & strHtml_Interno_Encabezado
                    strHtml_Interno_Detalle = ""
                    intNumColumna = intNumColumna + 1
                ElseIf intNumColumna = 3 Then
                    strHtml_Completo3 = strHtml_Completo3 & strHtml_Interno_Encabezado
                    strHtml_Interno_Detalle = ""
                    intNumColumna = 1
                End If
            Next




        Next



        ulColumna1.InnerHtml = strHtml_Completo1
        ulColumna2.InnerHtml = strHtml_Completo2
        ulColumna3.InnerHtml = strHtml_Completo3

    End Sub



End Class