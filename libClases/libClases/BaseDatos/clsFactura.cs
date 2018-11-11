using System;
using System.Web.UI.WebControls;
using libComunes.CapaObjetos;
using libComunes.CapaDatos;

namespace libClases.BaseDatos
{
    public class clsFactura
    {
        #region "Propiedades"
        public Int32 NumeroFactura { get; set; }
        public Int32 CodigoEmpleado { get; set; }
        public string DocumentoCliente { get; set; }
        public Int32 CodigoDetalleFactura { get; set; }
        public Int32 CodigoProducto { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 Total { get; private set; }
        public GridView grdFactura { get; set; }
        public Int32 ValorUnitario { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool Grabar()
        {
            if (NumeroFactura == 0)
            {
                if(!GrabarEncabezado())
                {
                    return false;
                }
            }
            if (GrabarDetalle())
            {
                if (CalcularTotal()){return true;}
                else { return false; }
            }
            else
            {
                return false;
            }
        }
        private bool GenerarFactura()
        {
            //Ejecuta la consulta para generar el número máximo de factura
            SQL = "SELECT   MAX (intNumero_FACT) + 1 AS Numero " +
                  "FROM     tblFactura ";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    NumeroFactura = oConexion.Reader.GetInt32(0);
                    //Libera memoria
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No tiene filas, se levanta un error
                    Error = "No se pudo generar el número de facturación";
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
        private bool GrabarEncabezado()
        {
            if (GenerarFactura())
            {
                //Inserta en la tabla tblFactura
                SQL = "INSERT INTO tblFactura (intNumero_FACT, strDocumento_CLIE, dtmFecha_FACT, " +
                                          "intCodigo_EMCA) " +
                      "VALUES (@prNumeroFactura, @prDocumento, GETDATE(), @prEmpleado)";

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prNumeroFactura", NumeroFactura);
                oConexion.AgregarParametro("@prDocumento", DocumentoCliente);
                oConexion.AgregarParametro("@prEmpleado", CodigoEmpleado);

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
            else
            {
                return false;
            }
        }
        private bool GrabarDetalle()
        {
            //Inserta en la tabla tblFactura
            SQL = "INSERT INTO tblDetalleFactura (intNumero_FACT, intCodigo_PROD, intCantidad_DEFA, " +
                                      "intValorUnitario_DEFA) " +
                  "VALUES (@prNumeroFactura, @prProducto,  @prCantidad, @prValorUnitario)";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNumeroFactura", NumeroFactura);
            oConexion.AgregarParametro("@prProducto", CodigoProducto);
            oConexion.AgregarParametro("@prCantidad", Cantidad);
            oConexion.AgregarParametro("@prValorUnitario", ValorUnitario);

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
        private bool CalcularTotal()
        {
            SQL = "SELECT   SUM (intCantidad_DEFA * intValorUnitario_DEFA) AS Total " +
                  "FROM     tblDetalleFactura " +
                  "WHERE    intNumero_FACT = @prNumeroFactura";

            clsConexion oConexion = new clsConexion();
            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prNumeroFactura", NumeroFactura);
            //Se invoca el método consultar
            if (oConexion.Consultar())
            {
                //Se verifica si hay datos
                if (oConexion.Reader.HasRows)
                {
                    //Tiene filas, se debe leer la información
                    oConexion.Reader.Read();
                    //Se captura la información
                    Total = oConexion.Reader.GetInt32(0);
                    //Libera memoria
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return true;
                }
                else
                {
                    //No tiene filas, se levanta un error
                    Error = "No se pudo generar el número de facturación";
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
        public bool LlenarGrid()
        {
            SQL = "SELECT dbo.tblDEtalleFActura.intCodigo_DEFA AS CODIGO, dbo.tblTIpoPRoducto.strNombre_TIPR AS [TIPO PRODUCTO], dbo.tblPRODucto.strNombre_PROD AS PRODUCTO, " +
                         "dbo.tblDEtalleFActura.intCantidad_DEFA AS CANTIDAD, dbo.tblDEtalleFActura.intValorUnitario_DEFA AS[VALOR UNITARIO], " +
                         "dbo.tblDEtalleFActura.intCantidad_DEFA* dbo.tblDEtalleFActura.intValorUnitario_DEFA AS SUBTOTAL " +
                  "FROM dbo.tblDEtalleFActura INNER JOIN dbo.tblFACTura  " +
                        " ON dbo.tblDEtalleFActura.intNumero_FACT = dbo.tblFACTura.intNumero_FACT " +
                        "INNER JOIN dbo.tblPRODucto " +
                        "ON dbo.tblDEtalleFActura.intCodigo_PROD = dbo.tblPRODucto.intCodigo_PROD " +
                        "INNER JOIN dbo.tblTIpoPRoducto " +
                        "ON dbo.tblPRODucto.intCodigo_TIPR = dbo.tblTIpoPRoducto.intCodigo_TIPR " +
                  "WHERE    dbo.tblDEtalleFActura.intNumero_FACT = @prFactura";

            clsGrid oGrid = new clsGrid();
            oGrid.SQL = SQL;
            oGrid.AgregarParametro("@prFactura", NumeroFactura);
            oGrid.gridGenerico = grdFactura;
            oGrid.NombreTabla = "Factura";
            if (oGrid.LlenarGridWeb())
            {
                grdFactura = oGrid.gridGenerico;
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
