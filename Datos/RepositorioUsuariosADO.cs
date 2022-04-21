using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Datos
{
    public class RepositorioUsuariosADO : IRepositorioUsuarios
    {
        public bool Create(Usuario obj)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "INSERT INTO Usuarios VALUES(@email, @contrasenia, @activo); " +
            "SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlCommand com = new SqlCommand(sql, conexion);

            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@contrasenia", obj.contrasenia);
            com.Parameters.AddWithValue("@activo", obj.activo);

           
            try
            {
                if (!obj.Validar())
                    return false;

                Conexion.AbrirConexion(conexion);
                int id = (int)com.ExecuteScalar();
                id = obj.id;
                return true;
            }
            catch(Exception ex)
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
            string sql = "DELETE FROM Usuarios WHERE Id=" + id;
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

            string sql = "SELECT * FROM Usuarios;";
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

        public bool ValidarMail(string mail)
        {
            throw new NotImplementedException();
        }
    }
}
