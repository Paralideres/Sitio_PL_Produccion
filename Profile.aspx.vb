Imports Sistema.PL.Negocio
Imports Sistema.PL.Entidad

Partial Public Class Profile
    Inherits System.Web.UI.Page
    Dim strPathImagenAuthor As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("PathImagenAuthor"))
    Dim strimagenAuthorporDefecto As String = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings("imagenAuthorporDefecto"))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim oAutor As New InfoAutor
            Dim IdAutor As Integer
            Dim IdPaginaListaAutor As Integer
            IdAutor = Request.QueryString("Id_Autor").ToString()
            Try
                IdPaginaListaAutor = Request.QueryString("pag").ToString()
            Catch ex As Exception
                IdPaginaListaAutor = 1
            End Try
            oAutor = Autor.TraerAutor(IdAutor)

            lblNombre.InnerHtml = oAutor.Nombre.ToString()
            LblCiudad.InnerHtml = oAutor.Ciudad.ToString()
            LblPais.InnerText = oAutor.Pais.ToString()
            LblFecha.InnerText = oAutor.Fecha_Desde.ToString("dd/MM/yyyy")
            LblEmail.InnerText = oAutor.Email.ToString()
            LblResena.InnerHtml = oAutor.Resena.ToString()
            If oAutor.FotoAutho.ToString <> "" Then
                ImgAutor.Src = strPathImagenAuthor & oAutor.FotoAutho.ToString
            Else
                ImgAutor.Src = strimagenAuthorporDefecto.ToString
            End If

            TituloPerfil.InnerHtml = "Perfil de " & oAutor.Nombre.ToString() & " | " & "ParaLideres.org"
            Lst_delAutor.HRef = "Lista_DelAutor.aspx?Ida=" & IdAutor & "&Pag=" & IdPaginaListaAutor

        End If

    End Sub

End Class