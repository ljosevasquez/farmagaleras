using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class RepositorioInventario : IRepositorioInventario
    {
        public void IngresarInventario(Entidades.Inventario inventario)
        {
            using (SqlConnection conexion =
                new SqlConnection(ConfigurationManager.
                    ConnectionStrings["farmagaleras"].ConnectionString))
            {
                conexion.Open();
                SqlTransaction tran = conexion.BeginTransaction();
                try
                {
                    SqlCommand comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Connection = conexion;
                    comando.Transaction = tran;
                    comando.CommandText = "IngresarInventario";
                    comando.Parameters.Add("@CodigoInventario", SqlDbType.BigInt).Value = inventario.CodigoInventario;
                    comando.Parameters.Add("@Producto", SqlDbType.VarChar).Value = inventario.Producto;
                    comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = inventario.Presentacion;
                    comando.Parameters.Add("@Concentracion", SqlDbType.VarChar).Value = inventario.Concentracion;
                    comando.Parameters.Add("@Disponibilidad", SqlDbType.Int).Value = inventario.Disponibilidad;
                    comando.Parameters.Add("@NumeroEstante", SqlDbType.VarChar).Value = inventario.NumeroEstante;
                    comando.Parameters.Add("@FechaInventario", SqlDbType.SmallInt).Value = inventario.FechaInventario;
                    comando.Parameters.Add("@FechaVencimiento", SqlDbType.SmallInt).Value = inventario.FechaVencimiento;

                    comando.ExecuteNonQuery();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<Entidades.Inventario> ObtenerDomicilios(string codigoInventario, string producto, string presentacion, string concentracion, string disponibilidad, string numeroEstante, string fechaInventario, string fechaVencimiento)
        {
            List<Entidades.Inventario> inventarios = new List<Entidades.Inventario>();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["farmagaleras"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarInventario";
                comando.Parameters.Add("@Producto", SqlDbType.VarChar).Value = producto;
                comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                comando.Parameters.Add("@Concentracion", SqlDbType.VarChar).Value = concentracion;
                comando.Parameters.Add("@Disponibilidad", SqlDbType.VarChar).Value = disponibilidad;
                comando.Parameters.Add("@CodigoInventario", SqlDbType.BigInt).Value = codigoInventario;
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Inventario inventario = new Entidades.Inventario();
                        inventario.CodigoInventario = Convert.ToInt64(reader["CodigoInventario"]);
                        inventario.Producto = reader["Producto"].ToString();
                        inventario.Presentacion = reader["Presentacion"].ToString();
                        inventario.Concentracion = reader["Concentración"].ToString();
                        inventario.Disponibilidad = reader["Disponibilidad"].ToString();
                        inventario.NumeroEstante = reader["Documento"].ToString();
                        inventario.FechaInventario = (DateTime)reader["FechaInventario"];
                        inventario.FechaVencimiento = (DateTime)reader["FechaVencimiento"];

                        inventarios.Add(inventario);
                    }
                }
            }
            return inventarios;
        }

        public DataTable ObtenerInventarios()
        {
            DataTable inventarios = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["farmagaleras"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarInventarios";

                comando.Parameters.Add("@CodigoInvetario", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Producto", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Concentracion", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Disponibilidad", SqlDbType.BigInt).Value = string.Empty;
                comando.Parameters.Add("@NumeroEstante", SqlDbType.BigInt).Value = string.Empty;
                comando.Parameters.Add("@FechaInventario", SqlDbType.BigInt).Value = string.Empty;
                comando.Parameters.Add("@FechaVencimiento", SqlDbType.BigInt).Value = string.Empty;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(inventarios);
            }

            return inventarios;
        }
    }
}
