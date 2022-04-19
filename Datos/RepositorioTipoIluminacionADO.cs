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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoIluminacion FindById(int id)
        {
            TipoIluminacion tipoIluminacion = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoIluminacion WHERE id = " + id + ";";
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

        public IEnumerable<TipoIluminacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoIluminacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
