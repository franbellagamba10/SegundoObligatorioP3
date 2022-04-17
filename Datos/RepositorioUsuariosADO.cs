using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioUsuariosADO : IRepositorioUsuarios
    {
        public bool Create(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            Usuario usuario = null; ;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Usuarios WHERE id = "+ id+";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        email = reader.GetString(1),
                        contrasenia = reader.GetString(2),
                        activo = reader.GetBoolean(3)
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
            return usuario;
        }

        public IEnumerable<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM USUARIOS;";
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Usuario user = new Usuario()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        email = reader.GetString(1),
                        contrasenia = reader.GetString(2),
                        activo = reader.GetBoolean(3)
                    };
                    usuarios.Add(user);
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
            return usuarios;
        }

        public bool Update(Usuario obj)
        {
            throw new NotImplementedException();
        }   

        public bool Validar(Usuario obj)
        {


            return true;
        }
    }
}
