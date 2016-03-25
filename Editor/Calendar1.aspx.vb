Public Partial Class Calendar1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim fecha As Date = New Date

        AddHandler Calendario.SelectionChanged, AddressOf Me.Calendario_SelectionChanged
        AddHandler Calendario.VisibleMonthChanged, AddressOf Me.Calendario_VisibleMonthChanged

        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If (Page.IsPostBack = False) Then
            'myFecha.Value = Request.Params["strFecha"];
            If (Request.Params("strFecha") <> "0") Then
                Try
                    fecha = Convert.ToDateTime(Request.Params("strFecha"))
                    Calendario.SelectedDate = fecha
                Catch ex As Exception
                    fecha = System.DateTime.Now.Date
                End Try
            Else
                fecha = System.DateTime.Now.Date
            End If
            Calendario.VisibleDate = fecha
            Calendario.TodaysDate = fecha
            LabelYear.Text = Calendario.VisibleDate.Year.ToString
        ElseIf (cantYear.Value <> "") Then
            'Calendario.SelectedDate = Calendario.SelectedDate.AddYears(CType(cantYear.Value, Integer))
            'Calendario.VisibleDate = Calendario.SelectedDate
            fecha = Calendario.TodaysDate
            fecha = fecha.AddYears(Convert.ToInt32(cantYear.Value))
            Calendario.TodaysDate = fecha
            Calendario.VisibleDate = fecha
            cantYear.Value = ""
            LabelYear.Text = Calendario.VisibleDate.Year.ToString
        End If
    End Sub
    Protected Sub Calendario_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Calendario.SelectionChanged
        myFecha.Value = Calendario.SelectedDate.Date.ToShortDateString
        Me.boCerrar.Value = "S"
    End Sub

    Protected Sub Calendario_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles Calendario.VisibleMonthChanged
        Calendario.TodaysDate = e.NewDate.Date
        LabelYear.Text = Calendario.VisibleDate.Year.ToString
    End Sub
End Class