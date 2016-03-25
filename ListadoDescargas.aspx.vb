Imports System.Web.Services
Imports Sistema.PL.Entidad
Imports Library_PL.Filtros

Partial Public Class ListadoDescargas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Not IsPostBack) Then
        '    Tabla_Principal.Visible = False
        'End If

    End Sub
    <WebMethod()> Public Shared Function BuscarTodasLasDescargas(ByVal intPagina As Integer) As List(Of InfoDescarga)
        Return Sistema.PL.Negocio.Pagina.ListaTodasLasDescagadas(intPagina)
    End Function
    <WebMethod()> Public Shared Function BuscarDescarga_x_Mes_Anio(ByVal intPagina As Integer, ByVal intMes As Integer, ByVal intAnio As Integer) As List(Of InfoDescarga)
        Dim oPaginas As New InfoFiltroPagina
        oPaginas.IdPagina = intPagina
        oPaginas.Mes = intMes
        oPaginas.Anio = intAnio

        Return Sistema.PL.Negocio.Pagina.BuscarDescarga_x_Mes_Anio(oPaginas)

    End Function

    'Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVer.Click
    '    'If txtcontrasena.Text = "p4r4lideres" Then
    '    '    Tabla_Principal.Visible = True
    '    '    lblError.Text = ""
    '    'Else
    '    '    lblError.Text = "*Contraseña Incorrecta"
    '    '    Tabla_Principal.Visible = False
    '    'End If
    'End Sub
End Class