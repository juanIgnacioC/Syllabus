using SaberesySoluciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesSyllabus.Models
{
    public class Saber
    {
        /*
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public EnumLogro logro { get; set; }
        */

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public EnumLogro Logro { get; set; }
        public EnumEstado Estado { get; set; }
        public string PorcentajeLogro { get; set; }
        public int Id { get; set; }
    }
}