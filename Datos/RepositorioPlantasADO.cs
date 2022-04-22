﻿using Dominio.Entidades;
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
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "INSERT INTO Planta VALUES(@tipo, @nombreCientifico, @nombresVulgares, @descripcion," +
                " @ambiente, @alturaMaxima, @foto, @precio, @ingresadoPor); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlCommand com = new SqlCommand(sql, conexion);

            com.Parameters.AddWithValue("@tipo", obj.tipo.id);
            com.Parameters.AddWithValue("@nombreCientifico", obj.nombreCientifico.Trim());
            com.Parameters.AddWithValue("@nombresVulgares", obj.nombresVulgares.Trim());
            com.Parameters.AddWithValue("@descripcion", obj.descripcion.Trim());
            com.Parameters.AddWithValue("@ambiente", obj.ambiente);
            com.Parameters.AddWithValue("@alturaMaxima", obj.alturaMaxima);
            com.Parameters.AddWithValue("@foto", obj.foto.Trim());
            com.Parameters.AddWithValue("@precio", obj.precio);
            com.Parameters.AddWithValue("@ingresadoPor", obj.ingresadoPor.id);// Session["usuarioId"] ?
            try
            {
                if (!obj.Validar() || YaExisteString(obj.nombreCientifico))
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
            string sql = "DELETE FROM Planta WHERE Id=" + id;
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
                        ambiente = (Planta.Ambiente)reader.GetInt32(5),
                        alturaMaxima = reader.GetInt32(6),
                        foto = reader.GetString(7),
                        precio = Convert.ToDouble(reader.GetDecimal(8)),
                        ingresadoPor = repoUsuarios.FindById(reader.GetInt32(9)),
                        ficha = repoFichas.FindById(reader.GetInt32(10))                        
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

        public bool YaExisteString(string nombreCientifico)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT nombreCientifico FROM Planta WHERE nombreCientifico = '" + nombreCientifico + "';";
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
