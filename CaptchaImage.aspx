
<%@ Page  %>

<script runat="server">


    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        Dim Rand As Random = New Random

        Dim iNum As Integer = 0

        Dim Bmp As System.Drawing.Bitmap = New System.Drawing.Bitmap(90, 30)
                
        Dim Gfx As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(Bmp)
        
        Dim Fnt As System.Drawing.Font = New System.Drawing.Font("Verdana", 14, System.Drawing.FontStyle.Bold)
                
        Dim RandY1 As Integer = 0
        Dim RandY2 As Integer = 0
        
        Try
            iNum = CInt(Request("x"))
        Catch ex As Exception
        End Try

        Try

            Trace.IsEnabled = False

            Gfx.DrawString(iNum.ToString, Fnt, System.Drawing.Brushes.LightGreen, 5, 5)
            
            RandY1 = Rand.Next(0, 30)
            RandY2 = Rand.Next(0, 30)

            ' Draw the first line 
            Gfx.DrawLine(System.Drawing.Pens.LightGreen, 0, RandY1, 90, RandY2)

            ' Create random numbers for the second line
            RandY1 = Rand.Next(0, 30)
            RandY2 = Rand.Next(0, 30)

            ' Draw the second line
            Gfx.DrawLine(System.Drawing.Pens.LightGreen, 0, RandY1, 90, RandY2)
            
            Bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif)

        Catch ex As Exception

            Throw ex

        Finally

            Bmp = Nothing

            Gfx = Nothing

        End Try

    End Sub


</script>
