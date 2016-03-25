Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio.Util

Partial Public Class Lista_LoPopular
    Inherits System.Web.UI.Page
    Dim intMaximoCarac_Tipo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterTipo"))
    Dim intMaximoCarac_Titulos As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoCaracterTitulo"))
    Dim intMaximoPorLista As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("MaximoPorLista"))
    Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheListado"))
    Dim intColumna1 As Integer = 10
    Dim intColumna2 As Integer = 5
    Dim intColumna3 As Integer = 40
    Dim IntColumna4 As Integer = 45
    Dim Intcolumna5 As Integer = 45
    'Dim Intcolumna6 As Integer = 35
    'Dim Intcolumna7 As Integer = 35
    'Dim Intcolumna8 As Integer = 35
    'Dim Intcolumna9 As Integer = 35
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''If (Not IsPostBack) Then
        ' ''Dim ListadoLoPop As New List(Of InfoLoPopular)

        ' ''ListadoLoPop = Sistema.PL.Negocio.LoPopular.ListarLoPopular(1)

        ' ''listarTabla(ListadoLoPop)


        Dim Expires As DateTime
        Expires = DateAdd(DateInterval.Minute, intTiempo, Now)
        Dim ListadoLoPop As New List(Of InfoLoPopular)
        ListadoLoPop = CType(Cache("ListadoPopular"), List(Of InfoLoPopular))

        If Cache("ListadoPopular") Is Nothing Then
            ListadoLoPop = Sistema.PL.Negocio.LoPopular.ListarLoPopular(1)
            Cache.Insert("ListadoPopular", ListadoLoPop, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
        End If

        listarTabla(ListadoLoPop)




        ''End If

    End Sub

    Sub listarTabla(ByVal Listado As List(Of InfoLoPopular))

        Dim intIndice = 0
        Dim strTipo As String
        Dim strTitulo As String
        For Each resultado As InfoLoPopular In Listado
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
                    rowMenu.CssClass = "lu_content_box"
                    If resultado.Nombre_Seccion.ToString().Length > intMaximoCarac_Tipo Then
                        strTipo = resultado.Nombre_Seccion.ToString().Substring(0, intMaximoCarac_Tipo)
                    Else
                        strTipo = resultado.Nombre_Seccion.ToString()
                    End If

                    'If resultado.Titulo.ToString().Length > intMaximoCarac_Titulos Then
                    '    strTitulo = resultado.Titulo.ToString().Substring(0, intMaximoCarac_Titulos) & "..."
                    'Else
                    '    strTitulo = resultado.Titulo.ToString()
                    'End If


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


                    rowMenu.Cells.Add(Html.CrearCelda(intColumna1.ToString() & "%", "<a href='#' onclick=IraSeccion('" + resultado.IdSeccion.ToString() + "') class='link_btn_round_sm'> " & strTipo.ToString() & " </a>", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna2.ToString() & "%", "<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'", HorizontalAlign.Center, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </a></h1> ", HorizontalAlign.Left, ""))
                    'rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><label id='Lbl_Articulo_" & resultado.PageId.ToString() & "' onclick=IraArticulo('" + resultado.PageId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </label></h1> ", HorizontalAlign.Left, ""))

                    rowMenu.Cells.Add(Html.CrearCelda(Intcolumna5.ToString() & "%", "<span>Por <a href='#' onclick=IraPerfil('" + resultado.AuthorId.ToString() + "')> " & resultado.Autor.ToString().Substring(0, intMaxLegth) & " </a> el " & resultado.Fecha.ToString("dd/MM/yyyy") & " </span>", HorizontalAlign.Left, ""))
                Else
                    rowMenu.CssClass = "lu_content_box"
                    If resultado.Nombre_Seccion.ToString().Length > intMaximoCarac_Tipo Then
                        strTipo = resultado.Nombre_Seccion.ToString().Substring(0, intMaximoCarac_Tipo)
                    Else
                        strTipo = resultado.Nombre_Seccion.ToString()
                    End If

                    'If resultado.Titulo.ToString().Length > intMaximoCarac_Titulos Then
                    '    strTitulo = resultado.Titulo.ToString().Substring(0, intMaximoCarac_Titulos) & "..."
                    'Else
                    '    strTitulo = resultado.Titulo.ToString()
                    'End If

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

                    rowMenu.Cells.Add(Html.CrearCelda(intColumna1.ToString() & "%", "<a href='#' onclick=IraSeccion('" + resultado.IdSeccion.ToString() + "') class='link_btn_round_sm'> " & strTipo.ToString() & " </a>", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(intColumna2.ToString() & "%", "<img class='lu_doc_icon' src='assets/imgs/doc_type_icons/doc.png' id='Img_Ira_" & resultado.PageId.ToString() & "' runat='server' onmouseover=this.style.cursor='hand'", HorizontalAlign.Center, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><a onclick=IraArticulo('" + resultado.PageId.ToString() + "','" + resultado.AuthorId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </a></h1> ", HorizontalAlign.Left, ""))
                    'rowMenu.Cells.Add(Html.CrearCelda(IntColumna4.ToString() & "%", "<h1><label id='Lbl_Articulo_" & resultado.PageId.ToString() & "' onclick=IraArticulo('" + resultado.PageId.ToString() + "') onmouseover=this.style.cursor='hand'> " & strTitulo.ToString() & " </label></h1> ", HorizontalAlign.Left, ""))
                    rowMenu.Cells.Add(Html.CrearCelda(Intcolumna5.ToString() & "%", "<span>Por <a href='#' onclick=IraPerfil('" + resultado.AuthorId.ToString() + "')> " & resultado.Autor.ToString().Substring(0, intMaxLegth) & " </a> el " & resultado.Fecha.ToString("dd/MM/yyyy") & " </span>", HorizontalAlign.Left, ""))
                End If
                Me.tblResultado.Rows.Add(rowMenu)
            Else
                Exit For
            End If
        Next
    End Sub
End Class