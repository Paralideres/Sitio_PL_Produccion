

<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.Editor" %>

<%@ Import Namespace="Library_PL_Editor" %>


<script runat="server">


    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        Trace.Write("LOAD")

        Dim objSections As DataLayer.sections

        Dim intSectionId As Integer = 0
        Dim intParentId As Integer = 0
        Dim intPostInMenu As Integer = 0

        Try
            intSectionId = CInt(Request("section_id"))
        Catch
        End Try

        Try
            intParentId = CInt(Request("section_parent"))
        Catch ex As Exception
        End Try

        Try
            intPostInMenu = CInt(Request("post_in_menu"))
        Catch ex As Exception
        End Try

        Try

            objSections = New DataLayer.sections(intSectionId)

            objSections.setSectionName(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("section_name")))

            'If ((intPostInMenu <> objSections.getPostInMenu) Or (intParentId <> objSections.getSectionParent)) And ((intParentId = 0) Or (objSections.getSectionParent = 0)) Then

            '    'we need to re-generate the menu of the public site

            '    Cache.Remove("LeftMenu")

            'End If

            objSections.setSectionParent(intParentId)

            objSections.setPostInMenu(intPostInMenu)

            objSections.setBlurb(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("blurb")))

            objSections.setPagetext(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("pagetext")))

            objSections.setUserId(CInt(Request("user_id")))

            objSections.setLastModified(Date.Today)

            objSections.setModBy(_objUser.getId)

            'objSections.setShowOnDroplist(CInt(Request("show_on_droplist")))

            If intSectionId = 0 Then 'Insert New Record

                objSections.Add()

            Else 'Update Record

                objSections.Update()

            End If 'If intSectionId = 0 Then 'Insert New Record

            Cache.Remove("LeftMenu") 'This clears the cache 
            Cache.Remove("SubSenctions" & intParentId) 'clears cache
            
            qs.Clear()

            qs("section_id") = objSections.getSectionParent
            qs("web_section") = "sections"
            qs("action") = "main"

            Response.Redirect("editor.aspx?x=" & qs.ToString())

        Catch ex As Exception

            ShowError(ex)

        Finally

            objSections = Nothing

        End Try
    End Sub


</script>
