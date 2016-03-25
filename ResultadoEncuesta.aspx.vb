Imports Sistema.PL.Entidad
Imports Sistema.PL.Negocio
Imports System.Web.Services
Imports Sistema.PL.Filtros
Imports ParaLideres

Partial Public Class ResultadoEncuesta
    Inherits System.Web.UI.Page
    Dim oResultadoEncuesta As InfoResultadoEncuesta
    Dim oPreguntasYRespuestas As New List(Of String)

    Dim _project_path As String = System.Configuration.ConfigurationManager.AppSettings("ProjectPath")
    Dim _ValorAnchoTabla As String = System.Configuration.ConfigurationManager.AppSettings("ValorAnchoTabla")
    Dim _ValorAnchoCellLeft As String = System.Configuration.ConfigurationManager.AppSettings("ValorAnchoCellLeft")
    Dim _ValorAnchoCellRight As String = System.Configuration.ConfigurationManager.AppSettings("ValorAnchoCellRight")
    Dim _TextoCuandoNoHayGrafico As String = System.Configuration.ConfigurationManager.AppSettings("TextoCuandoNoHayGrafico")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intIdPregunta As Integer
        Try
            intIdPregunta = Request.QueryString("IdPr").ToString
        Catch ex As Exception
        End Try
        oResultadoEncuesta = New InfoResultadoEncuesta
        oResultadoEncuesta = Pregunta.ResultadoPregunta(intIdPregunta)

        If oResultadoEncuesta.Id_Pregunta <> 0 Then
            lblResultado.InnerHtml = DesplegarGrafico(oResultadoEncuesta)
        Else
            lblResultado.InnerHtml = _TextoCuandoNoHayGrafico
        End If

    End Sub
    Function DesplegarGrafico(ByVal oResultadoEncuesta As InfoResultadoEncuesta) As String
        Dim sb As New System.Text.StringBuilder("")

        Dim intIndex As Integer = 0
        Dim intBarWidth As Integer = 0
        Dim intBarHeight As Integer = 5

        Dim dblPercentage As Double = 0
        Dim dblProportion As Double = 0.5
        'Dim _intTableWidth As Integer = _ValorAnchoTabla
        'Dim _intLeftCellWidth As Integer = _ValorAnchoCellLeft
        'Dim _intRightCellWidth As Integer = _ValorAnchoCellRight


        Dim _intTableWidth As Integer = 700
        Dim _intLeftCellWidthNomnbre As Integer = 120
        Dim _intLeftCellWidth As Integer = 100
        Dim _intRightCellWidth As Integer = 25
        Dim _intRightCellWidthVotos As Integer = 70







        Dim blShowHeaderRow As Boolean = True

        Dim intSumaTotalVotos As Integer = 0
        If oResultadoEncuesta.strRespuesta_1 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_1 & "|" & oResultadoEncuesta.Respuesta_1.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_1.ToString())
        End If

        If oResultadoEncuesta.strRespuesta_2 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_2 & "|" & oResultadoEncuesta.Respuesta_2.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_2.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_3 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_3 & "|" & oResultadoEncuesta.Respuesta_3.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_3.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_4 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_4 & "|" & oResultadoEncuesta.Respuesta_4.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_4.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_5 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_5 & "|" & oResultadoEncuesta.Respuesta_5.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_5.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_6 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_6 & "|" & oResultadoEncuesta.Respuesta_6.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_6.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_7 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_7 & "|" & oResultadoEncuesta.Respuesta_7.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_7.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_8 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_8 & "|" & oResultadoEncuesta.Respuesta_8.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_8.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_9 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_9 & "|" & oResultadoEncuesta.Respuesta_9.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_9.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_10 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_10 & "|" & oResultadoEncuesta.Respuesta_10.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_10.ToString())
        End If
        Try
            dblProportion = 2
            intBarHeight = 20
            blShowHeaderRow = False
            sb.Append("<br />          <table width=""" & _intTableWidth & """ border=""0"" cellspacing=""0"" cellpadding=""0"">")
            sb.Append("            <tr>")
            sb.Append("              <td height=""37"" colspan=""6"" align=center><span class=""Estilo1""><b>" & oResultadoEncuesta.strPregunta & "</b></span><br><br></td>")
            sb.Append("            </tr>")
            sb.Append("            <tr>")
            sb.Append("              <td height=""37"" colspan=""6"" align=center><span class=""Estilo1""><b>Desde: " & Funcion.FormatHispanicDateTime(oResultadoEncuesta.FechaInicio) & " - Hasta: " & Funcion.FormatHispanicDateTime(oResultadoEncuesta.FechaFin) & "</b></span><br><br></td>")
            sb.Append("            </tr>")
            Dim intIndice As Integer = 0
            For intIndice = 0 To oPreguntasYRespuestas.Count - 1
                Dim strResult As String() = oPreguntasYRespuestas(intIndice).ToString.Split("|")
                If intSumaTotalVotos > 0 Then

                    dblPercentage = strResult(1) / intSumaTotalVotos * 100

                    intBarWidth = Int(dblPercentage * dblProportion)

                End If

                'sb.Append("            <tr border=""1"">")
                'sb.Append("              <td width=""" & _intRightCellWidth & """><span class=""Estilo1""></span></td>")
                'sb.Append("              <td width=""" & _intLeftCellWidth & """><span class=""Estilo1"">" & strResult(0) & "</span></td>")
                'sb.Append("              <td width=""" & _intLeftCellWidth & """><img src=./images/survey_bar.gif height=" & intBarHeight & " width=" & intBarWidth & " border=1></td>")
                'sb.Append("              <td width=""" & _intRightCellWidth & """  valign=bottom  align=right class=""Estilo1"">" & FormatNumber(strResult(1).ToString(), 0) & " votos</td>")
                'sb.Append("              <td width=""" & _intRightCellWidth & """  valign=bottom  align=right class=""Estilo1""><b>" & FormatNumber(dblPercentage.ToString(), 2) & "%</b></td>")
                'sb.Append("              <td width=""" & _intRightCellWidth & """><span class=""Estilo1""></span></td>")
                'sb.Append("            </tr>")




                sb.Append("            <tr border=""1"">")
                sb.Append("              <td width=""" & _intRightCellWidth & """><span class=""Estilo1""></span></td>")
                sb.Append("              <td width=""" & _intLeftCellWidthNomnbre & """><span class=""Estilo1"">" & strResult(0) & "</span></td>")
                sb.Append("              <td width=""" & _intLeftCellWidth & """><img src=./images/survey_bar.gif height=" & intBarHeight & " width=" & intBarWidth & " border=1></td>")
                sb.Append("              <td width=""" & _intRightCellWidthVotos & """  valign=bottom  align=right class=""Estilo1"">" & FormatNumber(strResult(1).ToString(), 0) & " votos</td>")
                sb.Append("              <td width=""" & _intRightCellWidth & """  valign=bottom  align=right class=""Estilo1""><b>" & FormatNumber(dblPercentage.ToString(), 2) & "%</b></td>")
                sb.Append("              <td width=""" & _intRightCellWidth & """><span class=""Estilo1""></span></td>")
                sb.Append("            </tr>")
                sb.Append("            <tr><td colspan=2 height=3></td></tr>")

                sb.Append("            <tr><td colspan=2 height=3></td></tr>")
            Next









            'Show Total Number of Votes
            If intSumaTotalVotos > 0 Then

                sb.Append("            <tr>")
                sb.Append("              <td colspan=5 class=""Estilo1"" align=center><b>N&#250;mero total de votos: " & intSumaTotalVotos & "</b></td>")
                sb.Append("            </tr>")

            End If

            sb.Append("          </table>")

            Return sb.ToString()

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    <WebMethod()> Public Shared Function BuscarByFiltros(ByVal oFiltro As FiltroPregunta) As List(Of InfoPregunta)
        Return Sistema.PL.Negocio.Pregunta.BuscarByFiltros(oFiltro)
    End Function
    <WebMethod()> Public Shared Function BuscarGrafico(ByVal intIdPregunta As Integer) As String
        Dim oResultadoEncuesta As InfoResultadoEncuesta
        oResultadoEncuesta = New InfoResultadoEncuesta
        oResultadoEncuesta = Pregunta.ResultadoPregunta(intIdPregunta)


        Dim sb As New System.Text.StringBuilder("")

        Dim intIndex As Integer = 0
        Dim intBarWidth As Integer = 0
        Dim intBarHeight As Integer = 5

        Dim dblPercentage As Double = 0
        Dim dblProportion As Double = 0.5
        Dim _intTableWidth As Integer = 700
        'Dim _intLeftCellWidth As Integer = 100
        'Dim _intRightCellWidth As Integer = 50
        Dim _intLeftCellWidthNomnbre As Integer = 120
        Dim _intLeftCellWidth As Integer = 100
        Dim _intRightCellWidth As Integer = 25
        Dim _intRightCellWidthVotos As Integer = 70
        Dim blShowHeaderRow As Boolean = True
        Dim intSumaTotalVotos As Integer = 0
        Dim oPreguntasYRespuestas As New List(Of String)


        If oResultadoEncuesta.strRespuesta_1 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_1 & "|" & oResultadoEncuesta.Respuesta_1.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_1.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_2 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_2 & "|" & oResultadoEncuesta.Respuesta_2.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_2.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_3 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_3 & "|" & oResultadoEncuesta.Respuesta_3.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_3.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_4 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_4 & "|" & oResultadoEncuesta.Respuesta_4.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_4.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_5 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_5 & "|" & oResultadoEncuesta.Respuesta_5.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_5.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_6 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_6 & "|" & oResultadoEncuesta.Respuesta_6.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_6.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_7 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_7 & "|" & oResultadoEncuesta.Respuesta_7.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_7.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_8 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_8 & "|" & oResultadoEncuesta.Respuesta_8.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_8.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_9 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_9 & "|" & oResultadoEncuesta.Respuesta_9.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_9.ToString())
        End If
        If oResultadoEncuesta.strRespuesta_10 <> "" Then
            oPreguntasYRespuestas.Add(oResultadoEncuesta.strRespuesta_10 & "|" & oResultadoEncuesta.Respuesta_10.ToString)
            intSumaTotalVotos = intSumaTotalVotos + CInt(oResultadoEncuesta.Respuesta_10.ToString())
        End If

        dblProportion = 2
        intBarHeight = 20
        blShowHeaderRow = False
        sb.Append("   <table width=""" & _intTableWidth & """ border=""0"" cellspacing=""0"" cellpadding=""0"">")
        sb.Append("            <tr>")
        sb.Append("              <td height=""37"" colspan=""6"" align=center><span class=""Estilo1""><b>" & oResultadoEncuesta.strPregunta & "</b></span><br><br></td>")
        sb.Append("            </tr>")
        sb.Append("            <tr>")
        sb.Append("              <td height=""37"" colspan=""6"" align=center><span class=""Estilo1""><b>Desde: " & Funcion.FormatHispanicDateTime(oResultadoEncuesta.FechaInicio) & " - Hasta: " & Funcion.FormatHispanicDateTime(oResultadoEncuesta.FechaFin) & "</b></span><br><br></td>")
        sb.Append("            </tr>")
        Dim intIndice As Integer = 0
        For intIndice = 0 To oPreguntasYRespuestas.Count - 1
            Dim strResult As String() = oPreguntasYRespuestas(intIndice).ToString.Split("|")
            If intSumaTotalVotos > 0 Then
                dblPercentage = strResult(1) / intSumaTotalVotos * 100
                intBarWidth = Int(dblPercentage * dblProportion)
            End If
            sb.Append("            <tr border=""1"">")
            sb.Append("              <td width=""" & _intRightCellWidth & """><span class=""Estilo1""></span></td>")
            sb.Append("              <td width=""" & _intLeftCellWidthNomnbre & """><span class=""Estilo1"">" & strResult(0) & "</span></td>")
            sb.Append("              <td width=""" & _intLeftCellWidth & """><img src=./images/survey_bar.gif height=" & intBarHeight & " width=" & intBarWidth & " border=1></td>")
            sb.Append("              <td width=""" & _intRightCellWidthVotos & """  valign=bottom  align=right class=""Estilo1"">" & FormatNumber(strResult(1).ToString(), 0) & " votos</td>")
            sb.Append("              <td width=""" & _intRightCellWidth & """  valign=bottom  align=right class=""Estilo1""><b>" & FormatNumber(dblPercentage.ToString(), 2) & "%</b></td>")
            sb.Append("              <td width=""" & _intRightCellWidth & """><span class=""Estilo1""></span></td>")
            sb.Append("            </tr>")
            sb.Append("            <tr><td colspan=2 height=3></td></tr>")
        Next
        If intSumaTotalVotos > 0 Then
            sb.Append("            <tr>")
            sb.Append("              <td colspan=5 class=""Estilo1"" align=center><b>N&#250;mero total de votos: " & intSumaTotalVotos & "</b></td>")
            sb.Append("            </tr>")
        End If
        sb.Append("          </table>")
        Return sb.ToString()
    End Function
End Class