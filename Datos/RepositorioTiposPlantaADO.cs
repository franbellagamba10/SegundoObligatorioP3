using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioTiposPlantaADO : IRepositorio<TipoPlanta>
    {
        public bool Create(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }               

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TipoPlanta FindById(int id)
        {
            TipoPlanta tipoPlanta = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TipoPlanta WHERE id = " + id + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    tipoPlanta = new TipoPlanta()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        nombre = reader.GetString(1),
                        descripcion = reader.GetString(2),                        
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
            return tipoPlanta;
        }

        public IEnumerable<TipoPlanta> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(TipoPlanta obj)
        {
            throw new NotImplementedException();
        }
    }
}
