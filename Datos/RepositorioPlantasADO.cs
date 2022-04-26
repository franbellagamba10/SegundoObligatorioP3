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
        IRepositorio<TipoPlanta> repoTiposPlanta { get; set; }
        IRepositorio<Ficha> repoFichas { get; set; }
        IRepositorioUsuarios repoUsuarios { get; set; }
        public RepositorioPlantasADO(IRepositorio<TipoPlanta> repoTipos, IRepositorio<Ficha> repoFichas, IRepositorioUsuarios repoUsuarios)
        {
            repoTiposPlanta = repoTipos;
            this.repoFichas = repoFichas;
            this.repoUsuarios = repoUsuarios;
        }
        public bool Create(Planta obj)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "INSERT INTO Plantas VALUES(@tipo, @nombreCientifico, @nombresVulgares, @descripcion, @ambiente, @alturaMaxima, @foto, @precio,@ficha, @ingresadoPor); " +
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
            com.Parameters.AddWithValue("@ficha",obj.ficha.id);
            com.Parameters.AddWithValue("@ingresadoPor", obj.ingresadoPor.id);// Session["usuarioId"] ?
            try
            {
                if (!obj.Validar() || YaExisteString(obj.nombreCientifico))
                    return false;

                Conexion.AbrirConexion(conexion);
                int id = (int)com.ExecuteScalar();
                //id = obj.id;
                return true;
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

        public bool Delete(int id)
        {
            bool ok = false;
            SqlConnection conexion = Conexion.ObtenerConexion();
            //PUEDO NO USAR SQLPARAMETER PORQUE EL ÚNICO DATO ES UN ENTERO
            string sql = "DELETE FROM Plantas WHERE Id=" + id;
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                int tuplasAfectadas = com.ExecuteNonQuery();
                ok = tuplasAfectadas == 1;
                return ok;
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
                        precio = reader.GetDecimal(8),                        
                        ficha = repoFichas.FindById(reader.GetInt32(9)),
                        ingresadoPor = repoUsuarios.FindById(reader.GetInt32(10)),
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
            List<Planta> plantas = new List<Planta>();
            SqlConnection conexion = Conexion.ObtenerConexion();
            string sql = "SELECT * FROM Plantas;";
            SqlCommand com = new SqlCommand(sql, conexion);
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

        public bool Update(Planta obj)
        {
            bool ok = false;
            SqlConnection con = Conexion.ObtenerConexion();
            if (obj.Validar())
            {
                string sql =
                "UPDATE Plantas SET tipo=@tipo, nombreCientifico=@nombreCientifico, nombresVulgares=@nombresVulgares, descripcion=@descripcion,ambiente=@ambiente, alturaMaxima=@alturaMaxima,foto=@foto,precio=@precio,ingresadoPor=@ingresadoPor WHERE id=@id";
                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.AddWithValue("@id", obj.id);
                com.Parameters.AddWithValue("@tipo", obj.tipo.id);
                com.Parameters.AddWithValue("@nombreCientifico", obj.nombreCientifico.Trim());
                com.Parameters.AddWithValue("@nombresVulgares", obj.nombresVulgares.Trim());
                com.Parameters.AddWithValue("@descripcion", obj.descripcion.Trim());
                com.Parameters.AddWithValue("@ambiente", obj.ambiente);
                com.Parameters.AddWithValue("@alturaMaxima", obj.alturaMaxima);
                com.Parameters.AddWithValue("@foto", obj.foto.Trim());
                com.Parameters.AddWithValue("@precio", obj.precio);
                com.Parameters.AddWithValue("@ingresadoPor", obj.ingresadoPor.id);

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

        public bool YaExisteString(string nombreCientifico)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();
            string sql = "SELECT nombreCientifico FROM Plantas WHERE nombreCientifico = '" + nombreCientifico + "';";
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
       

        public Planta FindByName(string nombreCientifico)
        {
            Planta planta = null;
            SqlConnection con = Conexion.ObtenerConexion();
            string sql = "SELECT * FROM Plantas WHERE nombreCientifico = @nombreCientifico;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@nombreCientifico", nombreCientifico);
            try
            {
                Conexion.AbrirConexion(con);
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
                        precio = reader.GetDecimal(8),
                        ficha = repoFichas.FindById(reader.GetInt32(9)),
                        ingresadoPor = repoUsuarios.FindById(reader.GetInt32(10)),
                    };
                }
                return planta;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                Conexion.CerrarConexion(con);
            }

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