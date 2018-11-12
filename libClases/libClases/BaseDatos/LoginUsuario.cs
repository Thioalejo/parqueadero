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
   public class LoginUsuario
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        private string SQL;
        public string Error { get; private set; }

        public bool Consultar()
        {

            SQL = "SELECT USUARIO, ROL " +
                " FROM dbo.TBL_LOGIN " +
                " WHERE(USUARIO = @prUsuario) AND (CONTRASEÑA = @prContraseña)";


            //SQL = "SELECT USUARIO, CONTRASEÑA, ROL " +
            //    " FROM dbo.TBL_LOGIN " +
            //    " WHERE(USUARIO = '" + Usuario + ")AND (CONTRASEÑA = " + Contraseña + ")'";

            /* SQL = "SELECT   strNombre_CLIE, strPrimerApellido_CLIE, " +
                            "strSegundoApellido_CLIE, strDireccion_CLIE " +
                   "FROM     tblCliente " +
                   "WHERE    strDocumento_CLIE = @prDocumento";*/

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prUsuario", Usuario);
            oConexion.AgregarParametro("@prContraseña", Contraseña);
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    //idCliente = oConexion.Reader.GetInt32(0);
                    //Nombre_Completo = oConexion.Reader.GetString(1);
                    //Documento = oConexion.Reader.GetInt32(2);
                    //Telefono = oConexion.Reader.GetInt32(3);
                    Usuario = oConexion.Reader.GetString(0);
                    Rol = oConexion.Reader.GetString(1);


                    //Libera memoria
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No tiene filas, se levanta un error
                    Error = "El usuario " + Usuario +
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
