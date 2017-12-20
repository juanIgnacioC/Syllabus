using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaberesSyllabus.Models;
using SaberesSyllabus.Repositories;
using SaberesySoluciones.Models;
using SaberesySoluciones.ViewModel;

namespace SaberesySoluciones.Controllers
{
    public class AprendizajesController : Controller
    {
        // GET: Aprendizajes
        public ActionResult Index()
        {
            List<Aprendizaje> aprendizajes = Aprendizajes.LeerTodo();

            System.Diagnostics.Debug.WriteLine("leeeeeeeer todo");
            if (aprendizajes == null)
            {

                System.Diagnostics.Debug.WriteLine("nada que leeeeeeeeer");
                aprendizajes = new List<Aprendizaje>();
            }


            return View(aprendizajes);
        }


        [HttpPost]
        public ActionResult Crear(Aprendizaje aprendizaje)
        {
            aprendizaje = Aprendizajes.Crear(aprendizaje);
            return RedirectToAction("Index", "Aprendizajes");
        }

        [HttpPost]
        public ActionResult Editar(Aprendizaje aprendizaje)
        {
            Boolean result = Aprendizajes.Editar(aprendizaje);
            return RedirectToAction("Index", "Aprendizajes");
        }

        [HttpPost]
        public ActionResult Deshabilitar(String codigo)
        {
            Boolean resultadoConsulta;
            resultadoConsulta = Aprendizajes.Deshabilitar(codigo);

            return RedirectToAction("Index", "Aprendizajes");
        }

        [HttpPost]
        public ActionResult Habilitar(String codigo)
        {
            Boolean resultadoConsulta;
            resultadoConsulta = Aprendizajes.Habilitar(codigo);
            return RedirectToAction("Index", "Aprendizajes");
        }
    }
}