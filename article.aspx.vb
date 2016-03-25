Public Partial Class article
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim IdPagina As Integer
            IdPagina = Request.QueryString("page_id").ToString()
            Response.Redirect("VerArticulo.aspx?Idp=" & IdPagina & "&pag=1")
            'http://paralideres.org/article.aspx?page_id=6198&index=1&search_param=

        End If
    End Sub

End Class