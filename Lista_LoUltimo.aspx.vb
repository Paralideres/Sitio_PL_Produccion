Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio.Util

Partial Public Class Lista_LoUltimo
    Inherits System.Web.UI.Page
    Dim intMaximoCarac_Tipo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterTipo"))
    Dim intMaximoCarac_Titulos As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterTitulo"))
    Dim intMaximoPorLista As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoPorLista"))
    Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheListado"))

    Dim intColumna1 As Integer = 5
    Dim intColumna2 As Integer = 10
    Dim intColumna3 As Integer = 5
    Dim IntColumna4 As Integer = 40
    Dim Intcolumna5 As Integer = 45
    'Dim Intcolumna6 As Integer = 35
    'Dim Intcolumna7 As Integer = 35
    'Dim Intcolumna8 As Integer = 35
    'Dim Intcolumna9 As Integer = 35


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Not IsPostBack) Then
        Dim Expires As DateTime
        Expires = DateAdd(DateInterval.Minute, intTiempo, Now)
        Dim Listado As New List(Of InfoLoUltimo)
        Listado = CType(Cache("ListadoUltimo"), List(Of InfoLoUltimo))

        If Cache("ListadoUltimo") Is Nothing Then
            Listado = Sistema.PL.Negocio.LoUltimo.ListarLoUltimo(1)
            Cache.Insert("ListadoUltimo", Listado, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            'Cache("ListadoUltimo") = Listado
            'Response.Write("<script language = 'javascript'>alert('va al servidor'); </script>")
        End If

        listarTabla(Listado)


        'End If

    End Sub

    Sub listarTabla(ByVal Listado As List(Of InfoLoUltimo))

        'Dim row As New TableRow
        'row.Cells.Add(Html.CrearCelda("30%", "Tipo", HorizontalAlign.Center, "TablaEncabezado"))
        'row.Cells.Add(Html.CrearCelda("10%", "Tipo", HorizontalAlign.Center, "TablaEncabezado"))
        'row.Cells.Add(Html.CrearCelda("40%", "Titulo", HorizontalAlign.Center, "TablaEncabezado"))
        'row.Cells.Add(Html.CrearCelda("10%", "Autor", HorizontalAlign.Center, "TablaEncabezado"))
        'row.Cells.Add(Html.CrearCelda("10%", "Fecha", HorizontalAlign.Center, "TablaEncabezado"))


        'Me.tblResultado.Rows.Add(row)
        Dim intIndice = 0
        Dim strTipo As String
        Dim strTitulo As String

        For Each resultado As InfoLoUltimo In Listado
            Dim rowMenu As New TableRow()
            intIndice = intIndice + 1
            If intIndice < intMaximoPorLista Then

                Dim intMaxLegth As Integer
                If resultado.Autor.ToString().Length <= 20 Then
                    intMaxLegth = resultado.Autor.Length
                Else
                    intMaxLegth = 20
                End If
                If (intIndice Mod 2) = 0 Then
                    'OnMouseOver        
                    rowMenu.CssClass = "lu_content_box"
                    'rowMenu.CssClass = "filaoscura2"
                    'rowMenu.Attributes.Add("onmouseover", "this.className='filaoscura'")
                    'rowMenu.Attributes.Add("onmouseout", "this.className='filaoscura2'")

                    If resultado.Nombre_Seccion.ToString().Length > intMaximoCarac_Tipo Then
                        strTipo = resultado.Nombre_Seccion.ToString().Substring(0, intMaximoCarac_Tipo)
                    Else
                        strTipo = resultado.Nombre_Seccion.ToString()
                    End If

                    Dim intNewMaximoCarac_Titulos As Integer
                    Dim intrestar As Integer = 4
                    Dim intminimo As Integer = intMaximoCarac_Titulos - intrestar
                    If resultado.Titulo.ToString().IndexOf("&#") >= intminimo Then
                        intNewMaximoCarac_Titulos = intMaximoCarac_Titulos - (intrestar + 1)
                    Else
                        intNewMaximoCarac_Titulos = intMaximoCarac_Titulos
                    End If
                    If resultado.Titulo.ToString().Length > intNewMaximoCarac_Titulos Then

                        strTitulo = resultado.Titulo.ToString().Substring(0, intNewMaximoCarac_Titulos) & "..."
                    Else
                        strTitulo = resultado.Titulo.ToString()
                    End If

                    'rowMenu.Cells.Add(Html.CrearCelda("40%", resultado.Nombre_Seccion.ToString(), HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCeldaVisible(intColumna1.ToString() & "%", "<a href='#' class='link_btn_round_sm'> " & resultado.IdFila.ToString() & " </a>", HorizontalAlign.Left, "", False))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna2.ToString() & "%", "<a href='#' onclick=IraSeccion('" + resultado.IdSeccion.ToString() + "') class='link_btn_round_sm' onmouseover=this.style.cursor='hand'> " & strTipo.ToString() & " </a>", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna3.ToString() & "%", "<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'", HorizontalAlign.Center, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </a></h1> ", HorizontalAlign.Left, ""))
                    'rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><label id='Lbl_Articulo_" & resultado.PageId.ToString() & "' onclick=IraArticulo('" + resultado.PageId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </label></h1> ", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(Intcolumna5.ToString() & "%", "<span>Por <a onclick=IraPerfil('" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & resultado.Autor.ToString().Substring(0, intMaxLegth) & "  </a> el " & resultado.Fecha.ToString("dd/MM/yyyy") & " </span>", HorizontalAlign.Left, ""))
                    'rowMenu.Cells.Add(Html.CrearCelda("15%", "el " & resultado.Fecha.ToString("dd/MM/yyyy"), HorizontalAlign.Left, ""))resultado.AuthorId.ToString()


                Else
                    rowMenu.CssClass = "lu_content_box"
                    'rowMenu.CssClass = "filaclara2"
                    'rowMenu.Attributes.Add("onmouseover", "this.className='filaoscura'")
                    'rowMenu.Attributes.Add("onmouseout", "this.className='filaclara2'")


                    '<img class="lu_doc_icon" src="assets/imgs/doc_type_icons/doc.png" />

                    'rowMenu.Cells.Add(Html.CrearCelda("5%", "<img alt='Ir a FUI' id='Img_IraFUI_" + Convert.ToString(IntIndice) + "' onclick=IraFUI('" + QS.QSEncriptada + "') src='../../images/img_editar.gif' name='Img_IraFUI_" + Convert.ToString(IntIndice) + "' runat='server' onmouseover=this.style.cursor='hand' />", HorizontalAlign.Center, ""));

                    '<a href="#" class="link_btn_round_sm">Rompehielos</a>

                    If resultado.Nombre_Seccion.ToString().Length > intMaximoCarac_Tipo Then
                        strTipo = resultado.Nombre_Seccion.ToString().Substring(0, intMaximoCarac_Tipo)
                    Else
                        strTipo = resultado.Nombre_Seccion.ToString()
                    End If

                    Dim intNewMaximoCarac_Titulos As Integer
                    Dim intrestar As Integer = 4
                    Dim intminimo As Integer = intMaximoCarac_Titulos - intrestar
                    If resultado.Titulo.ToString().IndexOf("&#") >= intminimo Then
                        intNewMaximoCarac_Titulos = intMaximoCarac_Titulos - (intrestar + 1)
                    Else
                        intNewMaximoCarac_Titulos = intMaximoCarac_Titulos
                    End If
                    If resultado.Titulo.ToString().Length > intNewMaximoCarac_Titulos Then

                        strTitulo = resultado.Titulo.ToString().Substring(0, intNewMaximoCarac_Titulos) & "..."
                    Else
                        strTitulo = resultado.Titulo.ToString()
                    End If

                    'If resultado.Titulo.ToString().Length > intMaximoCarac_Titulos Then
                    '    strTitulo = resultado.Titulo.ToString().Substring(0, intMaximoCarac_Titulos) & "..."
                    'Else
                    '    strTitulo = resultado.Titulo.ToString()
                    'End If


                    rowMenu.Cells.Add(Html.CrearCeldaVisible(intColumna1.ToString() & "%", "<a href='#' class='link_btn_round_sm'> " & resultado.IdFila.ToString() & " </a>", HorizontalAlign.Left, "", False))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna2.ToString() & "%", "<a href='#' onclick=IraSeccion('" + resultado.IdSeccion.ToString() + "') class='link_btn_round_sm' onmouseover=this.style.cursor='hand'> " & strTipo.ToString() & " </a>", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna3.ToString() & "%", "<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'", HorizontalAlign.Center, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </a></h1> ", HorizontalAlign.Left, ""))
                    'rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><label id='Lbl_Articulo_" & resultado.PageId.ToString() & "' onclick=IraArticulo('" + resultado.PageId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </label></h1> ", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(Intcolumna5.ToString() & "%", "<span>Por <a onclick=IraPerfil('" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'>  " & resultado.Autor.ToString().Substring(0, intMaxLegth) & " </a> el " & resultado.Fecha.ToString("dd/MM/yyyy") & " </span>", HorizontalAlign.Left, ""))

                    'rowMenu.Cells.Add(Html.CrearCelda("15%", "el " & resultado.Fecha.ToString("dd/MM/yyyy"), HorizontalAlign.Left, ""))


                End If

                Me.tblResultado.Rows.Add(rowMenu)
            Else
                Exit For
            End If
        Next



    End Sub

End Class