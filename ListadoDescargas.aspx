<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ListadoDescargas.aspx.vb"
    Inherits="PLWeb4_7.ListadoDescargas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/default.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="./css/jqpagination.css" />
    <link href="css/FichaNueva.css" rel="stylesheet" type="text/css" />
    <script src="assets/js/jquery.js" type="text/javascript"></script>

    <script src="./scripts/jquery.jqpagination.js" type="text/javascript"></script>

    <script src="./scripts/ListadoDescargas.js" type="text/javascript"></script>



<style type="text/css">
#contenedor {
    display: table;
    border: 2px solid #000;
    width: 300px;
    text-align: center;
    margin: 0 auto;
}
#contenidos {
    display: table-row;
}
#columna1, #columna2, #columna3 {
    display: table-cell;
    border: 1px solid #000;
    vertical-align: middle;
    padding: 10px;
}
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--     <label>Ingrese Contraseña:</label>
  
          <asp:TextBox ID="txtcontrasena" CssClass="txt" runat="server" Width="190px"></asp:TextBox>
    <asp:Button ID="btnVer" runat="server" CssClass="btn-action"  Text="Visualizar  Prueba" />
    <br />
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>--%>

<div id="contenedor">
    <div id="contenidos">
        <div id="columna1">
         <select onchangue='displayVals' class="ddl-contenido" id="Mes" name="Mes">
        <option value='1'>Enero</option>
        <option value='2'>Febero</option>
        <option value='3'>Marzo</option>
        <option value='4'>Abril</option>
        <option value='5'>Mayo</option>
        <option value='6'>Junio</option>
        <option value='7'>Julio</option>
        <option value='8'>Agosto</option>
        <option value='9'>Septiembre</option>
        <option value='10'>Octubre</option>
        <option value='11'>Noviembre</option>
        <option value='12'>Diciembre</option>
      </select>
      <select onchangue='displayVals' class="ddl-contenido"  id="Anio" name="Anio">
        <option value='2014'>2014</option>
        <option value='2015'>2015</option>
        <option value='2016'>2016</option>
      </select>
        </div>
        <div id="columna2">
        <input type="button" id="btnMostrarPorMes" class="button" name="btnMostrarPorMes" value="Mostrar por Mes y Año" />
        </div>
        <div id="columna3"></div>
        <div id="columna3">
        <input type="button" id="btnMostrar" class="button" name="btnMostrar" value="Mostrar Todos" />
        </div>
        
    </div>
</div>


        
        <table id="Tabla_Principal" runat="server" class="tablas" width="50%">
            <tr>
                <td colspan="3">
                    <table id="tbResultadoBusqueda" class="grid" width="100%">
                        <thead>
                            <tr>
                                <th>
                                    Titulo
                                </th>
                                <th>
                                    Descargas
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr align="right">
            <td colspan="3" align="right">
               <div class="pagination" >
                <a href="#" class="first" data-action="first">&laquo;</a>
                <a href="#" class="previous" data-action="previous">&lsaquo;</a>
                <input type="text" readonly="readonly" data-max-page="40" />
                <a href="#" class="next" data-action="next">&rsaquo;</a>
                <a href="#" class="last" data-action="last">&raquo;</a>
              </div>
            </td>
        </tr>
            <tr align="center">
                <td colspan="3" align="right">
                    <label style="font-size: 12px;" id="TotalDescargas">
                    </label>
                </td>
            </tr>
        </table>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    </form>
</body>
</html>
