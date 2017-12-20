using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaberesSyllabus.Repositories;
using SaberesSyllabus.Models;
using SaberesySoluciones.ViewModel;

namespace SaberesySoluciones.Controllers
{
    public class EvaluacionUnidadController : Controller
    {
        // GET: EvaluacionUnidad
        public ActionResult Index()
        {
            List<Unidad> unidades = Unidades.LeerTodo();
            List<Evaluacion> evaluaciones = Evaluaciones.LeerTodo();
            UnionEvaluacionUnidad lista = new UnionEvaluacionUnidad()
            {
                Unidades = unidades,
                Evaluaciones = evaluaciones
            };
            return View(lista);
        }
    }
}