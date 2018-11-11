using System;
using System.Xml;

namespace libClases.ReglasNegocio
{
    public class clsRN_DescuentoPaquete
    {
        #region "Atributos/Propiedades"
        public string TipoDestino { get; set; }
        public Int16 NumeroPaquetes { get; set; }
        public double PorcentajeDescuento { get; private set; }
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool CalcularDescuento()
        {
            if (Validar())
            {
                //Se consulta el archivo XML
                //El primer paso es crear el objeto xmldocument
                XmlDocument oDocumento = new XmlDocument();
                //Se controlan las posibles excepciones (errores de ejecución) con try catch
                try
                {
                    //Abrir el documento. Se debe pasar la ruta completa del archivo
                    //C:\Users\docenteitm\Documents\DS\libClases\libClases\XML\xmlDescuentoPaquetes.xml
                    oDocumento.Load(@"C:\Users\docenteitm\Documents\DS\libClases\libClases\XML\xmlDescuentoPaquetes.xml");
                    //oDocumento.Load("C:\\Users\\docenteitm\\Documents\\DS\\libClases\\libClases\\XML\\xmlDescuentoPaquetes.xml");
                    //Se hace la consulta 
                    string Consulta;
                    if (TipoDestino.ToUpper()=="INTERNACIONAL")
                    {
                        //Consulta para viajes internacionales
                        Consulta = "//Descuento_Internacional[@CantidadMinima<=" + NumeroPaquetes  +
                                         " and @CantidadMaxima>=" + NumeroPaquetes + "]";
                    }
                    else
                    {
                        //Consulta para viajes nacionales
                        Consulta = "//Descuento_Nacional[@CantidadMinima<=" + NumeroPaquetes +
                                         " and @CantidadMaxima>=" + NumeroPaquetes + "]";
                    }
                    //Asignar la consulta para crear la lista de nodos con la (s) respuestas
                    XmlNodeList oListaNodos = oDocumento.SelectNodes(Consulta);
                    //Se valida si hay nodos que cumplan con los criterios seleccionados
                    if (oListaNodos.Count > 0)
                    {
                        //Capturo el porcentaje de descuento de la propiedad innertext
                        PorcentajeDescuento = Convert.ToDouble(oListaNodos[0].InnerText) / 100.0;
                    }
                    else
                    {
                        PorcentajeDescuento = 0.0;
                    }
                    //Libera memoria y retorna
                    oDocumento = null;
                    oListaNodos = null;
                    return true;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    //Libera memoria
                    oDocumento = null;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(TipoDestino))
            {
                Error = "No definió el tipo de destino";
                return false;
            }
            if (TipoDestino.ToUpper() != "INTERNACIONAL" && TipoDestino.ToUpper()!="NACIONAL")
            {
                Error = "No definió un tipo de destino válido, este debe ser Nacional o Internacional";
                return false;
            }
            if (NumeroPaquetes <=0)
            {
                Error = "No definió un número de paquetes válido";
                return false;
            }
            return true;
        }
        #endregion
    }
}
