using System;
using System.Globalization;
using System.Xml;

namespace libClases.ReglasNegocio
{
    public class clsRN_MinutosExtra
    {
        #region "Atributos/Propiedades"
        public Int32 ValorRecarga { get; set; }
        public string NumeroCelular { get; set; }
        private string DiaSemana;
        private string UltimoDigito;
        public double PorcentajeMinutosExtra { get; private set; }
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        private void CalcularUltimoDigito()
        {
            UltimoDigito = NumeroCelular.Substring(NumeroCelular.Length - 1, 1);
        }
        private void CalcularDiaSemana()
        {
            //Culture-info: Español
            CultureInfo ci = new CultureInfo("Es-Es");
            DiaSemana = ci.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        }
        public bool CalcularPromocion()
        {
            //Se invocan los métodos privados
            CalcularDiaSemana();
            CalcularUltimoDigito();
            string Consulta;
            XmlDocument oDocumento = new XmlDocument();
            try
            {
                //Carga el documento
                oDocumento.Load(@"C:\Users\docenteitm\Documents\DS\libClases\libClases\XML\xmlMinutosExtra.xml");
                //Construyo la consulta
                Consulta = "//Promocion[@Dia='" + DiaSemana.ToUpper() + "' and @DIGITO=" + UltimoDigito +
                           " and @VALOR_MIN<=" + ValorRecarga + " and @VALOR_MAX>=" + ValorRecarga + "]";
                XmlNodeList oNodos = oDocumento.SelectNodes(Consulta);
                if (oNodos.Count > 0)
                {
                    PorcentajeMinutosExtra = Convert.ToDouble(oNodos[0].InnerText) / 100.0;
                    oDocumento = null;
                    oNodos = null;
                    return true;
                }
                else
                {
                    Error = "La consulta no devolvió valores válidos";
                    PorcentajeMinutosExtra = 0;
                    oDocumento = null;
                    oNodos = null;
                    return false;
                }
            }
            catch(Exception ex)
            {
                Error = ex.Message;
                oDocumento = null;
                return false;
            }
        }
        #endregion
    }
}
