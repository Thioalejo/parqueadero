using System;

namespace libClases.ReglasNegocio
{
    public class clsAgenciaViajes
    {
        public clsAgenciaViajes()
        {
            ValorDolar = 3000;
        }
        #region "Atributos/Propiedades"
        public Int16 NumeroPaquetes { get; set; }
        public string Destino { get; set; }
        private string TipoDestino;
        private double ValorPaquete;
        private double ValorDolar;
        private double PorcentajeDescuento;
        public double Subtotal { get; private set; }
        public double ValorDescuento { get; private set; }
        public double ValorPagar { get; private set; }
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool CalcularPago()
        {
            if (DefinirTipoDestino())
            {
                if (CalcularDescuento())
                {
                    ValorPagar = Subtotal - ValorDescuento;
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            else
            {
                return false;
            }
        }
        private bool DefinirTipoDestino()
        {
            switch (Destino.ToUpper())
            {
                case "CANCUN":
                    ValorPaquete = 2200;
                    TipoDestino = "INTERNACIONAL";
                    break;
                case "MEXICO":
                    ValorPaquete = 2450;
                    TipoDestino = "INTERNACIONAL";
                    break;
                case "MIAMI":
                    ValorPaquete = 1500;
                    TipoDestino = "INTERNACIONAL";
                    break;
                case "PUNTA CANA":
                    ValorPaquete = 2450;
                    TipoDestino = "INTERNACIONAL";
                    break;
                case "BOGOTA":
                    ValorPaquete = 1650000;
                    TipoDestino = "NACIONAL";
                    break;
                case "CARTAGENA":
                    ValorPaquete = 1850000;
                    TipoDestino = "NACIONAL";
                    break;
                case "SAN ANDRES":
                    ValorPaquete = 1500000;
                    TipoDestino = "NACIONAL";
                    break;
                case "AMAZONAS":
                    ValorPaquete = 2350000;
                    TipoDestino = "NACIONAL";
                    break;
                default:
                    ValorPaquete = 0;
                    TipoDestino = "";
                    Error = "No se definió un destino válido";
                    return false; 
            }
            return true;
        }
        private bool CalcularDescuento()
        {
            if (TipoDestino.ToUpper() == "NACIONAL")
            {
                Subtotal = NumeroPaquetes * ValorPaquete;
            }
            else
            {
                Subtotal = NumeroPaquetes * ValorPaquete * ValorDolar;
            }
            if (CalcularPorcentajeDescuento())
            {
                //Calculó el porcentaje
                ValorDescuento = Subtotal * PorcentajeDescuento;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CalcularPorcentajeDescuento()
        {
            //Invoca la regla de negocio
            //Defino el objeto
            clsRN_DescuentoPaquete oRNDescuento = new clsRN_DescuentoPaquete();
            //Defino propiedades de entrada
            oRNDescuento.TipoDestino = TipoDestino;
            oRNDescuento.NumeroPaquetes = NumeroPaquetes;
            //Invoco el método
            if (oRNDescuento.CalcularDescuento())
            {
                //Capturo respuesta, libero memoria y retorno
                PorcentajeDescuento = oRNDescuento.PorcentajeDescuento;
                oRNDescuento = null;
                return true;
            }
            else
            {
                //Leo el error, libera memoria y retorna false
                Error = oRNDescuento.Error;
                oRNDescuento = null;
                return false;
            }
        }
        #endregion
    }
}
