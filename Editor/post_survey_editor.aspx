

<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.Editor" %>

<%@ Import Namespace="Library_PL_Editor" %>


<script runat="server">

    Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)

        Dim objQuestions As DataLayer.questions

        Dim intQuestionId As Integer = 0

        Dim dtStart As Date

        Dim dtEnd As Date


        Try
            intQuestionId = CInt(Request("question_id"))
        Catch
        End Try

        Try
            dtStart = CDate(Request("date_start"))
        Catch ex As Exception

        End Try

        Try
            dtEnd = CDate(Request("date_end"))
        Catch ex As Exception

        End Try

        Try

            objQuestions = New DataLayer.questions(intQuestionId)

            objQuestions.setQuestionDesc(Library_PL_Editor.ParaLideres.Functions.FormatString(Request("question_desc")))

            objQuestions.setDateStart(dtStart)

            objQuestions.setDateEnd(dtEnd)

            objQuestions.setQuestion1(Request("question_1"))

            objQuestions.setQuestion2(Request("question_2"))

            objQuestions.setQuestion3(Request("question_3"))

            objQuestions.setQuestion4(Request("question_4"))

            objQuestions.setQuestion5(Request("question_5"))

            objQuestions.setQuestion6(Request("question_6"))

            objQuestions.setQuestion7(Request("question_7"))

            objQuestions.setQuestion8(Request("question_8"))

            objQuestions.setQuestion9(Request("question_9"))

            objQuestions.setQuestion10(Request("question_10"))

            If intQuestionId = 0 Then 'Insert New Record

                objQuestions.Add()

            Else 'Update Record

                objQuestions.Update()

            End If 'If intQuestionId = 0 Then 'Insert New Record

            qs.Clear()
            qs("web_section") = "surveys"
            qs("action") = "main"

            Response.Redirect("editor.aspx?x=" & qs.ToString())

        Catch ex As Exception

            ShowError(ex)

        Finally

            objQuestions = Nothing

        End Try

    End Sub


</script>
