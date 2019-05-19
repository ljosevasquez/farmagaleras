using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace farmagaleras.Models
{
    public class Inventario
    {
        public long CodigoInventario { get; set; }
        public string Producto { get; set; }
        public string presentacion { get; set; }
        public string Concentracion { get; set; }
        public int Disponibilidad { get; set; }
        public int NumeroEstante { get; set; }
        public DateTime FechaInventario { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}