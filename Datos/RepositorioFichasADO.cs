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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(Ficha obj)
        {
            throw new NotImplementedException();
        }

        public bool YaExisteString(string cadena)
        {
            throw new NotImplementedException();
        }
    }
}
