using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Competencia
    {
        public int Codigo { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set; }
        public string Dominio { get; set;}
        public string Basico { get; set; }
        public string Intermedio { get; set; }
        public string Avanzado { get; set; }
        public string TiempoDesarrollo { get; set; }
        public List<Aprendizaje> Aprendizajes { get; set; }
        public string Estado { get; set; }
        public int PorcentajeLogro { get; set; }

        public Competencia()
        {
            this.Aprendizajes = new List<Aprendizaje>();
        }
    }
}