Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports Sistema.PL.Negocio.Util

Partial Public Class Cursos
    Inherits System.Web.UI.Page
    Dim strCursoOnline As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("CursoOnline"))
    Dim strCursoDescarga As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("CursoDescarga"))
    Dim intTiempo As Integer = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("TiempoCacheEncuesta"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '========================================================
        ' Si es la 1� carga de la pagina (Si no es PostBack)
        '========================================================
        If Not IsPostBack Then

            ' ''Dim ListadoCursos As New List(Of InfoCurso)
            ' ''ListadoCursos = NegCurso.TraerCursos()

            ' ''ListarTablaCurso(ListadoCursos)

            Dim Expires As DateTime
            Expires = DateAdd(DateInterval.Minute, intTiempo, Now)
            Dim ListadoCursos As New List(Of InfoCurso)
            ListadoCursos = CType(Cache("ListadoCursos"), List(Of InfoCurso))

            If Cache("ListadoCursos") Is Nothing Then
                ListadoCursos = NegCurso.TraerCursos()
                Cache.Insert("ListadoCursos", ListadoCursos, Nothing, Expires, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, Nothing)
            End If

            ListarTablaCurso(ListadoCursos)



        End If
    End Sub
    Sub ListarTablaCurso(ByVal Listado As List(Of InfoCurso))
        Dim intIndice = 0
        Dim StrBajar As String = "BAJAR"
        For Each resultado As InfoCurso In Listado
            Dim rowMenu As New TableRow()
            intIndice = intIndice + 1
            If resultado.zip.ToString = "" Then
                StrBajar = " "
            Else
                StrBajar = "BAJAR"
            End If
            If (intIndice Mod 2) = 0 Then
                rowMenu.CssClass = "lu_content_box"

                rowMenu.Cells.Add(Html.CrearCelda("50%", resultado.title.ToString(), HorizontalAlign.Left, ""))
                rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
                rowMenu.Cells.Add(Html.CrearCelda("20%", "<a href='" & strCursoOnline & resultado.on_line.ToString & "' onmouseover=this.style.cursor='hand'> TOMAR EN LINEA </a> ", HorizontalAlign.Center, ""))
                rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
                rowMenu.Cells.Add(Html.CrearCelda("20%", "<a href='" & strCursoDescarga & resultado.zip.ToString & "' onmouseover=this.style.cursor='hand'> " & StrBajar.ToString & " </a> ", HorizontalAlign.Center, ""))
            Else
                rowMenu.CssClass = "lu_content_box"
                '
                rowMenu.Cells.Add(Html.CrearCelda("50%", resultado.title.ToString(), HorizontalAlign.Left, ""))
                rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
                rowMenu.Cells.Add(Html.CrearCelda("20%", "<a href='" & strCursoOnline & resultado.on_line.ToString & "' onmouseover=this.style.cursor='hand'> TOMAR EN LINEA </a> ", HorizontalAlign.Center, ""))
                rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
                rowMenu.Cells.Add(Html.CrearCelda("20%", "<a href='" & strCursoDescarga & resultado.zip.ToString & "' onmouseover=this.style.cursor='hand'> " & StrBajar.ToString & " </a> ", HorizontalAlign.Center, ""))
            End If

            Me.tblResultado.Rows.Add(rowMenu)
            AgregarLineaVacia(intIndice)

        Next

    End Sub
    Sub AgregarLineaVacia(ByVal intIndice As Integer)
        Dim rowMenu As New TableRow()

        If (intIndice Mod 2) = 0 Then
            rowMenu.CssClass = "lu_content_box"

            rowMenu.Cells.Add(Html.CrearCelda("50%", " </br>", HorizontalAlign.Left, ""))
            rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
            rowMenu.Cells.Add(Html.CrearCelda("20%", "", HorizontalAlign.Center, ""))
            rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
            rowMenu.Cells.Add(Html.CrearCelda("20%", " ", HorizontalAlign.Center, ""))
        Else
            rowMenu.CssClass = "lu_content_box"
            rowMenu.Cells.Add(Html.CrearCelda("50%", " </br>", HorizontalAlign.Left, ""))
            rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
            rowMenu.Cells.Add(Html.CrearCelda("20%", "", HorizontalAlign.Center, ""))
            rowMenu.Cells.Add(Html.CrearCelda("5%", " ", HorizontalAlign.Center, ""))
            rowMenu.Cells.Add(Html.CrearCelda("20%", " ", HorizontalAlign.Center, ""))

        End If

        Me.tblResultado.Rows.Add(rowMenu)
    End Sub


End Class
