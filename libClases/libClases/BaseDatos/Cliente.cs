using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libComunes.CapaDatos;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libClases.BaseDatos
{
   public class Cliente
    {

        public int idCliente { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        private string SQL;
        public string Error { get; private set; }

        public bool Consultar()
        {

            SQL = "SELECT documento, nombre, apellido, idCliente " +
                  " FROM dbo.cliente " +
                  " WHERE(documento = @documento)";

           /* SQL = "SELECT   strNombre_CLIE, strPrimerApellido_CLIE, " +
                           "strSegundoApellido_CLIE, strDireccion_CLIE " +
                  "FROM     tblCliente " +
                  "WHERE    strDocumento_CLIE = @prDocumento";*/

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@documento", Documento);
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    Documento = oConexion.Reader.GetString(0);
                    Nombre = oConexion.Reader.GetString(1);
                    Apellido = oConexion.Reader.GetString(2);
                    idCliente = oConexion.Reader.GetInt32(3);
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

       
    }
}
