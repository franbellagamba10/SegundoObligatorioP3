using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioTipoIluminacionADO : IRepositorio<TipoIluminacion>
    {
        public bool Create(TipoIluminacion obj)
        {
            {
                SqlConnection conexion = Conexion.ObtenerConexion();


                string sql = "INSERT INTO TiposIluminacion VALUES(@iluminacion); " +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";
                SqlCommand com = new SqlCommand(sql, conexion);

                com.Parameters.AddWithValue("@iluminacion", obj.iluminacion.Trim());

                try
                {
                    if (!obj.Validar() || YaExisteString(obj.iluminacion))
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
        }

        public bool Delete(int id)
        {
            bool ok = false;

            SqlConnection conexion = Conexion.ObtenerConexion();
            
            string sql = "DELETE FROM TiposIluminacion WHERE Id=" + id;
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                int tuplasAfectadas = com.ExecuteNonQuery();
                ok = tuplasAfectadas == 1;
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

        public TipoIluminacion FindById(int id)
        {
            TipoIluminacion tipoIluminacion = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TiposIluminacion WHERE id = " + id + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    tipoIluminacion = new TipoIluminacion()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        iluminacion = reader.GetString(1)
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
            return tipoIluminacion;
        }

        public TipoIluminacion FindByName(string cadena)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoIluminacion> GetAll()
        {
            List<TipoIluminacion> tipoIluminaciones = new List<TipoIluminacion>();
            SqlConnection conexion = Conexion.ObtenerConexion();
            string sql = "SELECT * FROM TiposIluminacion;";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    TipoIluminacion tipoIluminacion = new TipoIluminacion()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        iluminacion = reader.GetString(1),


                    };
                    tipoIluminaciones.Add(tipoIluminacion);
                }
            }
            catch (Exception ex)
            {
                //log de error
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }
            return tipoIluminaciones;
        }

        public bool Update(TipoIluminacion obj)
        {
            throw new NotImplementedException();
        }

        public bool YaExisteString(string cadena)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT nombre FROM TiposIluminacion WHERE iluminacion = '" + cadena + "';";
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