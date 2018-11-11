using System;
using libComunes.CapaDatos;
//Se requiere la capa de objetos para llenar el combo
using libComunes.CapaObjetos;
//Se requiere la librería System.Web.UI.WebControls, y hay que referenciar a System.Web
using System.Web.UI.WebControls;

namespace libClases.BaseDatos
{
    public class clsPais
    {
        #region "Atributos/Propiedades"
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        //Crea el objeto cboPaises como propiedad de entrada y salida
        public DropDownList cboPaises { get; set; }
        public GridView grdPais { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool Ingresar()
        {
            SQL = "INSERT INTO tblPais (strNombre_PAIS, blnActivo_PAIS) " +
                  "VALUES (@prNombre, @prActivo)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);

            if(oConexion.EjecutarSentencia())
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
        }
        public bool Actualizar()
        {
            SQL = "UPDATE   tblPais " +
                  "SET      strNombre_PAIS = @prNombre, " +
                           "blnActivo_PAIS = @prActivo " +
                  "WHERE    intCodigo_PAIS = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);
            oConexion.AgregarParametro("@prCodigo", Codigo);

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
        }
        public bool Borrar()
        {
            SQL = "DELETE FROM tblPais " +
                  "WHERE    intCodigo_PAIS = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);

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
        }
        public bool LlenarCombo()
        {
            SQL = "SELECT       intCodigo_PAIS, strNombre_PAIS " + 
                       "FROM        tblPais " +
                       "WHERE       blnActivo_PAIS = 1 " +
                       "ORDER BY    strNombre_PAIS";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboPaises;
            oCombo.NombreTabla = "Pais";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "strNombre_PAIS";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "intCodigo_PAIS";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboPaises = oCombo.cboGenericoWeb;
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
        public bool LlenarGrid()
        {
            SQL = "SELECT  intCodigo_PAIS AS CODIGO, strNombre_PAIS AS NOMBRE, blnActivo_PAIS AS ACTIVO " +
                  "FROM dbo.tblPAIS " +
                  "ORDER BY NOMBRE";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.gridGenerico = grdPais;
            oGrid.NombreTabla = "Departamento";
            if (oGrid.LlenarGridWeb())
            {
                grdPais = oGrid.gridGenerico;
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
