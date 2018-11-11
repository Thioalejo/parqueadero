using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;

namespace libReglasNegocio.BaseDatos
{
    public class clsTipoServicio
    {
        #region "Atributos/Propiedades"
        public Int32 Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        private string SQL;
        public DropDownList cboTipoServicio { get; set; }
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool LlenarCombo()
        {
            if (cboTipoServicio == null)
            {
                Error = "No definió el combo de tipo servicio";
                return false;
            }
            SQL = "Execute TipoServicio_Combo";

            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            oCombo.cboGenericoWeb = cboTipoServicio;
            oCombo.NombreTabla = "tblCombo";
            oCombo.ColumnaTexto = "Texto";
            oCombo.ColumnaValor = "Valor";
            if (oCombo.LlenarComboWeb())
            {
                cboTipoServicio = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                cboTipoServicio = null;
                return false;
            }
        }
        #endregion
    }
}
