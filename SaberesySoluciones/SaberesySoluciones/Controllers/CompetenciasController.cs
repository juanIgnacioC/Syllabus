using SaberesySoluciones.Models;
using SaberesySoluciones.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class CompetenciasController : Controller
    {
        
        // GET: Competencias
        public ActionResult Index()
        {
            List<Competencia> finalcompetencias = Competencias.LeerTodo();
            if (finalcompetencias == null)
            {
                finalcompetencias = new List<Competencia>();
            }

            return View(finalcompetencias);
        }

        [HttpPost]
        public ActionResult Crear(Competencia competencia)
        {
            competencia = Competencias.Crear(competencia);
            return RedirectToAction("Index", "Competencias");
        }

        [HttpPost]
        public ActionResult Editar(Competencia competencia)
        {
            Boolean result = Competencias.Editar(competencia);
            return RedirectToAction("Index", "Competencias");
        }

        [HttpPost]
        public ActionResult Deshabilitar(int codigo)
        {
            Boolean resultadoConsulta;
            resultadoConsulta = Competencias.Deshabilitar(codigo);

            return RedirectToAction("Index", "Competencias");
        }

        [HttpPost]
        public ActionResult Habilitar(int codigo)
        {
            Boolean resultadoConsulta;
            resultadoConsulta = Competencias.Habilitar(codigo);
            return RedirectToAction("Index", "Competencias");
        }
    }
}