using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libClases.ClasesBasicas
{
    public class clsEscalafon
    {
        #region "Constructor"
        /*public [NombreClase]()
        {
        }
        */
        public clsEscalafon()
        {
            //Inicializa las propiedades de entrada
            AñosExperiencia = -1;
            NivelEstudios = "";
            Publicaciones = -1;
        }
        #endregion
        #region "Atributos/Propiedades"
        public Int16 AñosExperiencia { get; set; }
        public string NivelEstudios { get; set; }
        public Int16 Publicaciones { get; set; }
        public Int32 PuntosTotales { get; private set; }
        public string Estado { get; private set; }
        public string Categoria { get; private set; }
        public Int32 Salario { get; private set; }
        private Int16 PuntosEstudios;
        private Int16 PuntosPublicaciones;
        private  Int16 PuntosExperiencia;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        private bool Validar()
        {
            if (AñosExperiencia < 0 || AñosExperiencia > 80)
            {
                Error = "No definió los años de experiencia del docente en forma correcta";
                return false;
            }
            //if (NivelEstudios == "")
            if (string.IsNullOrEmpty(NivelEstudios))
            {
                Error = "No definió el nivel de estudios del docente";
                return false;
            }
            if (Publicaciones < 0 || Publicaciones > 50)
            {
                Error = "Las publicaciones del docente deben estar entre 0 y 50";
                return false;
            }
            return true;
        }
        private void CalcularPuntosExperiencia()
        {
            if (AñosExperiencia < 5)
            {
                PuntosExperiencia = 10;
            }
            else
            {
                if (AñosExperiencia <= 10)
                {
                    PuntosExperiencia = 20;
                }
                else
                {
                    PuntosExperiencia = 50;
                }
            }
        }
        private bool CalcularPuntosEstudios()
        {
            switch (NivelEstudios.ToUpper())
            {
                case "PROFESIONAL":
                    PuntosEstudios = 5;
                    return true;
                case "ESPECIALISTA":
                    PuntosEstudios = 15;
                    return true;
                case "MASTER":
                    PuntosEstudios = 25;
                    return true;
                case "DOCTOR":
                    PuntosEstudios = 50;
                    return true;
                default:
                    PuntosEstudios = 0;
                    Error = "No definió un nivel de estudios válido: \n Debe ser: Profesional, Especialista, Master o Doctor";
                    return false;
            }
        }
        private void CalcularPuntosPublicaciones()
        {
            if (Publicaciones < 2)
            {
                PuntosPublicaciones = 10;
            }
            else
            {
                if (Publicaciones <= 5)
                {
                    PuntosPublicaciones = 25;
                }
                else
                {
                    PuntosPublicaciones = 50;
                }
            }
        }
        private void CalcularEstado()
        {
            PuntosTotales = PuntosEstudios + PuntosExperiencia + PuntosPublicaciones;
            if (PuntosTotales < 50)
            {
                Estado = "NO APTO";
                Salario = -1;
            }
            else
            {
                Estado = "APTO";
                if (PuntosTotales <= 75)
                {
                    Categoria = "CATEGORÍA I";
                    Salario = 3000000;
                }
                else
                {
                    if (PuntosTotales <= 100)
                    {
                        Categoria = "CATEGORÍA II";
                        Salario = 4000000;
                    }
                    else
                    {
                        Categoria = "CATEGORÍA III";
                        Salario = 5000000;
                    }
                }
            }
        }
        public bool CalcularCategoria()
        {
            if (Validar())
            {
                //Empieza los cálculos
                CalcularPuntosExperiencia();
                if (!CalcularPuntosEstudios())
                {
                    return false;
                }
                CalcularPuntosPublicaciones();
                CalcularEstado();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
