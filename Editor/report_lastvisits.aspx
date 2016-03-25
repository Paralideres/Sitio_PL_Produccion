

<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.Editor" %>


<script runat="server">


Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

Dim strSortBy As String = ""
Dim strSortDir As String = ""

Try
strSortBy = qs("sort_by")
Catch
End Try

Try
strSortDir = qs("sort_dir")
Catch
End Try

Try

If strSortBy = "" Then 

strSortBy = "Fecha"
strSortDir = "DESC"

End If

Me.PageTitle = "Los Ultimos Usuarios Registrados Que Entraron Usando Su Clave"
Me.PageContent = DisplayReport("proc_GetLastRegUsersLogged", True, strSortBy, strSortDir)

Catch ex As Exception

ShowError(ex)

Finally


End Try

End Sub


</script>
