using SaberesSyllabus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Models
{
    public class Encargado
    {
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public EnumCargo Cargo { get; set; }
    }
}