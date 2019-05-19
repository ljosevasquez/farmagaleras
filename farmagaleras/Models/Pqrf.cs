using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace farmagaleras.Models
{
    public class Pqrf
    {
        public string NombreCompleto { get; set; }
        public int Identificacion { get; set; }
        public int Telefono { get; set; }
        public string Barrio { get; set; }
        public string Correo { get; set; }
        public string TipoRecurso { get; set; }
        public DateTime Fecha { get; set; }
        public string SituacionPresentada { get; set; }
    }
}