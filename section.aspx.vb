
Partial Class section
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Dim IdSeccion As Integer
            IdSeccion = Request.QueryString("section_id").ToString()
            Response.Redirect("Secciones.aspx?Ide=" & IdSeccion & "&Pag=1")
            'http://paralideres.org/section.aspx?section_id=112&index=0
            
        End If
    End Sub
End Class
