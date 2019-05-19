using Entidades;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data;

namespace Repositorio
{
    public class RepositorioDeportistaMock : IRepositorioDomicilio
    {
        public static List<Domicilio> domicilios = new List<Domicilio>();

        public void EliminarDomicilio(long codigoDomicilio)
        {
            var domicilio = domicilios.FirstOrDefault(d=>d.CodigoDomicilio == codigoDomicilio);
            if (domicilio != null)
            {
                domicilios.Remove(domicilio);
            }
        }

        public void IngresarDomicilio(Domicilio domicilio)
        {
            domicilio.CodigoDomicilio = new Random().Next(1, 1000000000);
            domicilios.Add(domicilio);
        }

        public List<Domicilio> ObtenerDomicilios(string nombreProducto, string concentracion, string presentacion, string valorUnitario, string cantidad, string valorTotal, string nombreUsuario, string idUsuario, string direccionUsuario, string telefonoUsuario, string domiciliario)
        {
            return domicilios.Where(p =>(nombreProducto == "" || p.NombreProducto.Contains(nombreProducto)) &&
            (concentracion == "" || p.Concentracion.Contains(concentracion)) &&
            (presentacion == "" || p.Presentacion.Contains(presentacion)) &&
            (valorUnitario == "" || p.ValorUnitario.Contains(valorUnitario)) &&
            (cantidad == "" || p.Cantidad.Contains(cantidad)) &&
            (valorTotal == "" || p.ValorTotal.Contains(valorTotal)) &&

            (nombreUsuario == "" || p.NombreUsuario.Contains(nombreUsuario)) &&
            (idUsuario == "" || p.IdUsuario.Contains(idUsuario)) &&
            (direccionUsuario == "" || p.DireccionUsuario.Contains(direccionUsuario)) &&
            (telefonoUsuario == "" || p.TelefonoUsuario.Contains(telefonoUsuario)) &&
            (domiciliario == "" || p.Domiciliario.Contains(domiciliario))
            ).ToList();
        }

        public DataTable ObtenerDomicilios()
        {
            List<Domicilio> listado = new List<Domicilio>();
            var table = new DataTable();

            table.Columns.Add("nombreProducto", typeof(string));
            table.Columns.Add("Concentracion", typeof(string));
            table.Columns.Add("Presentacion", typeof(string));
            table.Columns.Add("ValorUnitario", typeof(string));
            table.Columns.Add("Cantidad", typeof(string));
            table.Columns.Add("ValorTotal", typeof(string));

            table.Columns.Add("NombreUsuario", typeof(string));
            table.Columns.Add("IdUsuario", typeof(string));
            table.Columns.Add("DireccionUsuario", typeof(string));
            table.Columns.Add("TelefonoUsuario", typeof(string));
            table.Columns.Add("Domiciliario", typeof(string));

            foreach (var domicilio in domicilios)
            {
                var row = table.NewRow();

                row["NombreProducto"] = domicilio.NombreProducto;
                row["Concentracion"] = domicilio.Concentracion;
                row["Presentacion"] = domicilio.Presentacion;
                row["ValorUnitario"] = domicilio.ValorUnitario;
                row["Cantidad"] = domicilio.Cantidad;
                row["ValorTotal"] = domicilio.ValorTotal;
                row["NombreUsuario"] = domicilio.NombreUsuario;
                row["IdUsuario"] = domicilio.IdUsuario;
                row["DireccionUsuario"] = domicilio.DireccionUsuario;
                row["TelefonoUsuario"] = domicilio.TelefonoUsuario;
                row["Domiciliario"] = domicilio.Domiciliario;

                table.Rows.Add(row);
            }

            return table;
        }

        public List<Domicilio> ObtenerDomicilios(string codigoDomicilio, string NombreProducto, string concentracion, string presentacion, string valorUnitario, string cantidad, string valorTotal, string nombreUsuario, string idUusuario, string barrioUsuario, string direccionUsuario, string telefonoUsuario, string domiciliario)
        {
            throw new NotImplementedException();
        }

        public DataTable ObtenerDomicilios()
        {
            throw new NotImplementedException();
        }
    }
}