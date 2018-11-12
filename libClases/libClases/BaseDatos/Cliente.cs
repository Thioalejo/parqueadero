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
        public int Documento { get; set; }
        public string Nombre_Completo { get; set; }
        public int Telefono { get; set; }

        private string SQL;
        public string Error { get; private set; }

        public bool Consultar()
        {

            SQL = "SELECT dbo.TBL_CLIENTE.NOMBRE_COMPLETO, dbo.TBL_RESERVA.ESTADO_RESERVA, " +
                " dbo.TBL_CLIENTE.DOCUMENTO " +
                " FROM dbo.TBL_CLIENTE INNER JOIN " +
                " dbo.TBL_RESERVA ON dbo.TBL_CLIENTE.ID_CLIENTE = dbo.TBL_RESERVA.ID_CLIENTE" +
                  " WHERE(DOCUMENTO = @documento) AND (dbo.TBL_RESERVA.ESTADO_RESERVA = 'activa')";

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
                    idCliente = oConexion.Reader.GetInt32(0);
                    Nombre_Completo = oConexion.Reader.GetString(1);
                    Documento = oConexion.Reader.GetInt32(2);
                    Telefono = oConexion.Reader.GetInt32(3);



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
