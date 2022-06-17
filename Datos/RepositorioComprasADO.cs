using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datos
{
    public class RepositorioComprasADO : IRepositorio<Compra>, IRepositorioCompras
    {
        IRepositorioPlantas repoPlantas { get; set; }

        public RepositorioComprasADO(IRepositorioPlantas repoPlantas)
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
            return true;
        }

        public Item FindByIds(int idPlanta, int idCompra) //CAMBIAR !!
        {
            Item miItem = new Item { CompraId = 1, PlantaId = 1, cantidad = 1, precioUnidad = 200 };
            return miItem;
        
        }

        public IEnumerable<Item> FindAllById(int idCompra)
        {
            List<Item> detallesCompra = null;
           
            return detallesCompra;
        }

        public IEnumerable<Item> GetAllItems() 
        {                                   
            List<Item> items = new List<Item>();
            SqlConnection conexion = Conexion.ObtenerConexion();

            
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

        public Compra FindByName(string cadena)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}