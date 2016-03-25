Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Sistema.PL.Negocio.Util

Partial Public Class Lista_MasDelAutor
    Inherits System.Web.UI.Page
    Dim intMaximoCarac_Tipo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterTipo"))
    Dim intMaximoCarac_Titulos As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterTitulo"))
    Dim intMaximoPorLista As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoPorLista"))
    Dim intColumna1 As Integer = 5
    Dim intColumna2 As Integer = 10
    Dim intColumna3 As Integer = 5
    Dim IntColumna4 As Integer = 40
    Dim Intcolumna5 As Integer = 45
    Dim intIdAutor As Integer

    Dim strSeccion_Tipo_Font1 As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("Lista_Seccion_Tipo_Font1"))
    Dim intTotalMaximoPaginacion As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TotalMaximoPaginacion"))
    Dim strCaraterdeSeparacion As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("CaraterdeSeparacion"))
    Dim intFilasporPaginas As Integer = 0
    Dim strParamAutor As String = "Amor"
    Dim intPaginaActual As Integer
    Dim intInicioPagina As Integer
    Dim intTotalRegistros As Integer
    Dim intCantidadPaginas As Integer
    Dim IdArticulo As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        intIdAutor = Request.QueryString("Ida").ToString()
        Dim strParamPagina As String = "1"
        Try
            IdArticulo = Request.QueryString("Idp").ToString
            strParamAutor = Request.QueryString("Ida").ToString
            intIdAutor = CInt(strParamAutor)
            strParamPagina = Request.QueryString("Pag").ToString
        Catch ex As Exception
        End Try

        intFilasporPaginas = intMaximoPorLista

        If strParamPagina = "1" Then
            strParamPagina = "1"
            intPaginaActual = 1 'es la pagina inicial
            intInicioPagina = 1
        Else
            intInicioPagina = (intFilasporPaginas * (CInt(strParamPagina.ToString()) - 1)) + 1
            intPaginaActual = CInt(strParamPagina.ToString())
        End If

        Dim Listado As New List(Of InfoLoDelAutor)
        Listado = LoDelAutor.ListarLoDelAutor(intIdAutor, intInicioPagina, intFilasporPaginas)




        If Listado.Count > 0 Then
            intTotalRegistros = Listado.Item(0).CantidadTotalRegistros

            intCantidadPaginas = intTotalRegistros / intFilasporPaginas
            listarTabla(Listado)
        End If
    End Sub

    Sub listarTabla(ByVal Listado As List(Of InfoLoDelAutor))
        Dim intIndice = 0
        Dim strTipo As String
        Dim strTitulo As String
        For Each resultado As InfoLoDelAutor In Listado
            Dim rowMenu As New TableRow()
            intIndice = intIndice + 1
            If intIndice < intMaximoPorLista Then
                If (intIndice Mod 2) = 0 Then
                    rowMenu.CssClass = "lu_content_box"
                    If resultado.Nombre_Seccion.ToString().Length > intMaximoCarac_Tipo Then
                        strTipo = resultado.Nombre_Seccion.ToString().Substring(0, intMaximoCarac_Tipo)
                    Else
                        strTipo = resultado.Nombre_Seccion.ToString()
                    End If

                    If resultado.Titulo.ToString().Length > intMaximoCarac_Titulos Then
                        strTitulo = resultado.Titulo.ToString().Substring(0, intMaximoCarac_Titulos) & "..."
                    Else
                        strTitulo = resultado.Titulo.ToString()
                    End If

                    rowMenu.Cells.Add(Html.CrearCeldaVisible(intColumna1.ToString() & "%", "<a href='#' class='link_btn_round_sm'> " & resultado.IdFila.ToString() & " </a>", HorizontalAlign.Left, "", False))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna2.ToString() & "%", "<a href='#' onclick=IraSeccion('" + resultado.IdSeccion.ToString() + "') class='link_btn_round_sm' onmouseover=this.style.cursor='hand'> " & strTipo.ToString() & " </a>", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna3.ToString() & "%", "<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'", HorizontalAlign.Center, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </a></h1> ", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(Intcolumna5.ToString() & "%", "<span>Por <a onclick=IraPerfil('" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & resultado.Autor.ToString() & "  </a> el " & resultado.Fecha.ToString("dd/MM/yyyy") & " </span>", HorizontalAlign.Left, ""))
                Else
                    rowMenu.CssClass = "lu_content_box"
                    If resultado.Nombre_Seccion.ToString().Length > intMaximoCarac_Tipo Then
                        strTipo = resultado.Nombre_Seccion.ToString().Substring(0, intMaximoCarac_Tipo)
                    Else
                        strTipo = resultado.Nombre_Seccion.ToString()
                    End If

                    If resultado.Titulo.ToString().Length > intMaximoCarac_Titulos Then
                        strTitulo = resultado.Titulo.ToString().Substring(0, intMaximoCarac_Titulos) & "..."
                    Else
                        strTitulo = resultado.Titulo.ToString()
                    End If

                    rowMenu.Cells.Add(Html.CrearCeldaVisible(intColumna1.ToString() & "%", "<a href='#' class='link_btn_round_sm'> " & resultado.IdFila.ToString() & " </a>", HorizontalAlign.Left, "", False))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna2.ToString() & "%", "<a href='#' onclick=IraSeccion('" + resultado.IdSeccion.ToString() + "') class='link_btn_round_sm' onmouseover=this.style.cursor='hand'> " & strTipo.ToString() & " </a>", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna3.ToString() & "%", "<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'", HorizontalAlign.Center, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </a></h1> ", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(Intcolumna5.ToString() & "%", "<span>Por <a onclick=IraPerfil('" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'>  " & resultado.Autor.ToString() & " </a> el " & resultado.Fecha.ToString("dd/MM/yyyy") & " </span>", HorizontalAlign.Left, ""))

                End If

                Me.tblResultado.Rows.Add(rowMenu)
            Else
                Exit For
            End If
        Next
        Dim intX As Integer

        Dim strHtml_Ahref_Inicial As String = "<a href='VerArticulo.aspx?Idp="
        Dim strHtml_Ahref_Mitad As String = "&Pag="
        Dim strHtml_Ahref_Final As String = "</a>"
        Dim strHtml_Final As String = ""
        Dim strhtmlinterno As String = ""

        If intPaginaActual = 1 Then
            'onMouseOut
            '<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'"
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' />"
        Else
            strhtmlinterno = strhtmlinterno & "<a href='VerArticulo.aspx?Idp=" & IdArticulo & "&Ida=" & strParamAutor & "&Pag=" & intPaginaActual - 1 & "'> <img src='assets/imgs/widgets/last_updates/left_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/left_arrow_on.jpg' />" & strHtml_Ahref_Final
        End If

        If intPaginaActual > intTotalMaximoPaginacion And ((intFilasporPaginas * intPaginaActual) + 1) < intTotalRegistros Then
            For intX = intPaginaActual To intCantidadPaginas
                If intX <= (intTotalMaximoPaginacion + (intPaginaActual - 1)) Then
                    If intPaginaActual = intX Then
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & "<Label> <b>" & intX.ToString & "</b></label>"
                    Else
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & strParamAutor & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
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
                        strhtmlinterno = strhtmlinterno & "<Label> <b>" & intX.ToString & "</b></label>"
                    Else
                        strhtmlinterno = strhtmlinterno & "&nbsp;"
                        strhtmlinterno = strhtmlinterno & strHtml_Ahref_Inicial & IdArticulo & "&Ida=" & strParamAutor & strHtml_Ahref_Mitad & intX.ToString & "'>" & intX.ToString & strHtml_Ahref_Final
                    End If
                Else
                    Exit For
                End If

            Next
        End If




        If ((intFilasporPaginas * intPaginaActual) + 1) > intTotalRegistros Then
            strhtmlinterno = strhtmlinterno & "<img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' />"
        Else

            strhtmlinterno = strhtmlinterno & "<a href='VerArticulo.aspx?Idp=" & IdArticulo & "&Ida=" & strParamAutor & "&Pag=" & intPaginaActual + 1 & "'> <img src='assets/imgs/widgets/last_updates/right_arrow_off.jpg' onmouseover='assets/imgs/widgets/last_updates/right_arrow_on.jpg' />" & strHtml_Ahref_Final

        End If


        strHtml_Final = "<p align=center>" & strhtmlinterno & "</p>"
        TagPaginacion.InnerHtml = strHtml_Final


    End Sub

End Class