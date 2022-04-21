using Dominio.Entidades;
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
            
            
            string sql = "INSERT INTO TipoPlanta VALUES(@nombre, @descripcion); " +
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

        public bool YaExisteString(string cadena)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT nombre FROM TipoPlanta WHERE nombre = '" + cadena + "';";
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
