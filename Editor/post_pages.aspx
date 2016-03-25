

<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.Editor" %>

<%@ Import Namespace="Sistema.PL.Entidad" %>

<%@ Import Namespace="Library_PL_Editor" %>


<script runat="server">


    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        Dim objPages As DataLayer.pages
        
        Dim sb As StringBuilder = New StringBuilder("")
        
        Dim intPageId As Integer = 0

        Dim intOriginalSection As Integer = 0

        Try
            intPageId = CInt(Request("page_id"))
        Catch
        End Try

        Try

            objPages = New DataLayer.pages(intPageId)

            intOriginalSection = objPages.getSectionId()

            objPages.setSectionId(CInt(Request("section_id")))

            objPages.setPosted(CDate(Request("posted")))

            objPages.setPageTitle(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("page_title")))

            objPages.setBlurb(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("blurb")))

            objPages.setBody(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("body")))

            objPages.setIsposted(Library_PL_Editor.ParaLideres.Functions.CheckBoxValToInt(Request("isposted")))

            objPages.setTypeofarticle(CInt(Request("typeofarticle")))

            objPages.setIsfeatured(Library_PL_Editor.ParaLideres.Functions.CheckBoxValToInt(Request("isfeatured")))

            objPages.setUserId(CInt(Request("user_id")))

            objPages.setKeywords(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("keywords")))

            objPages.setBook(CInt(Request("book")))

            objPages.setChapter(CInt(Request("chapter")))

            objPages.setRating(Library_PL_Editor.ParaLideres.Functions.CheckBoxValToInt(Request("rating")))

            If intPageId = 0 Then 'Insert New Record

                objPages.Add()

            Else 'Update Record

                
                '****** INICIO revisar si la fecha funcion bien 24-10-2014 RGM****'
                'Dim strTxtFecha = objPages.Posted.ToString()

                'sb.Append("<p> La fecha es :" & strTxtFecha.ToString() & "</p>")
                'Dim anio As String '= cadena.substring(0, 4)
                'Dim mes As String '= cadena.substring(3, 2)
                'Dim dia As String '= cadena.substring(5, 2)
                'dia = objPages.Posted.Day.ToString
                'mes = objPages.Posted.Month.ToString
                'anio = objPages.Posted.Year.ToString
                'sb.Append("<p> Primer cambio</p>")

                'sb.Append("<p> dia  es :" & dia.ToString() & "</p>")
                'sb.Append("<p> mes es :" & mes.ToString() & "</p>")
                'sb.Append("<p> año es :" & anio.ToString() & "</p>")

                ''Dim strSplitFecha As String()

                ''If strTxtFecha.IndexOf("/") > 0 Then
                ''    strSplitFecha = strTxtFecha.Split("/")
                ''    If strSplitFecha(0).Length = 2 Then
                ''        'entonces esta colocando el dia primero
                ''        dia = strSplitFecha(0)
                ''        mes = strSplitFecha(1)
                ''        anio = strSplitFecha(2)

                ''        sb.Append("<p> Segundo cambio</p>")

                ''        sb.Append("<p> dia  es :" & dia.ToString() & "</p>")
                ''        sb.Append("<p> mes es :" & mes.ToString() & "</p>")
                ''        sb.Append("<p> año es :" & anio.ToString() & "</p>")
                ''    End If
                ''    If strSplitFecha(0).Length = 4 Then
                ''        'entonces esta colocando el año primero
                ''        anio = strSplitFecha(0)
                ''        mes = strSplitFecha(1)
                ''        dia = strSplitFecha(2)
                ''        sb.Append("<p> Tercer cambio</p>")

                ''        sb.Append("<p> dia  es :" & dia.ToString() & "</p>")
                ''        sb.Append("<p> mes es :" & mes.ToString() & "</p>")
                ''        sb.Append("<p> año es :" & anio.ToString() & "</p>")
                ''    End If
                ''ElseIf strTxtFecha.IndexOf("-") > 0 Then
                ''    strSplitFecha = strTxtFecha.Split("-")
                ''    If strSplitFecha(0).Length = 2 Then
                ''        'entonces esta colocando el dia primero
                ''        dia = strSplitFecha(0)
                ''        mes = strSplitFecha(1)
                ''        anio = strSplitFecha(2)
                ''        sb.Append("<p> Cuarto cambio</p>")

                ''        sb.Append("<p> dia  es :" & dia.ToString() & "</p>")
                ''        sb.Append("<p> mes es :" & mes.ToString() & "</p>")
                ''        sb.Append("<p> año es :" & anio.ToString() & "</p>")
                ''    End If
                ''    If strSplitFecha(0).Length = 4 Then
                ''        'entonces esta colocando el año primero
                ''        anio = strSplitFecha(0)
                ''        mes = strSplitFecha(1)
                ''        dia = strSplitFecha(2)
                ''        sb.Append("<p> Quinto cambio</p>")

                ''        sb.Append("<p> dia  es :" & dia.ToString() & "</p>")
                ''        sb.Append("<p> mes es :" & mes.ToString() & "</p>")
                ''        sb.Append("<p> año es :" & anio.ToString() & "</p>")
                ''    End If
                ''End If


                ''dia = agregaCeroaIzq(dia)
                ''mes = agregaCeroaIzq(mes)
                ''anio = anio.Substring(0, 4)



                ''sb.Append("<p> Sexto cambio</p>")

                ''sb.Append("<p> dia  es :" & dia.ToString() & "</p>")
                ''sb.Append("<p> mes es :" & mes.ToString() & "</p>")
                ''sb.Append("<p> año es :" & anio.ToString() & "</p>")


                'Dim sqltxt As String = objPages.Update2().ToString()

                'sb.Append("<p> sqltxt es :" & sqltxt.ToString() & "</p>")
                
                '****** FIN revisar si la fecha funcion bien 24-10-2014 RGM****'
                
                objPages.Update()

                
   
                
            End If 'If intPageId = 0 Then 'Insert New Record


            If objPages.getIsposted = 1 Then


                Library_PL_Editor.ParaLideres.Functions.UpdateTotalNumberOfArticlesForSection(objPages.getSectionId)

            End If


            Dim objFile As HttpPostedFile

            Dim strFilePath As String = Server.MapPath(Me.ProjectPath & "files\")
            
            Dim strFileName As String = ""
            
            Dim strThumbnailFileName As String = ""
            
            Dim strExtension As String = ""
                               
         
            
            
            
            Trace.Write("strFilePath: " & strFilePath)

            Try

                objFile = Request.Files.Get("File")

                If objFile.ContentLength > 0 Then
                    
                    Trace.Write("objFile.ContentType: " & objFile.ContentType)
                            
                    strExtension = System.IO.Path.GetExtension(objFile.FileName)
                            
                    Trace.Write("File extension: " & strExtension)
                    
                    'Response.Write(strExtension.ToString)
                    
                    Select Case strExtension

                        Case ".doc"

                            strFileName = "pic_" & objPages.getPageId & ".doc"

                            Trace.Write(strFilePath & strFileName)

                            objFile.SaveAs(strFilePath & strFileName)

                            objPages.setPic(strFileName)
                            objPages.setTypeofarticle(2)
                            objPages.Update()
                            
                        Case ".docx"

                            strFileName = "pic_" & objPages.getPageId & ".docx"

                            Trace.Write(strFilePath & strFileName)

                            objFile.SaveAs(strFilePath & strFileName)

                            objPages.setPic(strFileName)
                            objPages.setTypeofarticle(2)
                            objPages.Update()
                            
                        Case ".pdf"

                            strFileName = "pic_" & objPages.getPageId & ".pdf"

                            objFile.SaveAs(strFilePath & strFileName)

                            Trace.Write(strFilePath & strFileName)

                            objPages.setPic(strFileName)
                            objPages.setTypeofarticle(2)
                            objPages.Update()
                            
                        Case ".ppt"

                            strFileName = "pic_" & objPages.getPageId & ".ppt"

                            objFile.SaveAs(strFilePath & strFileName)

                            Trace.Write(strFilePath & strFileName)

                            objPages.setPic(strFileName)
                            objPages.setTypeofarticle(2)
                            objPages.Update()
                            
                        Case ".pptx"

                            strFileName = "pic_" & objPages.getPageId & ".pptx"

                            objFile.SaveAs(strFilePath & strFileName)

                            Trace.Write(strFilePath & strFileName)

                            objPages.setPic(strFileName)
                            objPages.setTypeofarticle(2)
                            objPages.Update()
                            
                        Case ".jpg"

                            strFileName = "pic_" & objPages.getPageId & ".jpg"
                            
                            strThumbnailFileName = "pic_" & objPages.getPageId & "_sml.jpg"

                            objFile.SaveAs(strFilePath & strFileName)
                            
                            Library_PL_Editor.ParaLideres.ImageResize.ResizeImage(strFilePath & strFileName, 120, 0, strFilePath & strThumbnailFileName)
                            
                            Trace.Write(strFilePath & strFileName)

                            objPages.setPic(strFileName)
                            objPages.setTypeofarticle(1)
                            objPages.Update()

                        Case Else
                            
                            Library_PL_Editor.ParaLideres.Functions.SendMail(Library_PL_Editor.ParaLideres.Functions.SupportAccount, Library_PL_Editor.ParaLideres.Functions.DevelopAccount, "Bad document format", _objUser.getFirstName & " is trying to upload a " & objFile.ContentType & " file instead of a doc/pdf.")
                            'sb.Append("<br> pase por aqui 1")
                            
                            sb.Append("<br><br>El archivo que subiste no es de tipo doc o pfd.  Solo ese tipo de archivos son aceptados.")


                    End Select
                    
                    'sb.Append("<br> pase por aqui 2")
                    ' ''Select Case objFile.ContentType

                    ' ''    Case "application/msword"

                    ' ''        strFileName = "pic_" & objPages.getPageId & ".doc"

                    ' ''        Trace.Write(strFilePath & strFileName)

                    ' ''        objFile.SaveAs(strFilePath & strFileName)

                    ' ''        objPages.setPic(strFileName)
                    ' ''        objPages.setTypeofarticle(2)
                    ' ''        objPages.Update()

                    ' ''    Case "application/pdf"

                    ' ''        strFileName = "pic_" & objPages.getPageId & ".pdf"

                    ' ''        objFile.SaveAs(strFilePath & strFileName)

                    ' ''        Trace.Write(strFilePath & strFileName)

                    ' ''        objPages.setPic(strFileName)
                    ' ''        objPages.setTypeofarticle(2)
                    ' ''        objPages.Update()

                    ' ''    Case Else

                    ' ''        ParaLideres.Functions.SendMail(ParaLideres.Functions.SupportAccount, ParaLideres.Functions.DevelopAccount, "Bad document format", _objUser.getFirstName & " is trying to upload a " & objFile.ContentType & " file instead of a doc/pdf.")

                    ' ''        sb.Append("<br><br>El archivo que subiste no es de tipo doc o pfd.  Solo ese tipo de archivos son aceptados.")

                    ' ''End Select

                End If ' If objFile.ContentLength > 0 Then

            Catch ex As Exception
                
                Trace.Warn(ex.ToString())
                
                ShowError(ex)

            Finally

                If Not IsNothing(objFile) Then objFile = Nothing

            End Try


            If Request("notify") = "on" Then

                Dim objUser As DataLayer.reg_users

                Try

                    objUser = New DataLayer.reg_users(objPages.getUserId)

                    'Library_PL_Editor.ParaLideres.Functions.SendMail( & _
                    '                         Library_PL_Editor.ParaLideres.Functions.Contact, & _
                    '                         objUser.getEmail , & _
                    '                         "Artculo ha sido publicado en Para Lderes", & _
                    '                         "Este es un mensaje para indicarte que el artculo " & objPages.getPageTitle & " ha sido publicado en Para Lderes y est disponible.")

                    
                    
                    
                    Dim oEmail As New InfoEnvioMail

                    oEmail.De = Library_PL_Editor.ParaLideres.Functions.Contact
                    oEmail.Para = objUser.getEmail


                    oEmail.DesplieguedelNombre = System.Configuration.ConfigurationManager.AppSettings("Colabora_Titulo_DespliegueNombreAuto")
                    oEmail.Asunto = "Artículo ha sido publicado en Para Líderes"

                    oEmail.Contenido = "Este es un mensaje para indicarte que el artículo " & objPages.getPageTitle & " ha sido publicado en Para Líderes y está disponible."
                    Sistema.PL.Negocio.EMail.Enviar(oEmail)
                    
                Catch ex As Exception

                    Throw ex

                Finally

                    objUser = Nothing

                End Try

            End If


            If intOriginalSection = 0 Then intOriginalSection = objPages.getSectionId

            qs.Clear()
            qs("section_id") = intOriginalSection
            qs("web_section") = "sections"
            qs("action") = "main"
            qs("record_id") = 0

            If objPages.getSectionId = 17 Then GeneratePageContent() '17 is home page

            sb.Append("<p align=center><a href=" & ProjectPath & "Editor\editor.aspx?x=" & qs.ToString() & ">Continuar</a></p>")
            
            Select Case objPages.getSectionId
                
                Case 3 'Noticias
                    
                    Try
                        Cache.Remove("RSSFeedNoticias")
                    Catch ex As Exception
                    End Try
                   
                Case 335 'Blogs
                                        
                    Try
                        Cache.Remove("RSSFeedBlogs")
                    Catch ex As Exception
                    End Try
                
            End Select
            
            If objPages.getSectionId = 3 Then 'News
                
                
                                
            End If
                                                            
            Me.PageTitle = "Art&#237;culo Actualizado"
            Me.PageContent = sb.ToString()
            
        Catch ex As Exception

            ShowError(ex)

        Finally

            sb = Nothing
            objPages = Nothing

        End Try

    End Sub
    
    
    Private Sub GeneratePageContent()

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder("")

        Dim objArticle As DataLayer.pages

        Dim intPageId As Integer = 0

        Try

            sb.Append("<table width=530 cellpadding=0 cellspacing=2 border=0>")

            'TOP
            intPageId = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("HomeTop")

            Trace.Write("intPageId: " & intPageId)

            objArticle = New DataLayer.pages(intPageId)

            sb.Append("<tr><td colspan=2 class=Estilo1>" & objArticle.getBody & "<br><br></td></tr>")

            sb.Append("      <tr>")
            sb.Append("        <td colspan=2 align=""left"" background=""" & ProjectPath & "" & "_images/puntos_horizontales.gif"" ><img src=""" & ProjectPath & "_images/puntos_horizontales.gif"" width=""1"" height=""1""></td>")
            sb.Append("      </tr>")

            sb.Append("<tr>")

            'BOTTOM LEFT
            intPageId = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("HomeLeft")

            Trace.Write("intPageId: " & intPageId)

            objArticle = New DataLayer.pages(intPageId)
            sb.Append("<td class=Estilo1>" & objArticle.getBody & "</td>")

            'BOTTOM RIGHT
            intPageId = System.Web.Configuration.WebConfigurationManager.AppSettings.Get("HomeRight")

            Trace.Write("intPageId: " & intPageId)

            objArticle = New DataLayer.pages(intPageId)
            sb.Append("<td class=Estilo1>" & objArticle.getBody & "</td>")

            sb.Append("</tr>")

            sb.Append("</table>")
            
            Cache.Remove("HomePageContent")
            
            Cache.Insert("HomePageContent", sb.ToString())

        Catch ex As Exception

            ShowError(ex)

        Finally

            sb = Nothing

            objArticle = Nothing

        End Try


    End Sub

    Function agregaCeroaIzq(ByVal texto As String) As String
        Dim nuevotexto As String = ""
        If texto.Length = 1 Then
            nuevotexto = "0" & texto
        Else
            nuevotexto = texto
        End If
        Return nuevotexto
    End Function

</script>
