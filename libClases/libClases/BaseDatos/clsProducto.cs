using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;
using libComunes.CapaDatos;

namespace libClases.BaseDatos
{
    public class clsProducto
    {
        #region "Atributos/Propiedades"
        public Int32 CodigoProducto { get; set; }
        public Int32 ValorUnitario { get; set; }
        public Int32 CodigoTipoProducto { get; set; }
        public DropDownList cboProducto { get; set; }
        private string SQL;
        public string Error { get; private set; }

        public string Nombre_PROD { get; set; }
        public string Descripcion_PROD { get; set; }
        public Int32 Cantidad_PROD { get; set; }
        public Int32 intValorUnitario_PROD { get; set; }
        public string intCodigo_TIPR { get; set; }
        public string urlImagen { get; set; }
        #endregion
        #region "Metodos"

        public bool ConsultarProductos()
        {
            SQL = "SELECT intCodigo_PROD AS CODIGO, strNombre_PROD AS TEXTO, strDescripcion_PROD, " +
                   "intCantidad_PROD, intValorUnitario_PROD, intCodigo_TIPR, urlImagen " +
                  "FROM dbo.tblProducto ";
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            //oConexion.AgregarParametro("@prDocumento", CodigoProducto);

            if (oConexion.Consultar())
            {
                //Se utiliza el objeto Reader... Propiedad HasRows, y métodos Get
                if (oConexion.Reader.HasRows)
                {
                    //Se lee el reader con el metodo Read
                    oConexion.Reader.Read();
                    //Se capturan los datos
                    CodigoProducto = oConexion.Reader.GetInt32(0);
                    Nombre_PROD = oConexion.Reader.GetString(1);
                    Descripcion_PROD = oConexion.Reader.GetString(2);
                    Cantidad_PROD = oConexion.Reader.GetInt32(3);
                    intValorUnitario_PROD = oConexion.Reader.GetInt32(4);
                    CodigoTipoProducto = oConexion.Reader.GetInt32(5);
                    urlImagen = oConexion.Reader.GetString(6);
                    //Cerrar y liberar
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No hay datos, se levanta un error
                    Error = "No hay datos de productos";
                    //Cerrar y liberar
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
                
            }
            return false;
        }


        public bool LlenarCombo()
        {
            SQL = "SELECT intCodigo_PROD AS CODIGO, strNombre_PROD AS TEXTO " +
                  "FROM dbo.tblProducto " +
                  "WHERE intCodigo_TIPR = @prTipoProducto";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            oCombo.AgregarParametro("@prTipoProducto", CodigoTipoProducto);
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboProducto;
            oCombo.NombreTabla = "Tabla";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "TEXTO";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "CODIGO";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboProducto = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                oCombo = null;
                return false;
            }
        }
        public bool ConsultarValorUnitario()
        {
            SQL = "SELECT intValorUnitario_PROD " +
                  "FROM dbo.tblProducto " +
                  "WHERE    intCodigo_PROD = @prCodigo";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", CodigoProducto);
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    ValorUnitario = oConexion.Reader.GetInt32(0);
                    //Libera memoria
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No tiene filas, se levanta un error
                    Error = "El producto con código " + CodigoProducto +
                        " no está en la base de datos. \nVerifique la información " +
                        "o ingréselo al sistema";
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

      /*  public bool Ingresar()
        {

            SQL = "INSERT INTO tblProducto (strNombre_PROD, strDescripcion_PROD, intCantidad_PROD, " +
                       "intValorUnitario_PROD, intCodigo_TIPR, urlImagen) " +
            "VALUES (@prNombre_PROD, @prDescripcion_PROD, @prCantidad_PROD, @printValorUnitario_PROD, @printCodigo_TIPR, @prurlImagen)";

           
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre_PROD", Nombre_PROD);
            oConexion.AgregarParametro("@prDescripcion_PROD", Descripcion_PROD);
            oConexion.AgregarParametro("@prCantidad_PROD", Cantidad_PROD);
            oConexion.AgregarParametro("@printValorUnitario_PROD", intValorUnitario_PROD);
            oConexion.AgregarParametro("@printCodigo_TIPR", intCodigo_TIPR);
            oConexion.AgregarParametro("@prurlImagen", urlImagen);

            if (oConexion.EjecutarSentencia())
            {
                //Ejecutó la sentencia, liberar memoria y retornar true
                oConexion = null;
                return true;
            }
            else
            {
                //Lee el error, libera y retorna false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }*/
        #endregion
    }
}

