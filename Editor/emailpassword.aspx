

<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.PageTemplate" %>

<%@ Import Namespace="Library_PL_Editor" %>


<script runat="server">


    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        Dim objReg As Library_PL_Editor.ParaLideres.Registration
        Dim strEmail As String = ""


        Try
            strEmail = Request("Email")
        Catch ex As Exception
        End Try


        Try

            Trace.Write("strEmail: " & strEmail)

            objReg = New Library_PL_Editor.ParaLideres.Registration

            If Request("send") = "yes" And strEmail <> "" Then

                Me.PageTitle = "Envio de Clave"
                Me.PageContent = objReg.SendPassword(strEmail)

            Else

                Me.PageTitle = "Enviar Clave Secreta"
                Me.PageContent = objReg.ForgotEmailForm(strEmail)

            End If

        Catch ex As Exception

            ShowError(ex)

        Finally

            objReg = Nothing

        End Try

    End Sub


</script>
