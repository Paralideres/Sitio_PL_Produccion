

<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.PageTemplate" %>

<%@ Import Namespace="Library_PL_Editor" %>




<script runat="server">


    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        'Me.Trace.IsEnabled = True

        If IsNothing(Request.UrlReferrer()) Then Response.Redirect("editor.aspx")

        If InStr(Request.UrlReferrer.AbsolutePath(), "editor.aspx") > 0 Then

            Dim strUsername As String = ""
            Dim strPassword As String = ""

            Try

                strUsername = Request.Form("username")
                strPassword = Request.Form("password")

            Catch ex As Exception

            End Try


            Try


                Dim objUser As Library_PL_Editor.ParaLideres.User

                Try

                    objUser = New Library_PL_Editor.ParaLideres.User(0)

                    Session("letmein") = objUser.LogonToEditor(strUsername, strPassword)

                Catch

                    Session("letmein") = -1

                Finally

                    objUser = Nothing

                End Try

                Response.Redirect("editor.aspx")

            Catch ex As Exception

                Response.Redirect("editor.aspx")

            End Try

        End If

    End Sub


</script>
