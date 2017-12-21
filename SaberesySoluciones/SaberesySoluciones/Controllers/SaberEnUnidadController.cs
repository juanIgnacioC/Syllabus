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
    public class SaberEnUnidadController : Controller
    {
        // GET: AprendizajeEnSaber
        public ActionResult Index()
        {
            List<Unidad> unidades = Unidades.LeerTodo();
            if (unidades == null)
            {
                unidades = new List<Unidad>();
            }
            foreach (Unidad uni in unidades)
            {
                uni.Saberes = Unidades.LeerSubSaberes(uni.Id);

                //Ordenar las SubSaberes según el codigo para evitar que se vean desordenadas :)
                //apr.Saberes.Sort((x, y) => x.Codigo.CompareTo(y.Codigo));

                if (uni.Saberes == null)
                {
                    uni.Saberes = new List<Saber>();
                }
            }

            return View(unidades);
        }

        [HttpPost]
        public ActionResult AgregarSaber(String codigoU, String codigoS)
        {
            if (codigoU != null)
            {
                var agregar = Unidades.CrearSaberEnUnidad(codigoU, codigoS);
            }

            return RedirectToAction("Index", "SaberEnUnidad");
        }

        /*
        [HttpPost]
        public ActionResult CargarUnidades(int codigoSaber)
        {
            var unidades = Unidades.LeerSubSaberes(codigoSaber);
            if (unidades != null)
            {
                saberUnidad.UnidadDeSaber = ;
            }
            aprendizajeSaber.CodigoAprendizaje = codigoAprendizaje;

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