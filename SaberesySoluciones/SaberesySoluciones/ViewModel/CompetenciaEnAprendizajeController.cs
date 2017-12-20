using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaberesySoluciones.Models;
using SaberesSyllabus.Models;

namespace SaberesySoluciones.ViewModel
{
    public class CompetenciaEnAprendizajeController 
    {
        public List<Competencia> competencias { get; set; }
        public List<Aprendizaje> aprendizajes { get; set; }
        public List<Aprendizaje> aprendizajeDeCompentencia { get; set; }

        public CompetenciaEnAprendizajeController()
        {
            this.competencias = new List<Competencia>();
            this.aprendizajes = new List<Aprendizaje>();
            this.aprendizajeDeCompentencia = new List<Aprendizaje>();
        }
    }
}