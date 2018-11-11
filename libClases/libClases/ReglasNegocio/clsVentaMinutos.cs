using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libClases.ReglasNegocio
{
    public class clsVentaMinutos
    {
        public clsVentaMinutos()
        {
            ValorMinuto = 250;
        }
        #region "Atributos/Propiedades"
        public string NumeroCelular { get; set; }
        public Int32 ValorRecarga { get; set; }
        private double PorcentajeMinutosExtra;
        private Int32 ValorMinuto;
        public Int32 MinutosComprados { get; private set; }
        public Int32 MinutosExtra { get; private set; }
        public Int32 MinutosTotales { get; private set; }
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool CalcularTotalMinutos()
        {
            if (CalcularMinutosExtra())
            {
                MinutosTotales = MinutosComprados + MinutosExtra;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CalcularMinCompra()
        {
            MinutosComprados = ValorRecarga / ValorMinuto;
        }
        private bool CalcularMinutosExtra()
        {
            CalcularMinCompra();
            if (CalcularPorcentajeMinutosExtra())
            {
                MinutosExtra = Convert.ToInt32(MinutosComprados * PorcentajeMinutosExtra);
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CalcularPorcentajeMinutosExtra()
        {
            //Invoca la regla de negocio
            clsRN_MinutosExtra oMinutos = new clsRN_MinutosExtra();
            oMinutos.NumeroCelular = NumeroCelular;
            oMinutos.ValorRecarga = ValorRecarga;
            if (oMinutos.CalcularPromocion())
            {
                PorcentajeMinutosExtra = oMinutos.PorcentajeMinutosExtra;
                oMinutos = null;
                return true;
            }
            else
            {
                Error = oMinutos.Error;
                oMinutos = null;
                return false;
            }
        }
        #endregion
    }
}
