using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datos
{
    public class RepositorioPlantasEF : IRepositorioPlantas
    {
        IRepositorio<TipoPlanta> repoTiposPlanta { get; set; }
        IRepositorio<Ficha> repoFichas { get; set; }
        IRepositorioUsuarios repoUsuarios { get; set; }
        public ViveroContext Db { get; set; } 

        public RepositorioPlantasEF(IRepositorio<TipoPlanta> repoTipos, IRepositorio<Ficha> repoFichas, IRepositorioUsuarios repoUsuarios,ViveroContext ctx)
        {
            repoTiposPlanta = repoTipos;
            this.repoFichas = repoFichas;
            this.repoUsuarios = repoUsuarios;
            Db = ctx;
        }
        public bool Create(Planta obj)
        {
            bool resultado = false;
            try
            {
                Planta unaPlanta = FindByName(obj.nombreCientifico);
                if (unaPlanta != null)
                    return resultado;

                Db.Plantas.Add(obj);
                Db.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion
                resultado = false;
            }
            return resultado;
        }

        public bool Delete(int id)
        {
            bool resultado = false;
            try
            {
                Planta user = Db.Plantas.Find(id);
                if (user == null)
                    return resultado;

                Db.Plantas.Remove(user);
                Db.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion
                resultado = false;
            }
            return resultado;
        }

        public Planta FindById(int id)
        {
            Planta user = null;
            try
            {
                user = Db.Plantas.Find(id);
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return user;
        }

        public IEnumerable<Planta> GetAll()
        {
            List<Planta> plantas = null;
            try
            {
                plantas = Db.Plantas.ToList();
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return plantas;
        }

        public bool Update(Planta obj)
        {
            if (obj == null)
                return false;

            try
            {
                Db.Plantas.Update(obj);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }       

        public Planta FindByName(string nombreCientifico)
        {
            return Db.Plantas.Where(x => x.nombreCientifico.Equals(nombreCientifico)).SingleOrDefault();
        }
        public IEnumerable<Planta> QuerySearch(string nombre, int tipoPlanta, int alturaMaximaDesde, int alturaMaximaHasta, int ambiente)
        {
            int contador = 0;
            int contadorControl = 0;
            List<Planta> plantas = new List<Planta>();
            string query = "SELECT * FROM Plantas WHERE ";

            if (!String.IsNullOrEmpty(nombre))
            {
                query += "nombreCientifico LIKE @nombre or nombresVulgares LIKE @nombre";
                contador++;                          
            }
            if (tipoPlanta != 0)
            {
                if (contador > contadorControl)
                {
                    query += " and";
                    contadorControl++;
                }
                query += " tipo = @tipoPlanta";
                contador++;
            }
            if (alturaMaximaDesde != 0)
            {
                if (contador != contadorControl)
                {
                    query += " and";
                    contadorControl++;
                }
                query += " alturaMaxima >= @alturaMaximaDesde";
                contador++;
            }
            if (alturaMaximaHasta != 0)
            {
                if (contador != contadorControl)
                {
                    query += " and";
                    contadorControl++;
                }
                query += " alturaMaxima < @alturaMaximaHasta";
                contador++;
            }
            if (ambiente != 0)
            {
                if (contador != contadorControl)
                {
                    query += " and";
                    contadorControl++;
                }
                query += " ambiente = @ambiente";
                contador++;
            }

            if (contador == 0)
                query = "SELECT * from Plantas";
            query += ";";
            SqlConnection conexion = Conexion.ObtenerConexion();
            SqlCommand com = new SqlCommand(query, conexion);
            com.Parameters.AddWithValue("@nombre","%"+nombre+"%");
            com.Parameters.AddWithValue("@tipoPlanta",tipoPlanta);
            com.Parameters.AddWithValue("@alturaMaximaDesde", alturaMaximaDesde);
            com.Parameters.AddWithValue("@alturaMaximaHasta",alturaMaximaHasta);
            com.Parameters.AddWithValue("@ambiente",ambiente);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Planta planta = new Planta()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        tipo = repoTiposPlanta.FindById(reader.GetInt32(1)),
                        nombreCientifico = reader.GetString(2),
                        nombresVulgares = reader.GetString(3),
                        descripcion = reader.GetString(4),
                        ambiente = (Planta.Ambiente)reader.GetInt32(5),
                        alturaMaxima = reader.GetInt32(6),
                        foto = reader.GetString(7),
                        precio = reader.GetDecimal(8),
                        ficha = repoFichas.FindById(reader.GetInt32(9)),
                        ingresadoPor = repoUsuarios.FindById(reader.GetInt32(10)),
                    };
                    plantas.Add(planta);
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
            return plantas;
        }
    }
}