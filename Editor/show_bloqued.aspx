
<%@ Page Language="VB" AutoEventWireup="false" Inherits="Library_PL_Editor.ParaLideres.Editor" %>

<%@ Import Namespace="Library_PL_Editor.ParaLideres" %>

<%@ Import Namespace="Library_PL_Editor" %>



    <script runat="server">

        Protected Overrides Sub OnLoadComplete(ByVal e As System.EventArgs)
            
            Dim intRecordId As Integer = 0

            Try
                intRecordId = CInt(Request("id"))
            Catch ex As Exception
            End Try

            If intRecordId > 0 Then

                GenericDataHandler.ExecSQL("DELETE FROM bloqued WHERE record_id = " & intRecordId)

                Response.Redirect("show_bloqued.aspx")

            Else 'If intRecordId > 0 Then

                Dim sb As New System.Text.StringBuilder("")
                Dim reader As System.Data.SqlClient.SqlDataReader
                Dim objCountryLookup As CountryLookup

                Dim strIPDataPath As String = Library_PL_Editor.ParaLideres.Functions.GeoDataFilePath
                Dim strCountryName As String = ""
                Dim strCountryCode As String = ""
                Dim strUserIPAddress As String = ""



                Try

                    objCountryLookup = New CountryLookup(strIPDataPath)

                    reader = Library_PL_Editor.ParaLideres.GenericDataHandler.GetRecords("SELECT record_id, ip_address FROM bloqued ORDER BY ip_address")

                    If reader.HasRows() Then

                        sb.Append("Los siguientes usuarios han sido bloqueados por tratar de crear un usuario por medio de 'bots' o tratar un 'hack'.  Para borrar de la lista de usuarios bloqueados haga un click en la bandera.<br>")

                        Do While (reader.Read())

                            intRecordId = reader(0)

                            strUserIPAddress = reader(1)

                            strCountryName = objCountryLookup.LookupCountryName(strUserIPAddress)

                            strCountryCode = objCountryLookup.LookupCountryCode(strUserIPAddress)

                            sb.Append("<br>" & strUserIPAddress & ": " & strCountryName & " <a href=show_bloqued.aspx?id=" & intRecordId & "><img src=" & ProjectPath & "images/flags/" & strCountryCode & ".gif border=0></a>")

                        Loop

                    End If

                    Me.PageTitle = "Usuarios Bloqueados Por Direccin de IP"
                    Me.PageContent = sb.ToString()

                Catch ex As Exception

                    Throw ex

                Finally

                    sb = Nothing
                    reader.Close()
                    reader = Nothing
                    objCountryLookup = Nothing

                End Try



            End If 'If intRecordId > 0 Then




        End Sub


</script>
