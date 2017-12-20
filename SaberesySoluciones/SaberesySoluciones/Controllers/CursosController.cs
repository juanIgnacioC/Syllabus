using SaberesySoluciones.Models;
using System;
using SaberesySoluciones.Repositories;
using SaberesSyllabus.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaberesySoluciones.Controllers
{
    public class CursosController : Controller
    {
        // GET: Cursos
        public ActionResult Index()
        {
            List<Curso> finalCurso = Cursos.LeerTodo();
            if (finalCurso == null)
            {
                finalCurso = new List<Curso>();
            }
            return View(finalCurso);
        }

        // GET: Cursos/Create
        [HttpPost]
        public ActionResult Crear(Curso curso)
        {
            Console.WriteLine("Dentro de crear del controlador de cursos");
            curso = Cursos.Crear(curso);
            return RedirectToAction("Index", "Cursos");
        }

        // POST: Cursos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cursos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
