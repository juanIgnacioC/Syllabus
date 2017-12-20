using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SaberesSyllabus.Models
{
    public enum TipoClase
    {
        [Description("Clase")]
        Clase,
        [Description("Laboratorio")]
        Laboratorio,
        [Description("Ayudantia")]
        Ayudantia,
    }

    public class EnumTipoClase
    {

    }
}