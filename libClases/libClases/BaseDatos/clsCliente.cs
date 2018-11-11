using System;
using System.Collections.Generic;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;
namespace libClases.BaseDatos
{
    public class clsCliente
    {
        #region "Atributos/Propiedades"
        public string Documento { get; set; }
        public string Nombre { get; set;}
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public DropDownList cboCliente { get; set; }
        public string NombreCompleto
        {
            get { return Nombre + ' ' + PrimerApellido + ' ' + SegundoApellido; }
        }
        public string ApellidosNombre
        {
            get { return PrimerApellido + ' ' + SegundoApellido + ' ' + Nombre; }
        }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool Ingresar()
        {
            //if (validar())
            SQL = "INSERT INTO tblCliente (strDocumento_CLIE, strNombre_CLIE, strPrimerApellido_CLIE, " +
                                          "strSegundoApellido_CLIE, strDireccion_CLIE) " +
                      "VALUES (@prDocumento, @prNombre, @prApellido1, @prApellido2, @prDireccion)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prApellido1", PrimerApellido);
            oConexion.AgregarParametro("@prApellido2", SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", Direccion);

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
        public bool Actualizar()
        {
            SQL = "UPDATE       tblCliente " +
                      "SET      strNombre_CLIE = @prNombre, " +
                               "strPrimerApellido_CLIE = @prApellido1, " +
                               "strSegundoApellido_CLIE = @prApellido2, " +
                               "strDireccion_CLIE = @prDireccion " +
                      "WHERE    strDocumento_CLIE = @prDocumento";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            oConexion.AgregarParametro("@prNombre", Nombre);
            oConexion.AgregarParametro("@prApellido1", PrimerApellido);
            oConexion.AgregarParametro("@prApellido2", SegundoApellido);
            oConexion.AgregarParametro("@prDireccion", Direccion);

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
        public bool Borrar()
        {
            SQL = "DELETE FROM tblCliente " +
                  "WHERE    strDocumento_CLIE = @prDocumento";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);

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
        public bool Consultar()
        {
            SQL = "SELECT   strNombre_CLIE, strPrimerApellido_CLIE, " +
                           "strSegundoApellido_CLIE, strDireccion_CLIE " +
                  "FROM     tblCliente " +
                  "WHERE    strDocumento_CLIE = @prDocumento";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prDocumento", Documento);
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    Nombre = oConexion.Reader.GetString(0);
                    PrimerApellido = oConexion.Reader.GetString(1);
                    SegundoApellido = oConexion.Reader.GetString(2);
                    Direccion = oConexion.Reader.GetString(3);
                    //Libera memoria
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No tiene filas, se levanta un error
                    Error = "El cliente con el documento " + Documento +
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


        public bool LlenarCombo()
        {
            SQL = "SELECT   dbo.tblCliente.strDocumento_CLIE AS CODIGO, " +
                           "dbo.tblCliente.strNombre_CLIE + ' ' + " +
                           "dbo.tblCliente.strPrimerApellido_CLIE + ' ' + " +
                           "dbo.tblCliente.strSegundoApellido_CLIE AS TEXTO " +
                  "FROM  dbo.tblCliente " +                         
                  "ORDER BY TEXTO";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboCliente;
            oCombo.NombreTabla = "Tabla";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "TEXTO";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "CODIGO";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboCliente = oCombo.cboGenericoWeb;
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
