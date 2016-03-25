

<%@ Page %>

<%@ Import Namespace="Library_PL_Editor" %>


<script runat="server">


    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        Dim mCal As Library_PL_Editor.ParaLideres.FormControls.Calendar

        Dim dtPassed As Date = #1/1/1900#

        Try
            dtPassed = CDate(Request("SelectedDate"))
        Catch
        End Try

        Try

            If dtPassed = #1/1/1900# Then dtPassed = Date.Today

            mCal = New Library_PL_Editor.ParaLideres.FormControls.Calendar()

            mCal.Script = "calendar.aspx"
            mCal.FieldName = Request("FormFieldName")
            mCal.TopColor = "#B7D983"
            mCal.MonthNameColor = "#000000"
            mCal.YearStart = 1900
            mCal.YearEnd = Date.Today.Year + 10

            Response.Write(mCal.DisplayCalendar(dtPassed))
                        
        Catch ex As Exception

            'do nothing

        Finally

            mCal = Nothing

        End Try

    End Sub


</script>
