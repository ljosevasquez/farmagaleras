using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Domicilio
    {
        public long CodigoDomicilio { get; set; }
        public string NombreProducto { get; set; }
        public string Concentracion { get; set; }
        public string Presentacion { get; set; }
        public string ValorUnitario { get; set; }
        public string Cantidad { get; set; }
        public string ValorTotal { get; set; }

        public string NombreUsuario { get; set; }
        public string IdUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public string TelefonoUsuario { get; set; }
        public string Domiciliario { get; set; }
    }
}
