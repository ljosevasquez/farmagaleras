using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    class Pqrf
    {
        public string NombreCompleto { get; set; }
        public int Identificacion { get; set; }
        public int Telefono { get; set; }
        public Barrio Barrio { get; set; }
        public string Correo { get; set; }
        public TipoRecurso TipoRecurso { get; set; }
        public DateTime Fecha { get; set; }
        public string SituacionPresentada { get; set; }
    }
}
