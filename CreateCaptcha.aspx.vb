Imports System.Drawing
Imports System.Drawing.Imaging
Public Class CreateCaptcha
    Inherits System.Web.UI.Page
    Private rand As New Random()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CreateCaptchaImage()
        End If


    End Sub

    ''' <summary>  
    ''' method for create captcha image  
    ''' </summary>  
    Private Sub CreateCaptchaImage()
        Dim code As String = GetRandomText()
        Dim bitmap As New Bitmap(200, 60, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(bitmap)
        Dim pen As New Pen(Color.Yellow)
        Dim rect As New Rectangle(0, 0, 200, 60)
        Dim blue As New SolidBrush(Color.DarkRed)
        Dim black As New SolidBrush(Color.White)
        Dim counter As Integer = 0
        g.DrawRectangle(pen, rect)
        g.FillRectangle(blue, rect)

        For i As Integer = 0 To code.Length - 1
            g.DrawString(code(i).ToString(), _
                         New Font("Tahoma", 10 + rand.[Next](15, 20), _
                         FontStyle.Italic), black, New PointF(10 + counter, 10))
            counter += 28
        Next
        DrawRandomLines(g)
        bitmap.Save(Response.OutputStream, ImageFormat.Gif)
        g.Dispose()
        bitmap.Dispose()

    End Sub
    ''' <summary>  
    ''' Method for drawing lines  
    ''' </summary>  
    ''' <param name="g"></param>  
    Private Sub DrawRandomLines(ByVal g As Graphics)
        Dim yellow As New SolidBrush(Color.Yellow)
        For i As Integer = 0 To 19
            g.DrawLines(New Pen(yellow, 1), GetRandomPoints())
        Next

    End Sub
    ''' <summary>  
    ''' method for gettting random point position  
    ''' </summary>  
    ''' <returns></returns>  
    Private Function GetRandomPoints() As Point()
        Dim points As Point() = {New Point(rand.[Next](0, 150), rand.[Next](1, 150)), _
                                 New Point(rand.[Next](0, 200), rand.[Next](1, 190))}
        Return points
    End Function
    ''' <summary>  
    ''' Method for generating random text of 5 cahrecters as captcha code  
    ''' </summary>  
    ''' <returns></returns>  
    Private Function GetRandomText() As String
        Dim randomText As New StringBuilder()
        Dim alphabets As String = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz"
        Dim r As New Random()
        For j As Integer = 0 To 5
            randomText.Append(alphabets(r.[Next](alphabets.Length)))
        Next
        Session("CaptchaCode") = randomText.ToString()
        Return TryCast(Session("CaptchaCode"), [String])
    End Function

End Class