using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class EvaluacionController : Controller
    {
        // GET: Evaluacion
        public ActionResult Index()
        {
            ViewBag.title = "Vista Evaluaciones";
            return View();
        }
    }
}