using System;
using libComunes.CapaDatos;
//Se requiere la capa de objetos para llenar el combo
using libComunes.CapaObjetos;
//Se requiere la librería System.Web.UI.WebControls, y hay que referenciar a System.Web
using System.Web.UI.WebControls;

namespace libClases.BaseDatos
{
    public class clsDepartamento
    {
        #region "Atributos/Propiedades"
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public Int32 CodigoPais { get; set; }
        public bool Activo { get; set; }
        //Crea el objeto grdDepartamento como propiedad de entrada y salida
        public GridView grdDepartamento { get; set; }
        public DropDownList cboDepartamento { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool Ingresar()
        {
            SQL = "INSERT INTO tblDepartamento (strNombre_DEPA, blnActivo_DEPA,intCodigo_PAIS) " +
                  "VALUES (@prNombre, @prActivo, @prCodigoPais)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);
            oConexion.AgregarParametro("@prCodigoPais", CodigoPais);

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
        public bool Actualizar()
        {
            SQL = "UPDATE   tblDepartamento " +
                  "SET      strNombre_DEPA = @prNombre, " +
                           "blnActivo_DEPA = @prActivo, " +
                           "intCodigo_PAIS =  @prCodigoPais " +
                  "WHERE    intCodigo_DEPA = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prActivo", Activo);
            oConexion.AgregarParametro("@prCodigoPais", CodigoPais);
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
            SQL = "DELETE FROM tblDepartamento " +
                  "WHERE    intCodigo_DEPA = @prCodigo";

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
        public bool Consultar()
        {
            return false;
        }
        public bool LlenarGrid()
        {
            SQL = "SELECT        dbo.tblPAIS.strNombre_PAIS AS PAÍS, " +
                                        "dbo.tblDepartamento.intCodigo_DEPA AS [CÓDIGO DEPARTAMENTO],  " +
                                        "dbo.tblDepartamento.strNombre_DEPA AS NOMBRE, " +
                                        "dbo.tblDepartamento.blnActivo_DEPA AS ACTIVO " +
                        "FROM dbo.tblDepartamento INNER JOIN dbo.tblPAIS " + 
                                        "ON dbo.tblDepartamento.intCodigo_PAIS = dbo.tblPAIS.intCodigo_PAIS " +
                        "WHERE      dbo.tblDepartamento.intCodigo_PAIS = @prPais";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.AgregarParametro("@prPais", CodigoPais);
            oGrid.gridGenerico = grdDepartamento;
            oGrid.NombreTabla = "Departamento";
            if (oGrid.LlenarGridWeb())
            {
                grdDepartamento = oGrid.gridGenerico;
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
        public bool LlenarCombo()
        {
            SQL = "SELECT       intCodigo_DEPA, strNombre_DEPA " +
                       "FROM        tblDepartamento " +
                       "WHERE       blnActivo_DEPA = 1 " +
                                   "AND intCodigo_PAIS = " + CodigoPais +
                       " ORDER BY    strNombre_DEPA";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboDepartamento;
            oCombo.NombreTabla = "Departamento";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "strNombre_DEPA";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "intCodigo_DEPA";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboDepartamento = oCombo.cboGenericoWeb;
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
        #endregion
    }
}
