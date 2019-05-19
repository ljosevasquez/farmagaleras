using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public interface IRepositorioInventario
    {
        void IngresarInventario(Inventario inventario);

        List<Inventario> ObtenerDomicilios(string codigoInventario, string producto, string presentacion, string concentracion, string disponibilidad, string numeroEstante, string fechaInventario, string fechaVencimiento);
        DataTable ObtenerInventarios();
    }
}
