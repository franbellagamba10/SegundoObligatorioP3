using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioFichasADO : IRepositorio<Ficha>
    {
        RepositorioFrecuenciaRiegoADO repoFrecuenciaRiego;
        RepositorioTipoIluminacionADO repoTipoIluminacion;

        public RepositorioFichasADO(RepositorioFrecuenciaRiegoADO repoFrecuenciaRiego, RepositorioTipoIluminacionADO repoTipoIluminacion)
        {
            this.repoFrecuenciaRiego = repoFrecuenciaRiego;
            this.repoTipoIluminacion = repoTipoIluminacion;
        }
        public bool Create(Ficha obj)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            string sql = "INSERT INTO Ficha VALUES(@frecuenciaRiego, @temperatura, @tipoIluminacion); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlCommand com = new SqlCommand(sql, conexion);

            com.Parameters.AddWithValue("@frecuenciaRiego", obj.frecuenciaRiego);
            com.Parameters.AddWithValue("@temperatura", obj.temperatura);
            com.Parameters.AddWithValue("@tipoIluminacion", obj.tipoIluminacion);

            try
            {
                if (!obj.Validar())
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

            //PUEDO NO USAR SQLPARAMETER PORQUE EL ÚNICO DATO ES UN ENTERO
            string sql = "DELETE FROM Ficha WHERE Id=" + id;
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

        public Ficha FindById(int id)
        {
            Ficha ficha = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Ficha WHERE id = " + id + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    ficha = new Ficha()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        frecuenciaRiego = repoFrecuenciaRiego.FindById(reader.GetInt32(1)),
                        tipoIluminacion = repoTipoIluminacion.FindById(reader.GetInt32(2)),
                        temperatura = reader.GetInt32(3)
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
            return ficha;
        }

        public IEnumerable<Ficha> GetAll()
        {
            List<Ficha> fichas = new List<Ficha>();

            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Ficha;";
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Ficha ficha = new Ficha()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        frecuenciaRiego = repoFrecuenciaRiego.FindById(reader.GetInt32(1)),
                        tipoIluminacion = repoTipoIluminacion.FindById(reader.GetInt32(2)),
                        temperatura = reader.GetInt32(3)
                    };

                    fichas.Add(ficha);
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

            return fichas;
        }

        public bool Update(Ficha obj)
        {
            bool ok = false;

            SqlConnection con = Conexion.ObtenerConexion();

            if (obj.Validar())
            {
                string sql =
                    "UPDATE Ficha SET id=@id, frecuenciaRiego=@frecuenciaRiego, temperatura=@temperatura,tipoIluminacion=@tipoIluminacion, WHERE Id=@id";

                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@id", obj.id);
                com.Parameters.AddWithValue("@frecuenciaRiego", obj.frecuenciaRiego);
                com.Parameters.AddWithValue("@temperatura", obj.temperatura);
                com.Parameters.AddWithValue("@tipoIluminacion", obj.tipoIluminacion);

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
            throw new NotImplementedException();
        }
    }
}
