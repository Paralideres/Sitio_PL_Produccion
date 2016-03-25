Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Sistema.PL.Negocio.Util

Partial Public Class Populares
    Inherits System.Web.UI.Page
    Dim ListadodeArticulos As New List(Of InfoArticuloListado)
    Dim intMaximoPorLista As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoPaginaSeccion"))
    Dim strSeccion_Tipo_Font1 As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Lista_Seccion_Tipo_Font1"))
    Dim intTotalMaximoPaginacion As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TotalMaximoPaginacion"))
    Dim strCaraterdeSeparacion As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("CaraterdeSeparacion"))
    Dim intPaginasporSeccion As Integer = 0
    Dim strParamSeccion As String = "Amor"
    Dim intPaginaActual As Integer
    Dim intInicioPagina As Integer
    Dim intTotalRegistros As Integer
    Dim intCantidadPaginas As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strParamPagina As String = "1"
        Try
            'strParamSeccion = Request.QueryString("Ide").ToString
            strParamPagina = Request.QueryString("Pag").ToString
        Catch ex As Exception
        End Try

        intPaginasporSeccion = intMaximoPorLista

        If strParamPagina = "1" Then
            strParamPagina = "1"
            intPaginaActual = 1 'es la pagina inicial
            intInicioPagina = 1
        Else
            intInicioPagina = (intPaginasporSeccion * (CInt(strParamPagina.ToString()) - 1)) + 1
            intPaginaActual = CInt(strParamPagina.ToString())
        End If

        LblPopularesTituloPrincipal.InnerHtml = "Lista de Lo Popular | ParaLideres.org"

        ListadodeArticulos = LoPopular.BuscarArticulosLoPopular(intInicioPagina, intPaginasporSeccion)

        If ListadodeArticulos.Count > 0 Then
            intTotalRegistros = ListadodeArticulos.Item(0).CantidadTotalRegistros

            intCantidadPaginas = intTotalRegistros / intPaginasporSeccion
            listarTabla(ListadodeArticulos)
        End If

    End Sub

    Sub listarTabla(ByVal Listado As List(Of InfoArticuloListado))

        Dim intIndice = 0
        Dim strCeldaPersonalizada As String


        For Each resultado As InfoArticuloListado In Listado
            Dim rowMenu As New TableRow()
            intIndice = intIndice + 1

            If intIndice <= intPaginasporSeccion Then
                If (intIndice Mod 2) = 0 Then
                    rowMenu.CssClass = "lu_content_box"

                    strCeldaPersonalizada = "<ul><li><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "')  onmouseover=this.style.cursor='hand'> <b>" & resultado.Titulo.ToString() & "</b> </a> <div class='rating r_rating'> " & DefineEstrella(resultado.Rating) & " </div>"
                    strCeldaPersonalizada = strCeldaPersonalizada & "<font style='font-size:" & strSeccion_Tipo_Font1 & "px;'> Por: " & resultado.NombreAutor.ToString() & "</font> <br>"
                    strCeldaPersonalizada = strCeldaPersonalizada & resultado.Contenido.ToString() & "</li></ul><br>"


                    rowMenu.Cells.Add(Html.CrearCelda("100%", strCeldaPersonalizada, HorizontalAlign.Left, ""))

                Else
                    rowMenu.CssClass = "lu_content_box"
                    strCeldaPersonalizada = "<ul><li><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> <b>" & resultado.Titulo.ToString() & "</b> </a> <div class='rating r_rating'> " & DefineEstrella(resultado.Rating) & " </div>"
                    strCeldaPersonalizada = strCeldaPersonalizada & "<font style='font-size:" & strSeccion_Tipo_Font1 & "px;'> Por: " & resultado.NombreAutor.ToString() & "</font> <br>"
                    strCeldaPersonalizada = strCeldaPersonalizada & resultado.Contenido.ToString() & "</li></ul><br>"
                    rowMenu.Cells.Add(Html.CrearCelda("100%", strCeldaPersonalizada, HorizontalAlign.Left, ""))

                End If

                Me.tblResultadoArticulos.Rows.Add(rowMenu)
            Else
                Exit For
            End If
        Next
        Dim intX As Integer

        Dim strHtml_Ahref_Inicial As String = "<a href='Populares.aspx"
        Dim strHtml_Ahref_Mitad As String = "?Pag="
        Dim strHtml_Ahref_Final As String = "</a>"
        Dim strHtml_Final As String = ""
        Dim strhtmlinterno As String = ""

        If intPaginaActual = 1 Then
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' />"
        Else
            strhtmlinterno = strhtmlinterno & "<a href='Populares.aspx?Pag=" & intPaginaActual - 1 & "'> <img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/left_arrow_on.jpg' />" & strHtml_Ahref_Final
        End If

        If intPaginaActual > intTotalMaximoPaginacion And ((intPaginasporSeccion * intPaginaActual) + 1) < intTotalRegistros Then
            For intX = intPaginaActual To intCantidadPaginas
                If intX <= (intTotalMaximoPaginacion + (intPaginaActual - 1)) Then
                    If intPaginaActual = intX Then
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & "<Label>" & intX.ToString & "</label>"
                    Else
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
                    End If
                Else
                    Exit For
                End If
            Next
        Else
            For intX = 1 To intCantidadPaginas
                If intX <= intTotalMaximoPaginacion Then
                    If intPaginaActual = intX Then
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & "<Label>" & intX.ToString & "</label>"
                    Else
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
                    End If
                Else
                    Exit For
                End If

            Next
        End If




        If ((intPaginasporSeccion * intPaginaActual) + 1) > intTotalRegistros Then
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' />"
        Else

            strhtmlinterno = strhtmlinterno & "<a href='Populares.aspx?Pag=" & intPaginaActual + 1 & "'> <img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/right_arrow_on.jpg' />" & strHtml_Ahref_Final
        End If


        strHtml_Final = "<p align=center>" & strhtmlinterno & "</p>"
        TagPaginacion.InnerHtml = strHtml_Final


    End Sub

    Function DefineEstrella(ByVal intrating As Integer) As String
        Dim strEstrellaOn As String = "<img src='assets/imgs/gral/rating_star_on.jpg' title='Valor de Estrella' />"
        Dim strEstrellaOff As String = "<img src='assets/imgs/gral/rating_star_off.jpg' title='Valor de Estrella' />"
        Dim strRating As String = ""
        If intrating = 0 Then
            strRating = strEstrellaOff & strEstrellaOff & strEstrellaOff & strEstrellaOff & strEstrellaOff
        ElseIf intrating = 1 Then
            strRating = strEstrellaOn & strEstrellaOff & strEstrellaOff & strEstrellaOff & strEstrellaOff
        ElseIf intrating = 2 Then
            strRating = strEstrellaOn & strEstrellaOn & strEstrellaOff & strEstrellaOff & strEstrellaOff
        ElseIf intrating = 3 Then
            strRating = strEstrellaOn & strEstrellaOn & strEstrellaOn & strEstrellaOff & strEstrellaOff
        ElseIf intrating = 4 Then
            strRating = strEstrellaOn & strEstrellaOn & strEstrellaOn & strEstrellaOn & strEstrellaOff
        ElseIf intrating = 5 Then
            strRating = strEstrellaOn & strEstrellaOn & strEstrellaOn & strEstrellaOn & strEstrellaOn
        End If
        Return strRating
    End Function

End Class