﻿using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioTiposPlantaADO : IRepositorio<TipoPlanta>
    {
        public bool Create(TipoPlanta obj)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();


            string sql = "INSERT INTO TiposPlantas VALUES(@nombre, @descripcion); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlCommand com = new SqlCommand(sql, conexion);

            com.Parameters.AddWithValue("@nombre", obj.nombre);
            com.Parameters.AddWithValue("@descripcion", obj.descripcion);

            try
            {
                if (!obj.Validar() || YaExisteString(obj.nombre))
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
                        
            string sql = "DELETE FROM TiposPlantas WHERE Id=" + id;
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                int tuplasAfectadas = com.ExecuteNonQuery();
                ok = tuplasAfectadas == 1;
                return ok;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                Conexion.CerrarYDesecharConexion(conexion);
            }
            
        }

        public TipoPlanta FindById(int id)
        {
            TipoPlanta tipoPlanta = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TiposPlantas WHERE id = " + id + ";";
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
            List<TipoPlanta> tipoPlantas = new List<TipoPlanta>();
            SqlConnection conexion = Conexion.ObtenerConexion();
            string sql = "SELECT * FROM TiposPlantas;";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    TipoPlanta tipoPlanta = new TipoPlanta()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        nombre = reader.GetString(1),
                        descripcion = reader.GetString(2),

                    };
                    tipoPlantas.Add(tipoPlanta);
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
            return tipoPlantas;
        }

        public bool Update(TipoPlanta obj)
        {            
            bool ok = false;

            if (obj.Validar())
            {
                SqlConnection con = Conexion.ObtenerConexion();
                string sql =
                "UPDATE TiposPlantas SET nombre=@nombre, descripcion=@descripcion WHERE id = @id;";
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddWithValue("@id", obj.id);
                com.Parameters.AddWithValue("@nombre", obj.nombre.Trim());
                com.Parameters.AddWithValue("@descripcion", obj.descripcion.Trim());

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

        public TipoPlanta FindByName(string nombreTP)
        {
            TipoPlanta tipoPlanta = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM TiposPlantas WHERE nombre = '" + nombreTP + "';";
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
        public bool YaExisteString(string cadena)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT nombre FROM TiposPlantas WHERE nombre = '" + cadena + "';";
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