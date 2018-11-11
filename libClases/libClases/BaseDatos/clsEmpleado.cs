using System;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libClases.BaseDatos
{
    public class clsEmpleado
    {
        #region "Atributos/Propiedades"
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string Cargo { get; set; }
        public DateTime FechaContratacion { get; set; }
        public DateTime FechaFinContratacion { get; set; }
        public string CodigoSucursal { get; set; }
        public DropDownList cboEmpleado { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"


        public bool ingresarEmpleado()
        {
            if(Ingresar())
            {
                SQL = "INSERT INTO tblEmpleadoCargo (strDocumento_EMPL, intCodigo_CARG, dtmFechaInicio_EMCA, " +
                       "dtmFechaFin_EMCA, intCodigo_SUCU) " +
                        "VALUES (@prDocumento_EMPL, @printCodigo_CARG, @prdtmFechaInicio_EMCA, @prdtmFechaFin_EMCA, @printCodigo_SUCU)";

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento_EMPL", Documento);
                oConexion.AgregarParametro("@printCodigo_CARG", Cargo);
                oConexion.AgregarParametro("@prdtmFechaInicio_EMCA", FechaContratacion);
                oConexion.AgregarParametro("@prdtmFechaFin_EMCA", FechaFinContratacion);
                oConexion.AgregarParametro("@printCodigo_SUCU", CodigoSucursal);
               

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
           return false;
        }
        public bool Ingresar()
        {

            SQL = "INSERT INTO tblEmpleado (strDocumento_EMPL, strNombre_EMPL, strPrimerApellido_EMPL, " +
                       "strSegundoApellido_EMPL, strDireccion_EMPL, strTelefono_EMPL) " +
            "VALUES (@prDocumento, @prNombre, @prPrimerApellido, @prSegundoApellido, @prDireccion, @prTelefono)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", Direccion);
            oConexion.AgregarParametro("@prTelefono", Telefono);

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

        public bool ActualizarEmpleado()
        {
            if(Actualizar())
            {

                SQL = "UPDATE tblEmpleadoCargo " +
                    "SET intCodigo_CARG = @printCodigo_CARG, " +
                    "dtmFechaInicio_EMCA = @prdtmFechaInicio_EMCA , " +
                    "dtmFechaFin_EMCA = @prdtmFechaFin_EMCA , " +
                    "intCodigo_SUCU = @printCodigo_SUCU " +     
                    "WHERE(strDocumento_EMPL = @prDocumento_EMPL)";

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento_EMPL", Documento);
                oConexion.AgregarParametro("@printCodigo_CARG", Cargo);
                oConexion.AgregarParametro("@prdtmFechaInicio_EMCA", FechaContratacion);
                oConexion.AgregarParametro("@prdtmFechaFin_EMCA", FechaFinContratacion);
                oConexion.AgregarParametro("@printCodigo_SUCU", CodigoSucursal);

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
            return false;
        }
        public bool Actualizar()
        {
            SQL = "UPDATE   tblEmpleado " +
                        "SET      strNombre_EMPL = @prNombre, " +
                                    "strPrimerApellido_EMPL = @prPrimerApellido, " +
                                    "strSegundoApellido_EMPL = @prSegundoApellido, " +
                                    "strDireccion_EMPL = @prDireccion, " +
                                    "strTelefono_EMPL = @prTelefono " +
                  "WHERE    strDocumento_EMPL = @prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prPrimerApellido", PrimerApellido);
            oConexion.AgregarParametro("@prSegundoApellido", SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", Direccion);
            oConexion.AgregarParametro("@prTelefono", Telefono);

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
            SQL = "DELETE FROM tblEmpleado " +
                  "WHERE    strDocumento_EMPL = @prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

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

        public bool ConsultarEmpleado()
        {
            if (Consultar())
            {

                SQL = "SELECT        strDocumento_EMPL, intCodigo_CARG, " +
                    "                dtmFechaInicio_EMCA, dtmFechaFin_EMCA, intCodigo_SUCU " +
                    "FROM dbo.tblEmpleadoCargo " +
                    "WHERE(strDocumento_EMPL = @prDocumento)";
              

                clsConexion oConexion = new clsConexion();

                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento", Documento);

                if (oConexion.Consultar())
                {
                    //Se utiliza el objeto Reader... Propiedad HasRows, y métodos Get
                    if (oConexion.Reader.HasRows)
                    {
                        //Se lee el reader con el metodo Read
                        oConexion.Reader.Read();
                        //Se capturan los datos
                        Documento = oConexion.Reader.GetString(0);
                        Cargo = Convert.ToString(oConexion.Reader.GetInt32(1));
                        FechaContratacion = oConexion.Reader.GetDateTime(2);
                        FechaFinContratacion = oConexion.Reader.GetDateTime(3);
                        CodigoSucursal = Convert.ToString(oConexion.Reader.GetInt32(4));
                        //Cerrar y liberar
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        //No hay datos, se levanta un error
                        Error = "No hay datos para el el empleado de documento: " + Documento;
                        //Cerrar y liberar
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return false;
                    }
                }
                else
                {
                    Error = oConexion.Error;
                    //Cerrar conexión
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            return false;
        }
        public bool Consultar()
        {
            SQL = "SELECT       strNombre_EMPL, strPrimerApellido_EMPL, " +
                                          "strSegundoApellido_EMPL, strDireccion_EMPL, strTelefono_EMPL " +
                      "FROM          tblEmpleado " +
                      "WHERE        strDocumento_EMPL = @prDocumento";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

            if (oConexion.Consultar())
            {
                //Se utiliza el objeto Reader... Propiedad HasRows, y métodos Get
                if (oConexion.Reader.HasRows)
                {
                    //Se lee el reader con el metodo Read
                    oConexion.Reader.Read();
                    //Se capturan los datos
                    Nombre = oConexion.Reader.GetString(0);
                    PrimerApellido = oConexion.Reader.GetString(1);
                    SegundoApellido = oConexion.Reader.GetString(2);
                    Direccion = oConexion.Reader.GetString(3);
                    Telefono = oConexion.Reader.GetString(4);
                    //Cerrar y liberar
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No hay datos, se levanta un error
                    Error = "No hay datos para el el empleado de documento: " + Documento;
                    //Cerrar y liberar
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else
            {
                Error = oConexion.Error;
                //Cerrar conexión
                oConexion.CerrarConexion();
                oConexion = null;
                return false;
            }
        }


        public bool LlenarCombo()
        {
            SQL = "SELECT   dbo.tblEmpleadoCargo.intCodigo_EMCA AS CODIGO, " +
                           "dbo.tblEmpleado.strNombre_EMPL + ' ' + " + 
                           "dbo.tblEmpleado.strPrimerApellido_EMPL + ' ' + " +
                           "dbo.tblEmpleado.strSegundoApellido_EMPL AS TEXTO " +
                  "FROM dbo.tblcargo INNER JOIN dbo.tblEmpleadoCargo " +
                           "ON dbo.tblcargo.intCodigo_CARG = dbo.tblEmpleadoCargo.intCodigo_CARG " +
                           "INNER JOIN dbo.tblEmpleado " +
                           "ON dbo.tblEmpleadoCargo.strDocumento_EMPL = dbo.tblEmpleado.strDocumento_EMPL " +
                  
                  "ORDER BY TEXTO";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboEmpleado;
            oCombo.NombreTabla = "Tabla";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "TEXTO";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "CODIGO";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboEmpleado = oCombo.cboGenericoWeb;
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

        public bool LlenarComboCargoEmpleado()
        {
            SQL = "SELECT dbo.tblcargo.intCodigo_CARG, dbo.tblcargo.strNombre_CARG " +
                  "FROM dbo.tblcargo";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboEmpleado;
            oCombo.NombreTabla = "tblcargo";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "strNombre_CARG";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "intCodigo_CARG";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboEmpleado = oCombo.cboGenericoWeb;
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

        public bool LlenarComboSucursal()
        {
            SQL = "SELECT [intCodigo_SUCU], [strNombre_SUCU], [strDireccion_SUCU], [strTelefono_SUCU], " +
                " [intCodigo_CIUD] " +
                "FROM[VentasCelulares2].[dbo].[tblSucursal]";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboEmpleado;
            oCombo.NombreTabla = "tblSucursal";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "strNombre_SUCU";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "intCodigo_SUCU";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboEmpleado = oCombo.cboGenericoWeb;
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
