using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaberesySoluciones.Models;
using SaberesSyllabus.Models;

namespace SaberesySoluciones.ViewModel
{
    public class UnionEvaluacionUnidad
    {
        public List<Unidad> Unidades {get; set;}
        public List<Evaluacion> Evaluaciones { get; set; }
        public List<Evaluacion> EvaluacionesEnUnidad { get; set; }

        public UnionEvaluacionUnidad()
        {
            this.Unidades = new List<Unidad>();
            this.Evaluaciones = new List<Evaluacion>();
            this.EvaluacionesEnUnidad = new List<Evaluacion>();
           
        }
    }
}
