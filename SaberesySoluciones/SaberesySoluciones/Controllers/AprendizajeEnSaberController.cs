using SaberesSyllabus.Models;
using SaberesSyllabus.Repositories;
using SaberesySoluciones.Models;
using SaberesySoluciones.Repositories;
using SaberesySoluciones.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class AprendizajeEnSaberController : Controller
    {
        AprendizajeEnSaberesController aprendizajeSaber = new AprendizajeEnSaberesController();
        // GET: AprendizajeEnSaber
        public ActionResult Index()
        {
            List<Aprendizaje> aprendizajes = Aprendizajes.LeerHabilitados();
            if (aprendizajes == null)
            {
                aprendizajes = new List<Aprendizaje>();
            }
            foreach (Aprendizaje apr in aprendizajes)
            {
                apr.Saberes = Aprendizajes.LeerSubSaberes(apr.Codigo);

                //Ordenar las SubSaberes según el codigo para evitar que se vean desordenadas :)
                //apr.Saberes.Sort((x, y) => x.Codigo.CompareTo(y.Codigo));

                if (apr.Saberes== null)
                {
                    apr.Saberes = new List<Saber>();
                }
            }

            return View(aprendizajes);
        }
        /*
        [HttpPost]
        public ActionResult CrearSaber(Saber saber, Aprendizaje aprendizaje)
        {
            saber = Aprendizajes.Crear(aprendizaje);
            return RedirectToAction("Index", "Aprendizajes");
        }*/



        [HttpPost]
        public ActionResult CargarSaberes(String codigoAprendizaje)
        {
            var saberes = Saberes.LeerSaberesEnAprendizaje(codigoAprendizaje);
            if (saberes != null)
            {
                aprendizajeSaber.SaberDeAprendizaje = saberes;
            }
            aprendizajeSaber.CodigoAprendizaje = codigoAprendizaje;

            return RedirectToAction("Index", "AprendizajeEnSaber");
        }

        [HttpPost]
        public ActionResult AgregarSaber(String codigoA, String codigoS)
        {
            if (codigoA != null) {
                var agregar = Saberes.CrearSaberEnAprendizaje(codigoA, codigoS);
            }

            return RedirectToAction("Index", "AprendizajeEnSaber");
        }

        [HttpPost]
        public ActionResult EliminarSaber(String codigo)
        {
            if (aprendizajeSaber.CodigoAprendizaje != null)
            {
                var agregar = Saberes.EliminarSaberEnAprendizaje(aprendizajeSaber.CodigoAprendizaje, codigo);
            }
            return RedirectToAction("Index", "AprendizajeEnSaber");
        }
    }
}