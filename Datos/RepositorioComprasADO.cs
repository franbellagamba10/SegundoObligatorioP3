using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class RepositorioComprasADO : IRepositorio<Compra>, IRepositorioCompras
    {        
        RepositorioPlantasADO repoPlantas { get; set; }
        
        public RepositorioComprasADO(RepositorioPlantasADO repoPlantas)
        {            
            this.repoPlantas = repoPlantas;
        }

        public bool Create(Compra obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Compra FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Compra> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Compra obj)
        {
            throw new NotImplementedException();
        }
        #region Items
        public bool Create(Item obj)
        {
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "INSERT INTO Items VALUES (@compra, @planta, @cantidad, @precioPlanta);";
            SqlCommand com = new SqlCommand(sql, conexion);

            com.Parameters.AddWithValue("@compra", obj.compra);
            com.Parameters.AddWithValue("@planta", obj.planta);
            com.Parameters.AddWithValue("@cantidad", obj.cantidad);
            com.Parameters.AddWithValue("@precioPlanta", obj.precioUnidad);

            try
            {
                if (!Validar(obj))
                    return false;

                Conexion.AbrirConexion(conexion);
                com.ExecuteNonQuery();   //porque no espero un valor significante si uso ExecutoScalar(), Item no tiene Id propio
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

        public Item FindByIds(int idPlanta, int idCompra)
        {
            Item item = null;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Item WHERE planta = " + idPlanta + " and compra = " + idCompra + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    item = new Item()
                    {
                        compra = FindById(idCompra),
                        planta = repoPlantas.FindById(idPlanta),
                        cantidad = reader.GetInt32(2),
                        precioUnidad = reader.GetDecimal(3)
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
            return item;
        }

        public IEnumerable<Item> FindAllById(int idCompra)
        {
            List<Item> detallesCompra = null;
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Items WHERE compra = " + idCompra + ";";
            SqlCommand com = new SqlCommand(sql, conexion);
            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Item item = new Item()
                    {
                        compra = FindById(reader.GetInt32(0)),
                        planta = repoPlantas.FindById(reader.GetInt32(1)),
                        cantidad = reader.GetInt32(2),
                        precioUnidad = reader.GetDecimal(3)
                    };
                    detallesCompra.Add(item);
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
            return detallesCompra;
        }

        public IEnumerable<Item> GetAllItems() //Sirve de algo implementar esto? En algun momento vamos a querer traer todos los detalles? si quisiera el total ganado lo haria a traves de obtener todas las compras y conseguir el total de c/u
        {                                   //pero ^ podria ser mas costoso que simplemente traerme todo y calcularlo asi. El foreach del caso ^ seria costoso, es mas facil traer todo, pero igualmente no se si necesitamos esto para algo
            List<Item> items = new List<Item>();
            SqlConnection conexion = Conexion.ObtenerConexion();

            string sql = "SELECT * FROM Items;";
            SqlCommand com = new SqlCommand(sql, conexion);

            try
            {
                Conexion.AbrirConexion(conexion);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Item item = new Item()
                    {
                        compra = FindById(reader.GetInt32(0)),
                        planta = repoPlantas.FindById(reader.GetInt32(1)),
                        cantidad = reader.GetInt32(2),
                        precioUnidad = reader.GetDecimal(3)
                    };
                    items.Add(item);
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
            return items;
        }

        public bool Validar(Item obj)
        {
            throw new NotImplementedException();
        }

        public bool YaExisteString(string cadena)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
