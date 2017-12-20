using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Subcategoria
    {
        public int Id { get; set; }
        public List<Aprendizaje> Aprendizajes { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
    }
}