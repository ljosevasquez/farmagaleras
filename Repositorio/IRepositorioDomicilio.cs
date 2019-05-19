using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public interface IRepositorioDomicilio
    {
        void IngresarDomicilio(Domicilio inventario);

        List<Domicilio> ObtenerDomicilios(string codigoDomicilio, string NombreProducto, string concentracion, string presentacion, string valorUnitario, string cantidad, string valorTotal, string nombreUsuario, string idUusuario, string barrioUsuario, string direccionUsuario, string telefonoUsuario, string domiciliario);
        DataTable ObtenerDomicilios();
    }
}