using Entidades;
using Repositorio;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class InventarioNegocio
    {
        IRepositorioInventario repositorio;
        public InventarioNegocio ()
        {
            repositorio = new RepositorioInventarioMock();
        }

        public void IngresarInventario(Inventario inventario)
        {
            repositorio.IngresarInventario(inventario);
        }

        public List<Inventario> ObtenerInventarios(string codigoInventario, string producto, string presentacion, string concentracion, string disponibilidad, string numeroEstante, string fechaInventario, string fechaVencimiento)
        {
            return repositorio.ObtenerDomicilios(codigoInventario, producto, presentacion, concentracion, disponibilidad, numeroEstante, fechaInventario, fechaVencimiento);
        }

        public DataTable ObtenerInventarios()
        {
            return repositorio.ObtenerInventarios();
        }
    }
}
