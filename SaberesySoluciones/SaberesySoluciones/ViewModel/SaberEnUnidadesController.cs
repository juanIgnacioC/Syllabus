using SaberesSyllabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.ViewModel
{
    public class SaberEnUnidadesController : Controller
    {
        public List<Saber> Saberes { get; set; }
        public List<Unidad> Unidades { get; set; }
        public List<Unidad> UnidadDeSaber { get; set; }
        public string CodigoSaber { get; set; }

        public SaberEnUnidadesController()
        {
            this.Saberes = new List<Saber>();
            this.Unidades = new List<Unidad>();
            this.UnidadDeSaber = new List<Unidad>();
        }
    }
}
