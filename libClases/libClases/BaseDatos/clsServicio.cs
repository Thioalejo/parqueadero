using System;
using libComunes.CapaObjetos;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;

namespace libReglasNegocio.BaseDatos
{
    public class clsServicio
    {
        #region "Atributos/Propiedades"
        public GridView grdServicio { get; set; }
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public Int32 Valor { get; set; }
        public Int32 TipoServicio { get; set; }
        public bool Activo { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool LlenarGrid()
        {
            SQL = "Execute Servicio_Grid";
            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.NombreTabla = "tblGrid";
            oGrid.gridGenerico = grdServicio;
            if (oGrid.LlenarGridWeb())
            {
                grdServicio = oGrid.gridGenerico;
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
        public bool Insertar()
        {
            Int16 iActivo;
            if (Activo) iActivo = 1; else iActivo = 0;
            SQL = "Servicio_Insertar";
            clsConexion oConexion = new clsConexion();
            //Se pasa el sql
            oConexion.SQL = SQL;
            //Pasa los parámetros al procedimiento almacenado
            oConexion.AgregarParametro("@pr_Nombre", System.Data.SqlDbType.VarChar, 50, Nombre);
            oConexion.AgregarParametro("@pr_Valor", System.Data.SqlDbType.Int, 4, Valor);
            oConexion.AgregarParametro("@pr_CodigoTipoServicio", System.Data.SqlDbType.Int, 4, TipoServicio);
            oConexion.AgregarParametro("@pr_Activo", System.Data.SqlDbType.Bit, 1, iActivo);
            //Se ejecuta la instrucción
            if (oConexion.EjecutarSentencia())
            {
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
        public bool Actualizar()
        {
            Int16 iActivo;
            if (Activo) iActivo = 1; else iActivo = 0;
            SQL = "Servicio_Actualizar";
            clsConexion oConexion = new clsConexion();
            //Se pasa el sql
            oConexion.SQL = SQL;
            //Pasa los parámetros al procedimiento almacenado
            oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, Codigo);
            oConexion.AgregarParametro("@pr_Nombre", System.Data.SqlDbType.VarChar, 50, Nombre);
            oConexion.AgregarParametro("@pr_Valor", System.Data.SqlDbType.Int, 4, Valor);
            oConexion.AgregarParametro("@pr_CodigoTipoServicio", System.Data.SqlDbType.Int, 4, TipoServicio);
            oConexion.AgregarParametro("@pr_Activo", System.Data.SqlDbType.Bit, 1, iActivo);
            //Se ejecuta la instrucción
            if (oConexion.EjecutarSentencia())
            {
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
        public bool Borrar()
        {
            SQL = "Servicio_Borrar";
            clsConexion oConexion = new clsConexion();
            //Se pasa el sql
            oConexion.SQL = SQL;
            //Pasa los parámetros al procedimiento almacenado
            oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, Codigo);
            //Se ejecuta la instrucción
            if (oConexion.EjecutarSentencia())
            {
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
        public bool Consultar()
        {
            SQL = "Servicio_Consultar";
            clsConexion oConexion = new clsConexion();
            //Se pasa el sql
            oConexion.SQL = SQL;
            //Pasa los parámetros al procedimiento almacenado
            oConexion.AgregarParametro("@pr_Codigo", System.Data.SqlDbType.Int, 4, Codigo);
            //Se ejecuta la instrucción
            if (oConexion.Consultar())
            {
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    Nombre = oConexion.Reader.GetString(0);
                    Valor = oConexion.Reader.GetInt32(1);
                    TipoServicio = oConexion.Reader.GetInt32(2);
                    Activo = oConexion.Reader.GetBoolean(3);
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    Error = "No hay datos para el servicio de código: " + Codigo;
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                oConexion.CerrarConexion();
                oConexion = null;
                return false;
            }
        }
        #endregion
    }
}
