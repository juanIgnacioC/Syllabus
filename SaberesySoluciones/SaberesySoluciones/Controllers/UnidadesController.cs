using SaberesSyllabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class UnidadesController : Controller
    {
        // GET: Unidades


        public ActionResult Index()
        {
            //Para agregar un nuevo atributo a ViewBag basta con crearlo y asignarlo. No es necesaria acciones adicionales
            List<Unidad> Unidades = new Unidad().ListarTodos();
            if (Unidades == null)
            {
                Unidades = new List<Unidad>();
            }

            return View(Unidades);
        }
        
        [HttpGet]
        public ActionResult Crear()
        {
            Unidad unidad = new Unidad();
            return View(unidad);
        }

        [HttpPost]
        public ActionResult Crear(Unidad nueva)
        {
            nueva.Crear();
            return RedirectToAction("Index");
        }

        public ActionResult ListarTodos()
        {
            var unidad = new Unidad().ListarTodos();
            return View(unidad);
        }

        //localhost/Sucursal/Detalle/idValue
        public ActionResult Detalle(String id)
        {
            Unidad unidad = new Unidad();
            unidad.Seleccionar(id);
            return View(unidad);
        }
    }
}