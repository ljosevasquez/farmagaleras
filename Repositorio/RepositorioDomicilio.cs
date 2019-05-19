using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repositorio
{
    public class RepositorioInventario : IRepositorioInventario
    {
        public void IngresarDomicilio(Entidades.Domicilio domicilio)
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
                    comando.CommandText = "IngresarDomicilio";
                    comando.Parameters.Add("@CodigoDomicilio", SqlDbType.BigInt).Value = domicilio.CodigoDomicilio;
                    comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = domicilio.NombreProducto;
                    comando.Parameters.Add("@Concentracion", SqlDbType.VarChar).Value = domicilio.Concentracion;
                    comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = domicilio.Presentacion;
                    comando.Parameters.Add("@ValorUnitario", SqlDbType.VarChar).Value = domicilio.Presentacion;
                    comando.Parameters.Add("Cantidad", SqlDbType.VarChar).Value = domicilio.Cantidad;
                    comando.Parameters.Add("@ValorTotal", SqlDbType.VarChar).Value = domicilio.ValorTotal;

                    comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = domicilio.NombreUsuario;
                    comando.Parameters.Add("@IdUsuario", SqlDbType.VarChar).Value = domicilio.IdUsuario;
                    comando.Parameters.Add("@DireccionUsuario", SqlDbType.VarChar).Value = domicilio.DireccionUsuario;
                    comando.Parameters.Add("@TelefonoUsuario", SqlDbType.VarChar).Value = domicilio.TelefonoUsuario;
                    comando.Parameters.Add("@Domiciliario", SqlDbType.VarChar).Value = domicilio.Domiciliario;

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

        public List<Entidades.Domicilio> ObtenerDomicilios(string codigoDomicilio, string nombreProducto, string concentracion, string presentacion, string valorUnitario, string cantidad, string valorTotal, string nombreUsuario, string idUsuario, string direccionUsuario, string telefonoUsuario, string domiciliario)
        {
            List<Entidades.Domicilio> domicilios = new List<Entidades.Domicilio>();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["farmagaleras"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarDomicilio";
                comando.Parameters.Add("@CodigoDomicilio", SqlDbType.BigInt).Value = codigoDomicilio;
                comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = nombreProducto;
                comando.Parameters.Add("@Concentracion", SqlDbType.BigInt).Value = concentracion;
                comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = presentacion;
                comando.Parameters.Add("@ValorUnitario", SqlDbType.BigInt).Value = valorUnitario;
                comando.Parameters.Add("@Cantidad", SqlDbType.BigInt).Value = cantidad;
                comando.Parameters.Add("@ValorTotal", SqlDbType.BigInt).Value = valorTotal;
                comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = nombreUsuario;
                comando.Parameters.Add("@IdUsuario", SqlDbType.BigInt).Value = idUsuario;
                comando.Parameters.Add("@DireccionUsuario", SqlDbType.VarChar).Value = direccionUsuario;
                comando.Parameters.Add("@TelefonoUsuario", SqlDbType.BigInt).Value = telefonoUsuario;
                comando.Parameters.Add("@Domiciliario", SqlDbType.BigInt).Value = domiciliario;



                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Domicilio domicilio = new Entidades.Domicilio();
                        domicilio.CodigoDomicilio = Convert.ToInt64(reader["CodigoDomicilio"]);
                        domicilio.NombreProducto = reader["NombreProducto"].ToString();
                        domicilio.Concentracion = reader["Concentracion"].ToString();
                        domicilio.Presentacion = reader["Presentacion"].ToString();
                        domicilio.ValorUnitario = reader["ValorUnitario"].ToString();
                        domicilio.Cantidad = reader["Cantidad"].ToString();
                        domicilio.ValorTotal = reader["ValorTotal"].ToString();

                        domicilio.NombreUsuario = reader["NombreUsuario"].ToString();
                        domicilio.IdUsuario = reader["IdUsuario"].ToString();
                        domicilio.DireccionUsuario = reader["DireccionUsuario"].ToString();
                        domicilio.TelefonoUsuario = reader["TelefonoUsuario"].ToString();
                        domicilio.Domiciliario = reader["Domiciliario"].ToString();

                        domicilios.Add(domicilio);
                    }
                }
            }
            return domicilios;
        }

        public DataTable ObtenerDomicilios()
        {
            DataTable domicilios = new DataTable();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["farmagaleras"].ConnectionString))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = conexion;
                comando.CommandText = "ConsultarDomicilios";

                comando.Parameters.Add("@CodigoDomicilio", SqlDbType.SmallInt).Value = string.Empty;
                comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@Concentracion", SqlDbType.Char).Value = string.Empty;
                comando.Parameters.Add("@Presentacion", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@ValorUnitario", SqlDbType.Money).Value = string.Empty;
                comando.Parameters.Add("@Cantidad", SqlDbType.Char).Value = string.Empty;
                comando.Parameters.Add("@ValorTotal", SqlDbType.Money).Value = string.Empty;
                comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@IdUsuario", SqlDbType.SmallInt).Value = string.Empty;
                comando.Parameters.Add("@DireccionUsuario", SqlDbType.VarChar).Value = string.Empty;
                comando.Parameters.Add("@TelefonoUsuario", SqlDbType.Char).Value = string.Empty;
                comando.Parameters.Add("@Domiciliario", SqlDbType.VarChar).Value = string.Empty;

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(domicilios);
            }

            return domicilios;
        }
    }
}
