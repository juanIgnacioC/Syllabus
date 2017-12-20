using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Categoria
    {
        public List<Subcategoria> Subcategorias { get; set; }
        public string Nombre { get; set; }
    }
}