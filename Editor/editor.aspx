
<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.Editor" %>

<script runat="server">

    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)
        
        Dim intSectionId As Integer = 0
        Dim strWebSection As String = ""
        Dim strAction As String = ""

        Try

            intSectionId = CInt(qs("section_id"))
            strWebSection = qs("web_section")
            strAction = qs("action")

            _strAlpha = qs("alpha")

        Catch ex As Exception

        End Try

        Try

            If Request.Form.HasKeys() Then

                strWebSection = Request.Form("web_section")
                strAction = Request.Form("action")

            End If

            Select Case strWebSection

                Case ""

                    Me.PageTitle = "Bienvenido al Editor de Para Lderes.org"

                Case "sections"

                    If intSectionId > 0 Then

                        Me.PageTitle = UCase(GetSectionName(intSectionId))

                    Else

                        Me.PageTitle = "SECCIONES"

                    End If

                Case "articles"

                    Me.PageTitle = "ARTICULOS"

                Case "users"

                    Me.PageTitle = "USUARIOS"

                Case "cursos"

                    Me.PageTitle = "CURSOS"

                Case "surveys"

                    Me.PageTitle = "ENCUESTAS"

                Case Else

                    Me.PageTitle = "EN CONSTRUCCION"

            End Select


            Trace.Write("--------------------------------------------------------")
            Trace.Write("strWebSection :" & strWebSection)
            Trace.Write("strAction :" & strAction)
            Trace.Write("intSectionId :" & intSectionId)
            Trace.Write("--------------------------------------------------------")

            Me.PageContent = EditorContent(strWebSection, strAction, intSectionId)

            
        Catch ex As Exception

            ShowError(ex)

            Trace.Write("ERROR on editor.aspx:" & ex.Source & " " & ex.Message)

        End Try

    End Sub


</script>
