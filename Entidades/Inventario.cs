using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Inventario
    {
        public long CodigoInventario { get; set; }
        public string CodigoProducto { get; set; }
        public string Producto { get; set; }
        public string Presentacion { get; set; }
        public string Concentracion { get; set; }
        public string Disponibilidad { get; set; }
        public string NumeroEstante { get; set; }
        public DateTime FechaInventario { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
