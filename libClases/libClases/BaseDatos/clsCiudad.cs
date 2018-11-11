using System;
using libComunes.CapaDatos;
//Se requiere la capa de objetos para llenar el combo
using libComunes.CapaObjetos;
//Se requiere la librería System.Web.UI.WebControls, y hay que referenciar a System.Web
using System.Web.UI.WebControls;

namespace libClases.BaseDatos
{
    public class clsCiudad
    { 
    #region "Atributos/Propiedades"
    public Int32 Codigo { get; set; }
    public string Nombre { get; set; }
    public Int32 CodigoDpto { get; set; }
    public bool Activo { get; set; }
    //Crea el objeto grdCiudad como propiedad de entrada y salida
    public GridView grdCiudad { get; set; }
    public DropDownList cboCiudad { get; set; }
    private string SQL;
    public string Error { get; private set; }
    #endregion
    #region "Metodos"
    public bool Ingresar()
    {
        SQL = "INSERT INTO tblCiudad (strNombre_CIUD, blnActivo_CIUD,intCodigo_Depa) " +
              "VALUES (@prNombre, @prActivo, @prCodigoDepa)";

        clsConexion oConexion = new clsConexion();

        oConexion.SQL = SQL;
        oConexion.AgregarParametro("@prNombre", Nombre);
        oConexion.AgregarParametro("@prActivo", Activo);
        oConexion.AgregarParametro("@prCodigoDepa", CodigoDpto);

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
        SQL = "UPDATE   tblCiudad " +
              "SET      strNombre_CIUD = @prNombre, " +
                       "blnActivo_CIUD = @prActivo, " +
                       "intCodigo_Depa =  @prCodigoDepa " +
              "WHERE    intCodigo_CIUD = @prCodigo";

        clsConexion oConexion = new clsConexion();

        oConexion.SQL = SQL;
        oConexion.AgregarParametro("@prNombre", Nombre);
        oConexion.AgregarParametro("@prActivo", Activo);
        oConexion.AgregarParametro("@prCodigoDepa", CodigoDpto);
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
        SQL = "DELETE FROM tblCiudad " +
              "WHERE    intCodigo_CIUD = @prCodigo";

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
            SQL = "SELECT dbo.tblPAIS.strNombre_PAIS AS PAÍS, dbo.tblDEPArtamento.strNombre_DEPA AS DEPARTAMENTO, " +
                        "dbo.tblCIUDad.intCodigo_CIUD AS CÓDIGO, dbo.tblCIUDad.strNombre_CIUD AS CIUDAD, " +
                         "dbo.tblCIUDad.blnActivo_CIUD AS ACTIVO " +
                    "FROM  dbo.tblCIUDad INNER JOIN dbo.tblDEPArtamento " +
                           "ON dbo.tblCIUDad.intCodigo_DEPA = dbo.tblDEPArtamento.intCodigo_DEPA " +
                           "INNER JOIN dbo.tblPAIS " +
                           "ON dbo.tblDEPArtamento.intCodigo_PAIS = dbo.tblPAIS.intCodigo_PAIS " +
                    "WHERE dbo.tblCIUDad.intCodigo_DEPA = @prDepartamento";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.AgregarParametro("@prDepartamento", CodigoDpto);
            oGrid.gridGenerico = grdCiudad;
            oGrid.NombreTabla = "Departamento";
            if (oGrid.LlenarGridWeb())
            {
                grdCiudad = oGrid.gridGenerico;
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
        SQL = "SELECT       intCodigo_CIUD, strNombre_CIUD " +
                   "FROM        tblCiudad " +
                   "WHERE       blnActivo_CIUD = 1 " +
                               "AND intCodigo_Depa = " + CodigoDpto +
                   " ORDER BY    strNombre_CIUD";

        //Se crea la instancia del objeto combo
        clsCombos oCombo = new clsCombos();
        oCombo.SQL = SQL;
        //Se pasa el combo Depa
        oCombo.cboGenericoWeb = cboCiudad;
        oCombo.NombreTabla = "Ciudad";
        //La columna texto es el nombre de la columna que el combo a mostrar
        oCombo.ColumnaTexto = "strNombre_CIUD";
        //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
        oCombo.ColumnaValor = "intCodigo_CIUD";
        //Se invoca el combo y se lee
        if (oCombo.LlenarComboWeb())
        {
            //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboDepaes
            cboCiudad = oCombo.cboGenericoWeb;
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
