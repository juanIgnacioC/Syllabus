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
            aprendizajeSaber.Aprendizajes = Aprendizajes.LeerHabilitados();
            if (aprendizajeSaber.Aprendizajes == null)
            {
                aprendizajeSaber.Aprendizajes = new List<Aprendizaje>();
            }
            aprendizajeSaber.Saberes = Saberes.LeerHabilitado();
            if (aprendizajeSaber.Saberes == null)
            {
                aprendizajeSaber.Saberes = new List<Saber>();
            }

            if (aprendizajeSaber.CodigoAprendizaje != null)
            {
                aprendizajeSaber.SaberDeAprendizaje = Saberes.LeerSaberesEnAprendizaje(aprendizajeSaber.CodigoAprendizaje);
                if (aprendizajeSaber.SaberDeAprendizaje == null)
                {
                    aprendizajeSaber.Saberes = new List<Saber>();
                }
                else {
                    foreach (var todoS in aprendizajeSaber.Saberes) {
                        foreach (var saber in aprendizajeSaber.Saberes) {
                            if (todoS.Codigo == saber.Codigo)
                            {
                                aprendizajeSaber.Saberes.Remove(todoS);
                            }
                        }
                    }
                }
            }

            return View(aprendizajeSaber);
        }

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
        public ActionResult AgregarSaber(String codigo)
        {
            if (aprendizajeSaber.CodigoAprendizaje != null) {
                var agregar = Saberes.CrearSaberEnAprendizaje(aprendizajeSaber.CodigoAprendizaje, codigo);
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