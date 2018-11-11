using System;



namespace libClases.ClasesBasicas
{
    public class clsVenta
    {
        #region "Propiedades y atributos"
        public double ValorUnitario { get; set; }

        public Int16 Cantidad { get; set; }
        public double ValorAntesIVA { get; private set; }
        public double ValorIVA { get; private set; }
        public double Total { get; private set; }
        private double PorcentajeIVA;
        #endregion
        #region "Metodos"
        public void CalcularTotal()
        {
            Total = Cantidad * ValorUnitario;
            ValorAntesIVA = CalcularAntesIVA();
            CalcularIVA();
        }
        private double CalcularAntesIVA()
        {
            //Comentario de una linea
            //Defino el porcentaje de IVA en el 19%
            PorcentajeIVA = 0.19;
            /* Comentarios
             * de múltiples
             * líneas
             */
            return Total / (1 + PorcentajeIVA);
        }
        private void CalcularIVA()
        {
            ValorIVA = Total - ValorAntesIVA;
        }
        #endregion
    }
}
