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
            SQL = "INSERT INTO TBL_VEHICULO (COLOR, MARCA, PLACA, MODELO, ID_CLIENTE) " +
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
            SQL = "SELECT dbo.TBL_VEHICULO.ID_VEHICULO, dbo.TBL_VEHICULO.COLOR, dbo.TBL_VEHICULO.MARCA, " +
                " dbo.TBL_VEHICULO.PLACA, dbo.TBL_VEHICULO.MODELO, dbo.TBL_CLIENTE.NOMBRE_COMPLETO, " +
                " dbo.TBL_RESERVA.FECHA_LLEGADA " +
                " FROM  dbo.TBL_VEHICULO INNER JOIN" +
                " dbo.TBL_CLIENTE ON dbo.TBL_VEHICULO.ID_CLIENTE = dbo.TBL_CLIENTE.ID_CLIENTE INNER JOIN " +
                " dbo.TBL_RESERVA ON dbo.TBL_CLIENTE.ID_CLIENTE = dbo.TBL_RESERVA.ID_CLIENTE where FECHA_LLEGADA between'" + fecha_inicial + "' and '" + fecha_final+"'";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            //oGrid.AgregarParametro("@prFactura", NumeroFactura);
            oGrid.gridGenerico = grid;
            //oGrid.NombreTabla = "Factura";
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

        public bool ConsultarVehiculo()
        {

            SQL = "SELECT PLACA FROM TBL_VEHICULO WHERE PLACA = @prPlaca";

            /* SQL = "SELECT   strNombre_CLIE, strPrimerApellido_CLIE, " +
                            "strSegundoApellido_CLIE, strDireccion_CLIE " +
                   "FROM     tblCliente " +
                   "WHERE    strDocumento_CLIE = @prDocumento";*/

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prPlaca", Placa);
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    Placa = oConexion.Reader.GetString(0);

                    //Libera memoria
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No tiene filas, se levanta un error
                    Error = "La Placa  " + Placa +
                        " no está en la base de datos. \n O no tiene un reserva activa \n Verifique la información ingresada";
                    //Cerrar la conexión
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                //Se debe cerrar la conexión
                oConexion.CerrarConexion();
                oConexion = null;
                return false;
            }
        }

        #endregion


    }
}
