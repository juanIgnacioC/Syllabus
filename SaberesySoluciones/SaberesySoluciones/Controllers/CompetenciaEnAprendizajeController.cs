using SaberesSyllabus.Models;
using SaberesySoluciones.Models;
using SaberesSyllabus.Repositories;
using SaberesySoluciones.Repositories;
using SaberesySoluciones.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class CompetenciaEnAprendizajeController : Controller
    {
        // GET: CompetenciaEnAprendizaje
        public ActionResult Index()
        {
            List<Competencia> competencias = Competencias.LeerTodo();
            if (competencias == null)
            {
                competencias = new List<Competencia>();
            }
            foreach (Competencia comp in competencias)
            {
                comp.Aprendizajes = Competencias.LeerSubAprendizajes(comp.Codigo);

                //Ordenar las SubSaberes según el codigo para evitar que se vean desordenadas :)
                //apr.Saberes.Sort((x, y) => x.Codigo.CompareTo(y.Codigo));

                if (comp.Aprendizajes == null)
                {
                    comp.Aprendizajes = new List<Aprendizaje>();
                }
            }

            return View(competencias);
        }
        /*
        [HttpPost]
        public ActionResult CargarCompetenciaes(int codigoSaber)
        {
            var competencias = Competenciaes.LeerSubSaberes(codigoSaber);
            if (competencias != null)
            {
                saberCompetencia.CompetenciaDeSaber = ;
            }
            aprendizajeSaber.CodigoAprendizaje = codigoAprendizaje;

            return RedirectToAction("Index", "AprendizajeEnSaber");
        }

        [HttpPost]
        public ActionResult AgregarSaber(String codigo)
        {
            if (aprendizajeSaber.CodigoAprendizaje != null)
            {
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
        }*/
    }
}