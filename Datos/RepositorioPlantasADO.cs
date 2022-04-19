using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioPlantasADO : IRepositorioPlantas
    {
        RepositorioTiposPlantaADO repoTiposPlanta { get; set; }
        RepositorioFichasADO repoFichas { get; set; }
        RepositorioUsuariosADO repoUsuarios { get; set; }

        public RepositorioPlantasADO(RepositorioTiposPlantaADO repoTipos, RepositorioFichasADO repoFichas, RepositorioUsuariosADO repoUsuarios)
        {
            repoTiposPlanta = repoTipos;
            this.repoFichas = repoFichas;
            this.repoUsuarios = repoUsuarios;
        }
        public bool Create(Planta obj)
        {
            throw new NotImplementedException();
        }               

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Planta FindById(int id)
        {
            Planta planta = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Plantas WHERE id = " + id + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    planta = new Planta()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        tipo = repoTiposPlanta.FindById(reader.GetInt32(1)),
                        nombreCientifico = reader.GetString(2),
                        nombresVulgares = reader.GetString(3),
                        descripcion = reader.GetString(4),
                        ambiente = reader.GetString(5),
                        alturaMaxima = reader.GetInt32(6),
                        foto = reader.GetString(7),
                        precio = Convert.ToDouble(reader.GetDecimal(8)),
                        ingresadoPor = repoUsuarios.FindById(reader.GetInt32(9)),
                        ficha = repoFichas.FindById(reader.GetInt32(10))
                    };
                }

                DB.Plantas.Where(x => x.tipo == "unTipoPlanta").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }
            return planta;
        }

        public IEnumerable<Planta> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Planta obj)
        {
            throw new NotImplementedException();
        }
        
        public bool Validar(Planta obj)
        {
            throw new NotImplementedException();
        }
        
    }
}
