Public Partial Class frameCalendario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Page.IsPostBack = False) Then
            myFecha.Value = Request.Params("strFecha")


        End If
    End Sub

End Class