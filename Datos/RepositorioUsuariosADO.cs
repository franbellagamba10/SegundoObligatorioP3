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
                if (!Validar(obj))
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

        public bool Validar(Usuario obj)
        {
            int contadorLetras = 0;
            bool tieneMayusculas = false;
            bool tieneMinusculas = false;
            bool tieneNumeros = false;

            if (obj.contrasenia.Length < 6)
                return false;            

            while ((!tieneMayusculas || !tieneMinusculas || !tieneNumeros) && !(contadorLetras == obj.contrasenia.Length))
            {
                char letra = Convert.ToChar(obj.contrasenia.Substring(contadorLetras,1));                
                
                if (Char.IsUpper(letra))
                {
                    tieneMayusculas = true;
                }
                if (Char.IsLower(letra))
                {
                    tieneMinusculas = true;
                }
                if (Char.IsDigit(letra))
                {
                    tieneNumeros = true;
                }
                contadorLetras++;
            }
            if (tieneMayusculas && tieneMinusculas && tieneNumeros)
                return true;           
            return false;           
        }

        //un comentario nuevo
    }
}
