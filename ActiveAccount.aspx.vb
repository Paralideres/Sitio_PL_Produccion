Imports Sistema.PL.Negocio

Partial Public Class ActiveAccount
    Inherits System.Web.UI.Page
    Dim liQS As Libreria.QueryString.QueryString
    Dim IdUsuario As Integer
    Dim strOlvidoCMailMinutosDuracion As String = System.Configuration.ConfigurationManager.AppSettings("OlvidoCMailMinutosDuracion")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strNombre As String
        Dim strApellido As String
        Dim strPassword As String
        Dim parametro As String
        Dim strHoy As String
        Dim strDia As String = agregaCeroaIzq(Now().Day.ToString)
        Dim strMes As String = agregaCeroaIzq(Now().Month.ToString)
        Dim strAnio As String = Now().Year.ToString
        Dim IntNumeroLink As Integer
        Dim intNumeroActual As Integer
        If Not IsPostBack Then

            parametro = Request.QueryString("action")


            liQS = New Libreria.QueryString.QueryString(parametro)
            IdUsuario = Convert.ToInt32(liQS.Item("ID_USU"))
            strNombre = Convert.ToString(liQS.Item("Nombre"))
            strApellido = Convert.ToString(liQS.Item("Apellido"))
            strPassword = Convert.ToString(liQS.Item("Clave"))
            strHoy = Convert.ToString(liQS.Item("Hoy"))

            If strHoy.Length = 0 Then
                strHoy = "19000101"
            End If
            Session("IdUsuarioActivar") = IdUsuario


            IntNumeroLink = Convert.ToInt32(strHoy)
            intNumeroActual = Convert.ToInt32((strAnio & strMes & strDia).ToString())
            Dim intDiferencia = intNumeroActual - IntNumeroLink
            NombreUsuario.InnerHtml = strNombre & " " & strApellido & " "
            MensajeError.Visible = False
            If intDiferencia <= Convert.ToInt32(strOlvidoCMailMinutosDuracion) Then
                If Usuario.ConsultarEstadoUsuario(IdUsuario) = 1 Then
                    btnActivar.Visible = False
                    MensajeError.Visible = True
                    MensajeError.InnerHtml = "Tu cuenta ya se encuentra activa!"
                ElseIf Usuario.ConsultarEstadoUsuario(IdUsuario) > 1 Then
                    btnActivar.Visible = False
                    'MensajeError.Visible = True
                    Response.Redirect("AccountFail.aspx?IuAc=" & IdUsuario)

                    'MensajeError.InnerHtml = "Tu cuenta, por diferentes razones(ej, el tiempo sin usarla), no esta activada, por favor comunicate por Email con nosotros y te la activamos!"
                End If
            Else
                btnActivar.Visible = False

                Response.Redirect("AccountFail.aspx?IuAc=" & IdUsuario)
            End If


        End If
    End Sub
    Protected Sub btnActivar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActivar.Click
        IdUsuario = Session("IdUsuarioActivar")
        Usuario.CambiarEstadoUsuario(IdUsuario, 1)

        CuentaActivada.Visible = True
        btnActivar.Visible = False

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
End Class