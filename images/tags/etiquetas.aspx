
<%@ Page Language="VB" AutoEventWireup="false" Inherits="ParaLideres.PageTemplate" %>

<script runat="server">


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                   
        Dim sb As New System.Text.StringBuilder("")
                
        Dim intPageId As Integer = 0
        
        Dim strLink As String = ""
	    
        Try
            intPageId = CInt(Request("page_id"))
        Catch
        End Try

        Try
            
            strLink = "http://www.paraliders.org/page_id=" & intPageId
            
            sb.Append("Contenido de la pagina linea 1<br>")
            sb.Append("Contenido de la pagina linea 2<br>")
            sb.Append("Contenido de la pagina linea 3<br>")
            sb.Append("Contenido de la pagina linea 4<br>")
                        
            sb.Append(Etiquetas(strLink))
            
            Me.PageTitle = "Titulo de la pagian"
            Me.PageContent = sb.ToString

        Catch ex As Exception

            ShowError(ex)

        Finally

            sb = Nothing

        End Try

    End Sub

    
    Public Function Etiquetas(ByVal strLink As String) As String
        
        Dim sb As StringBuilder = New StringBuilder("")

        Try


            sb.Append("	<div id='extras'>" & vbCrLf)

            sb.Append("		<div id='tags'>Etiquetas:<br>" & vbCrLf)

            sb.Append("		<a href=""http://www.futbolecuador.com/stories/tags/ecuatorianos_en_el_exterior"">ecuatorianos en el exterior</a> <a href=""http://www.futbolecuador.com/stories/tags/internacional"">internacional</a> <a href=""http://www.futbolecuador.com/stories/tags/joffre_guerr�n"">joffre guerr�n</a> 		</div>" & vbCrLf)

            sb.Append("		<div id='share'>Compartir esta Noticia:<br>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://www.facebook.com/share.php?u=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_facebook2.png"" border=""0"" id=""facebook"" name=""facebook"" onmouseover=""document.facebook.src='" & ProjectPath & "images/tags/ico_facebook.gif'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a facebook""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://del.icio.us/post?title=&url=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_delicious.gif"" border=""0"" id=""delicious"" name=""delicous"" onmouseover=""document.delicious.src='" & ProjectPath & "images/tags/ico_delicious.gif'"" onmouseover=""MM_swapImage('delicious','','http://www.futbolecuador.com/imagenes/icons/ico_delicious.gif',1)"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a delicious""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://myweb2.search.yahoo.com/myresults/bookmarklet?u=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_yahoo2.png"" border=""0"" id=""yahoo"" name=""yahoo"" onmouseover=""document.yahoo.src='" & ProjectPath & "images/tags/ico_yahoo.gif'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a Yahoo""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://meneame.net/submit.php?url=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_meneame2.png"" border=""0"" id=""meneame"" name=""meneame"" onmouseover=""document.meneame.src='" & ProjectPath & "images/tags/ico_meneame.gif'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a meneame""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://www.digg.com/submit?url=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_digg2.png"" border=""0"" id=""digg"" name=""digg"" onmouseover=""document.digg.src='" & ProjectPath & "images/tags/ico_digg.gif'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a digg""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://www.mister-wong.es/addurl/?bm_url=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_mister_wong2.png"" border=""0"" id=""mwong"" name=""mwong""  onmouseover=""document.mwong.src='" & ProjectPath & "images/tags/ico_mister_wong.gif'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a mister-wong""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://www.google.com/bookmarks/mark?op=edit&bkmk=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_google2.png"" border=""0"" id=""google"" name=""google"" onmouseover=""document.google.src='" & ProjectPath & "images/tags/ico_google.png'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a google""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://twitthis.com/twit?url=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_twitter2.png"" border=""0"" id=""twitthis"" name=""twitthis"" onmouseover=""document.twitthis.src='" & ProjectPath & "images/tags/ico_twitter.png'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a twitter""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='' onClick='Modalbox.show(""" & strLink & """, {title: "" "", width: 430 ,overlayClose: false}); return false;' ><img src=""" & ProjectPath & "images/tags/ico_email_link2.png"" border=""0"" id=""enviar"" name=""enviar"" onmouseover=""document.enviar.src='" & ProjectPath & "images/tags/ico_email_link.png'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a un amigo""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_imprimir2.png"" border=""0"" id=""print"" name=""print"" onmouseover=""document.print.src='" & ProjectPath & "images/tags/ico_imprimir.png'"" onmouseout=""MM_swapImgRestore()"" alt=""Imprime la noticia""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href='http://technorati.com/faves?add=" & strLink & "'><img src=""" & ProjectPath & "images/tags/ico_technorati2.png"" border=""0"" id=""technorati"" name=""technorati"" onmouseover=""document.technorati.src='" & ProjectPath & "images/tags/ico_technorati2.png'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a technorati""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href=""http://www.myspace.com/Modules/PostTo/Pages/?u=" & strLink & """ ><img src=""" & ProjectPath & "images/tags/3.jpg"" border=""0"" id=""myspace"" name=""myspace"" onmouseover=""document.myspace.src='" & ProjectPath & "images/tags/3.jpg'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a myspace""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href=""https://favorites.live.com/quickadd.aspx?marklet=1&amp;mkt=en-us&amp;url=" & strLink & """><img src=""" & ProjectPath & "images/tags/8.jpg"" border=""0"" id=""live"" name=""live"" onmouseover=""document.live.src='" & ProjectPath & "images/tags/8.jpg'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a live""/></a>" & vbCrLf)

            sb.Append("		<a target='_blank' href=""http://www.stumbleupon.com/submit?url=" & strLink & """><img src=""" & ProjectPath & "images/tags/9.jpg"" border=""0"" id=""stumbleupon"" name=""stumbleupon"" onmouseover=""document.stumbleupon.src='" & ProjectPath & "images/tags/9.jpg'"" onmouseout=""MM_swapImgRestore()"" alt=""Envia a stumbleupon""/></a>" & vbCrLf)

            sb.Append("		</div>" & vbCrLf)

            sb.Append("	</div>" & vbCrLf)

            Return sb.ToString()

        Catch ex As Exception

            Trace.Warn(ex.ToString())

            Throw ex

        Finally

            sb = Nothing

        End Try

    End Function


</script>
