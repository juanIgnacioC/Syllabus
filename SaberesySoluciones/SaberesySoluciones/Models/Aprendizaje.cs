using SaberesSyllabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Aprendizaje
    {
        public int Codigo { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Descripcion { get; set; }
        public List<Saber> Saberes { get; set; }
        public EnumEstado Estado { get; set;}
        public int PorcentajeLogro { get; set;}
        public Boolean Check { get; set; }

        public Aprendizaje()
        {
            this.Saberes = new List<Saber>();
        }
    }
}