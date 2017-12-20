using SaberesSyllabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Curso
    {
        public string Nombre { get; set; }
        public int HorasPresenciales { get; set; }
        public int HorasAutonomas { get; set; }
        public string Descripcion { get; set; }
        public List<Unidad> Unidades { get; set; }
        public List<Competencia> Competencias { get; set; }
        public Encargado Encargado { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public EnumEstado Estado { get; set; }

        public Curso()
        {
            this.Unidades = new List<Unidad>();
            this.Competencias = new List<Competencia>();
            this.Alumnos = new List<Alumno>();
        }
    }
}