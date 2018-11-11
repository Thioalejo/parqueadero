using libComunes.CapaDatos;
using libComunes.CapaObjetos;
using System.Web.UI.WebControls;

namespace libClases.BaseDatos
{
    public class Vehiculo
    {
        #region Atributos
        public string Marca { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int IdCliente { get; set; }

        private string SQL;
        public string Error { get; private set; }
        public GridView grid { get; set; }
        #endregion

        #region "Metodoes
        public bool Guardar()
        {
            SQL = "INSERT INTO vehiculo (marca, color, modelo, placa, idCliente) " +
                     "VALUES (@marca, @color, @modelo, @placa, @idCliente)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@marca", Marca);
            oConexion.AgregarParametro("@color", Color);
            oConexion.AgregarParametro("@modelo", Modelo);
            oConexion.AgregarParametro("@placa", Placa);
            oConexion.AgregarParametro("@idCliente", IdCliente);

            if (oConexion.EjecutarSentencia())
            {
                //Grabó en la base de datos
                oConexion = null;
                return true;
            }
            else
            {
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }

        public bool LlenarGrid(string fecha_inicial, string fecha_final)
        {
            SQL = "SELECT dbo.vehiculo.marca, dbo.vehiculo.color, dbo.vehiculo.modelo, dbo.vehiculo.placa " +
                " FROM dbo.cliente INNER JOIN " +
                " dbo.reserva ON dbo.cliente.idCliente = dbo.reserva.idCliente INNER JOIN " +
                " dbo.parqueadero ON dbo.reserva.idParqueadero = dbo.parqueadero.idParqueadero INNER JOIN " +
                " dbo.vehiculo ON dbo.cliente.idCliente = dbo.vehiculo.idCliente AND dbo.reserva.idVehiculo =" +
                " dbo.vehiculo.idVehiculo AND dbo.parqueadero.idVehiculo = dbo.vehiculo.idVehiculo " +
                " where fecha_llegada between'" + fecha_inicial + "' and '" + fecha_final+"'";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            //oGrid.AgregarParametro("@prFactura", NumeroFactura);
            oGrid.gridGenerico = grid;
            oGrid.NombreTabla = "Factura";
            if (oGrid.LlenarGridWeb())
            {
                grid = oGrid.gridGenerico;
                oGrid = null;
                return true;
            }
            else
            {
                Error = oGrid.Error;
                oGrid = null;
                return false;
            }
        }
        
        #endregion


    }
}
