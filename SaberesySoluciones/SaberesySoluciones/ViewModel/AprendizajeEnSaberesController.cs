using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaberesySoluciones.Models;
using SaberesSyllabus.Models;

namespace SaberesySoluciones.ViewModel
{
    public class AprendizajeEnSaberesController
    {
        public List<Aprendizaje> Aprendizajes { get; set; }
        public List<Saber> Saberes { get; set; }
        public List<Saber> SaberDeAprendizaje { get; set; }
        public string CodigoAprendizaje { get; set; }

        public AprendizajeEnSaberesController()
        {
            this.Aprendizajes = new List<Aprendizaje>();
            this.Saberes = new List<Saber>();
            this.SaberDeAprendizaje = new List<Saber>();
        }
    }
}