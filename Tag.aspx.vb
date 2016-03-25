Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Sistema.PL.Negocio.Util

Partial Public Class Tag
    Inherits System.Web.UI.Page
    Dim ListadoEtiqueta As List(Of InfoEtiqueta)
    Dim intMaximoPorLista As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoPorListaEtiqueta"))
    Dim strEtiqueta_Tipo_Font1 As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Lista_Etiqueta_Tipo_Font1"))
    Dim intTotalMaximoPaginacion As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TotalMaximoPaginacion"))
    Dim intTotalRegistros As Integer = 0
    Dim intEtiquetasporPaginas As Integer = 0
    Dim intCantidadPaginas As Integer = 0
    Dim intPaginaActual As Integer
    Dim intInicioPagina As Integer
    Dim strParaEtiqueta As String = "Amor"
    Dim intCantidadLinks As Integer = 10
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strParaPagina As String = "1"
        Try
            strParaEtiqueta = Request.QueryString("Ide").ToString
            strParaPagina = Request.QueryString("Pag").ToString
        Catch ex As Exception
        End Try
        LblEtiquetaTitulo.InnerHtml = "Art&#237;culos Marcado con Etiqueta : '" & strParaEtiqueta & "'"
        intEtiquetasporPaginas = intMaximoPorLista

        If strParaPagina = "1" Then
            strParaPagina = "1"
            intPaginaActual = 1 'es la pagina inicial
            intInicioPagina = 1
        Else
            intInicioPagina = (intEtiquetasporPaginas * (CInt(strParaPagina.ToString()) - 1)) + 1
            intPaginaActual = CInt(strParaPagina.ToString())
        End If
        ListadoEtiqueta = Etiqueta.BuscarPaginasPorEtiquetas(strParaEtiqueta, intInicioPagina, intEtiquetasporPaginas)




        intTotalRegistros = Etiqueta.ObtenerCantidadRegistroPorEtiqueta(strParaEtiqueta)
        intCantidadPaginas = intTotalRegistros / intEtiquetasporPaginas
        listarTabla(ListadoEtiqueta)
    End Sub
    Sub listarTabla(ByVal Listado As List(Of InfoEtiqueta))

        Dim intIndice = 0
        Dim strCeldaPersonalizada As String


        For Each resultado As InfoEtiqueta In Listado
            Dim rowMenu As New TableRow()
            intIndice = intIndice + 1

            If intIndice <= intEtiquetasporPaginas Then
                If (intIndice Mod 2) = 0 Then
                    rowMenu.CssClass = "lu_content_box"

                    strCeldaPersonalizada = "<ul><li><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "')  onmouseover=this.style.cursor='hand'> <b>" & resultado.Titulo.ToString() & "</b> </a> " & DefineEstrella(resultado.Rating) & "<br>"
                    strCeldaPersonalizada = strCeldaPersonalizada & "<font style='font-size:" & strEtiqueta_Tipo_Font1 & "px;'> Por: " & resultado.NombreAutor.ToString() & "</font> <br>"
                    strCeldaPersonalizada = strCeldaPersonalizada & resultado.Contenido.ToString() & "</li></ul><br>"


                    rowMenu.Cells.Add(Html.CrearCelda("100%", strCeldaPersonalizada, HorizontalAlign.Left, ""))

                Else
                    rowMenu.CssClass = "lu_content_box"
                    strCeldaPersonalizada = "<ul><li><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> <b>" & resultado.Titulo.ToString() & "</b> </a> " & DefineEstrella(resultado.Rating) & "<br>"
                    strCeldaPersonalizada = strCeldaPersonalizada & "<font style='font-size:" & strEtiqueta_Tipo_Font1 & "px;'> Por: " & resultado.NombreAutor.ToString() & "</font> <br>"
                    strCeldaPersonalizada = strCeldaPersonalizada & resultado.Contenido.ToString() & "</li></ul><br>"
                    rowMenu.Cells.Add(Html.CrearCelda("100%", strCeldaPersonalizada, HorizontalAlign.Left, ""))

                End If

                Me.tblResultado.Rows.Add(rowMenu)
            Else
                Exit For
            End If
        Next
        Dim intX As Integer

        Dim strHtml_Ahref_Inicial As String = "<a href='Tag.aspx?Ide="
        Dim strHtml_Ahref_Mitad As String = "&Pag="
        Dim strHtml_Ahref_Final As String = "</a>"
        Dim strHtml_Final As String = ""
        Dim strhtmlinterno As String = ""

        '<p align=center>
        '   <a href="/pages_by_tag.aspx?index=1"><< Previo</a>  
        '   <a href="/pages_by_tag.aspx?index=1">1</a> <b>2</b>  
        '   <a href="/pages_by_tag.aspx?index=21">3</a>  
        '   <a href="/pages_by_tag.aspx?index=31">4</a>  
        '   <a href="/pages_by_tag.aspx?index=21">Siguiente >></a>
        '</p>
        If intPaginaActual = 1 Then
            'onMouseOut
            '<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'"
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' />"
        Else
            strhtmlinterno = strhtmlinterno & "<a href='Tag.aspx?Ide=" & strParaEtiqueta & "&Pag=" & intPaginaActual - 1 & "'> <img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/left_arrow_on.jpg' />" & strHtml_Ahref_Final
        End If


        If intPaginaActual > intTotalMaximoPaginacion And ((intEtiquetasporPaginas * intPaginaActual) + 1) < intTotalRegistros Then
            For intX = intPaginaActual To intCantidadPaginas
                If intX <= (intTotalMaximoPaginacion + (intPaginaActual - 1)) Then
                    If intPaginaActual = intX Then
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & "<Label>" & intX.ToString & "</label>"
                    Else
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strParaEtiqueta & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
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
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strParaEtiqueta & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
                    End If
                Else
                    Exit For
                End If
            Next

        End If



        If ((intEtiquetasporPaginas * intPaginaActual) + 1) > intTotalRegistros Then
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' />"
        Else

            strhtmlinterno = strhtmlinterno & "<a href='Tag.aspx?Ide=" & strParaEtiqueta & "&Pag=" & intPaginaActual + 1 & "'> <img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/right_arrow_on.jpg' />" & strHtml_Ahref_Final
        End If


        strHtml_Final = "<p align=center>" & strhtmlinterno & "</p>"
        TagPaginacion.InnerHtml = strHtml_Final


    End Sub
    Function DefineEstrella(ByVal intrating As Integer) As String
        'Dim strEstrellaOn As String = "<a href='#votar'><img src='assets/imgs/gral/rating_star_on.jpg' title='Valor de Estrella' /></a>"
        'Dim strEstrellaOff As String = "<a href='#votar'><img src='assets/imgs/gral/rating_star_off.jpg' title='Valor de Estrella' /></a>"
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