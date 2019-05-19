using Entidades;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data;

namespace Repositorio
{
    public class RepositorioInventarioMock : IRepositorioInventario
    {
        public static List<Inventario> inventarios = new List<Inventario>();

        public void EliminarInventario(long idInventario)
        {
            var inventario = inventarios.FirstOrDefault(d => d.CodigoInventario == idInventario);
            if(inventario != null)
            {
                inventarios.Remove(inventario);
            }
        }

        public void IngresarInventario(Inventario inventario)
        {
            inventario.CodigoInventario = new Random().Next(1, 1000000000);
            inventarios.Add(inventario);
        }

        public List<Inventario> ObtenerDomicilios(long codigoInventario, string producto, string presentacion, string concentracion, string disponibilidad, string numeroEstante, string fechaInventario, string fechaVencimiento)
        {
            return inventarios.Where(p => (codigoInventario == '#' || p.CodigoInventario == codigoInventario) &&
            (producto == "" || p.Producto.Contains(producto)) &&
            (presentacion == "" || p.Presentacion.Contains(presentacion)) &&
            (concentracion == "" || p.Concentracion.Contains(concentracion)) &&
            (disponibilidad == "" || p.Disponibilidad.Contains(disponibilidad)) &&
            (numeroEstante == "" || p.NumeroEstante.Contains(numeroEstante)) &&
            ).ToList();
        }

        public DataTable ObtenerInventarios()
        {
            List<Inventario> listado = new List<Inventario>();
            var table = new DataTable();

            table.Columns.Add("Producto", typeof(string));
            table.Columns.Add("Presentacion", typeof(string));
            table.Columns.Add("Concentracion", typeof(string));
            table.Columns.Add("Disponibilidad", typeof(string));
            table.Columns.Add("NumeroEstante", typeof(string));
            table.Columns.Add("FechaInventario", typeof(DateTime));
            table.Columns.Add("FechaVencimiento", typeof(DateTime));

            foreach (var deportista in inventarios)
            {
                var row = table.NewRow();

                row["PrimerNombre"] = deportista.Producto;
                row["SegundoNombre"] = deportista.Presentacion;
                row["PrimerApellido"] = deportista.Concentracion;
                row["SegundoApellido"] = deportista.Disponibilidad;
                row["NumeroDocumento"] = deportista.NumeroEstante;
                row["FechaNacimiento"] = deportista.FechaInventario;
                row["FechaNacimiento"] = deportista.FechaVencimiento;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}