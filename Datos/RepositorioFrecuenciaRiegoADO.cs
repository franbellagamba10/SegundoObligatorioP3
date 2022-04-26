using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioFrecuenciaRiegoADO : IRepositorio<FrecuenciaRiego>
    {
        public bool Create(FrecuenciaRiego obj)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            string sql = "INSERT INTO FrecuenciasRiego VALUES(@tiempo, @cantidad); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlCommand com = new SqlCommand(sql, conexion);

            com.Parameters.AddWithValue("@tiempo", obj.tiempo.Trim());
            com.Parameters.AddWithValue("@cantidad", obj.cantidad);

            try
            {
                if (!obj.Validar() || YaExisteString(obj.tiempo))
                    return false;

                Conexion.AbrirConexion(conexion);
                int id = (int)com.ExecuteScalar();
                id = obj.id;
                return true;
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }

        }

        public bool Delete(int id)
        {
            bool ok = false;

            SqlConnection conexion = Conexion.ObtenerConexion();
            
            string sql = "DELETE FROM FrecuenciasRiego WHERE Id=" + id;
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                int filasAfectadas = com.ExecuteNonQuery();
                ok = filasAfectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }


            return ok;
        }

        public FrecuenciaRiego FindById(int id)
        {
            FrecuenciaRiego frecuenciaRiego = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM FrecuenciasRiego WHERE id = " + id + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    frecuenciaRiego = new FrecuenciaRiego()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        tiempo = reader.GetString(1),
                        cantidad = reader.GetInt32(2),
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }
            return frecuenciaRiego;
        }

        public FrecuenciaRiego FindByName(string cadena)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FrecuenciaRiego> GetAll()
        {
            List<FrecuenciaRiego> frecuenciasRiego = new List<FrecuenciaRiego>();

            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM FrecuenciasRiego;";
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    FrecuenciaRiego frecuenciaRiego = new FrecuenciaRiego()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        tiempo = reader.GetString(1),
                        cantidad = reader.GetInt32(2),
                    };

                    frecuenciasRiego.Add(frecuenciaRiego);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }

            return frecuenciasRiego;
        }

        public bool Update(FrecuenciaRiego obj)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            if (obj.Validar())
            {
                string sql =
                    "UPDATE FrecuenciasRiego SET tiempo=@tiempo, cantidad=@cantidad, WHERE Id=@id";

                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@id", obj.id);
                com.Parameters.AddWithValue("@tiempo", obj.tiempo.Trim());
                com.Parameters.AddWithValue("@cantidad", obj.cantidad);

                try
                {
                    Conexion.AbrirConexion(con);
                    int afectadas = com.ExecuteNonQuery();
                    ok = afectadas == 1;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Conexion.CerrarConexion(con);
                }

            }

            return ok;
        }

        public bool YaExisteString(string cadena)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT nombre FROM FrecuenciasRiego WHERE tiempo = '" + cadena + "';";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);

                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }
        }
    }
}