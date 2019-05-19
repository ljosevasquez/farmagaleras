using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace farmagaleras.Models
{
    public class Domicilio
    {
        public long CodigoDomicilio { get; set; }
        public string NombreProducto { get; set; }
        public string Concentracion { get; set; }
        public string presentacion { get; set; }
        public int ValorUnitario { get; set; }
        public int Cantidad { get; set; }
        public int ValorTotal { get; set; }

        public string NombreUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public int TelefonoUusuario { get; set; }
        public string Domiciliario { get; set; }
    }
}