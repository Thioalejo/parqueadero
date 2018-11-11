using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libClases.BaseDatos
{
    public class clsTipoProducto
    {
        #region "Atributos/Propiedades"
        public DropDownList cboTipoProducto { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool LlenarCombo()
        {
            SQL = "SELECT intCodigo_TIPR AS CODIGO, strNombre_TIPR AS TEXTO " +
                   " FROM dbo.tblTIpoProducto " +
                    "WHERE blnActivo_TIPR = 1 " +
                    "ORDER BY TEXTO";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo pais
            oCombo.cboGenericoWeb = cboTipoProducto;
            oCombo.NombreTabla = "Tabla";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "TEXTO";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "CODIGO";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboPaises
                cboTipoProducto = oCombo.cboGenericoWeb;
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
