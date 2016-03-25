Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Sistema.PL.Negocio.Util

Partial Public Class Secciones
    Inherits System.Web.UI.Page

    Dim ListadoPaginaPorSeccion As New List(Of InfoPaginasdelaSeccion)
    Dim oSeccion As New InfoSeccion
    Dim intMaximoPorLista As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoPaginaSeccion"))
    Dim strSeccion_Tipo_Font1 As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Lista_Seccion_Tipo_Font1"))
    Dim strSeccion_Tipo_Font2 As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Lista_Seccion_Tipo_Font2"))
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
            strParamSeccion = Request.QueryString("Ide").ToString
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

        'LblSeccionTitulo.InnerHtml = "Art&#237;culos Marcado con Etiqueta '" & strParaEtiqueta & "'"

        oSeccion = NegSeccion.ObtenerInformacionSeccion(Convert.ToInt32(strParamSeccion))
        LblSeccionTitulo.InnerHtml = oSeccion.section_name & "(" & oSeccion.article_count & ")"
        LblSeccionTituloPrincipal.InnerHtml = oSeccion.section_name & " | ParaLideres.org"
        LblDescripcionSeccion.InnerHtml = oSeccion.pagetext & "<br />"
        If oSeccion.TieneSubSeccion Then
            listarSubSeccion(oSeccion.SubSeccion)
        End If

        Dim strListadoOrigenes As String()
        strListadoOrigenes = oSeccion.Descripcion_niveles.Split(strCaraterdeSeparacion)
        Dim intcuentaVeces As Integer = 1
        For intIndiceY = 0 To strListadoOrigenes.Length - 3
            Dim strListadoOrigen2 As String()
            strListadoOrigen2 = strListadoOrigenes(intIndiceY).Split("|")
            If intIndiceY = 0 Then
                hrefTitulo5.Visible = True
                hrefTitulo5.HRef = "Secciones.aspx?Ide=" & strListadoOrigen2(0) & "&Pag=1"
                hrefTitulo5.InnerHtml = strListadoOrigen2(1)
                lblSigno5.Visible = True
            ElseIf intIndiceY = 1 Then
                hrefTitulo4.Visible = True
                hrefTitulo4.HRef = "Secciones.aspx?Ide=" & strListadoOrigen2(0) & "&Pag=1"
                hrefTitulo4.InnerHtml = strListadoOrigen2(1)
                lblSigno4.Visible = True
            ElseIf intIndiceY = 2 Then
                hrefTitulo3.Visible = True
                hrefTitulo3.HRef = "Secciones.aspx?Ide=" & strListadoOrigen2(0) & "&Pag=1"
                hrefTitulo3.InnerHtml = strListadoOrigen2(1)
                lblSigno3.Visible = True
            ElseIf intIndiceY = 3 Then
                hrefTitulo2.Visible = True
                hrefTitulo2.HRef = "Secciones.aspx?Ide=" & strListadoOrigen2(0) & "&Pag=1"
                hrefTitulo2.InnerHtml = strListadoOrigen2(1)
                lblSigno2.Visible = True
            ElseIf intIndiceY = 4 Then
                hrefTitulo1.Visible = True
                hrefTitulo1.HRef = "Secciones.aspx?Ide=" & strListadoOrigen2(0) & "&Pag=1"
                hrefTitulo1.InnerHtml = strListadoOrigen2(1)
                lblSigno1.Visible = True
            End If


            intcuentaVeces = intcuentaVeces + 1
        Next


        ListadoPaginaPorSeccion = NegSeccion.BuscarPaginasPorSeccion(Convert.ToInt32(strParamSeccion), intInicioPagina, intPaginasporSeccion)




        If ListadoPaginaPorSeccion.Count > 0 Then
            intTotalRegistros = ListadoPaginaPorSeccion.Item(0).CantidadTotalRegistros

            intCantidadPaginas = Math.Truncate(intTotalRegistros / intPaginasporSeccion)


            Dim intResultDivision As Integer = 0
            intResultDivision = intTotalRegistros Mod intPaginasporSeccion

            If intResultDivision > 0 Then
                intCantidadPaginas = intCantidadPaginas + 1

            End If
            listarTabla(ListadoPaginaPorSeccion)
        End If

    End Sub

    Sub listarSubSeccion(ByVal Listado As List(Of InfoSubSeccion))
        '<p><img src=" & _project_path & "images/seccion.gif><a href=" & _project_path & "section.aspx?section_id=" & intChildId & ">" & strChildName & "</a> (" & intChildRecordCount & ")<br>" & strChildText

        Dim intIndice = 0
        Dim strCeldaPersonalizada As String


        For Each resultado As InfoSubSeccion In Listado
            Dim rowMenu As New TableRow()
            intIndice = intIndice + 1

            'If intIndice <= intPaginasporSeccion Then
            If (intIndice Mod 2) = 0 Then
                rowMenu.CssClass = "lu_content_box"

                strCeldaPersonalizada = "<ul><li><img src='assets/imgs/seccion.gif'><a onclick=IraSeccion('" + resultado.section_id.ToString() + "')  onmouseover=this.style.cursor='hand'> <b>" & resultado.section_name.ToString() & "</b> </a> (" & resultado.article_count & ")<br>"
                strCeldaPersonalizada = strCeldaPersonalizada & "<font style='font-size:" & strSeccion_Tipo_Font1 & "px;'> " & resultado.pagetext.ToString() & "</font> </li></ul><br>"
                rowMenu.Cells.Add(Html.CrearCelda("100%", strCeldaPersonalizada, HorizontalAlign.Left, ""))

            Else
                rowMenu.CssClass = "lu_content_box"
                strCeldaPersonalizada = "<ul><li><img src='assets/imgs/seccion.gif'><a onclick=IraSeccion('" + resultado.section_id.ToString() + "')  onmouseover=this.style.cursor='hand'> <b>" & resultado.section_name.ToString() & "</b> </a> (" & resultado.article_count & ")<br>"
                strCeldaPersonalizada = strCeldaPersonalizada & "<font style='font-size:" & strSeccion_Tipo_Font1 & "px;'> " & resultado.pagetext.ToString() & "</font> </li></ul><br>"
                rowMenu.Cells.Add(Html.CrearCelda("100%", strCeldaPersonalizada, HorizontalAlign.Left, ""))

            End If

            Me.tblResultadoArticulosSubSeccion.Rows.Add(rowMenu)
            ' Else
            'Exit For
            'End If
        Next


    End Sub


    Sub listarTabla(ByVal Listado As List(Of InfoPaginasdelaSeccion))

        Dim intIndice = 0
        Dim strCeldaPersonalizada As String


        For Each resultado As InfoPaginasdelaSeccion In Listado
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

        Dim strHtml_Ahref_Inicial As String = "<a href='Secciones.aspx?Ide="
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
            strhtmlinterno = strhtmlinterno & "<a href='Secciones.aspx?Ide=" & strParamSeccion & "&Pag=" & intPaginaActual - 1 & "'> <img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/left_arrow_on.jpg' />" & strHtml_Ahref_Final
        End If

        If intPaginaActual > intTotalMaximoPaginacion And ((intPaginasporSeccion * intPaginaActual) + 1) < intTotalRegistros Then
            For intX = intPaginaActual To intCantidadPaginas
                If intX <= (intTotalMaximoPaginacion + (intPaginaActual - 1)) Then
                    If intPaginaActual = intX Then
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & "<Label>" & intX.ToString & "</label>"
                    Else
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strParamSeccion & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
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
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strParamSeccion & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
                    End If
                Else
                    Exit For
                End If

            Next
        End If




        If ((intPaginasporSeccion * intPaginaActual) + 1) > intTotalRegistros Then
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' />"
        Else

            strhtmlinterno = strhtmlinterno & "<a href='Secciones.aspx?Ide=" & strParamSeccion & "&Pag=" & intPaginaActual + 1 & "'> <img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/right_arrow_on.jpg' />" & strHtml_Ahref_Final
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
