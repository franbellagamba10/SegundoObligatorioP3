using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Datos.Utilitarios;

namespace Datos
{
    public class RepositorioComprasEF : IRepositorioCompras
    {
        IRepositorioPlantas repoPlantas { get; set; }
        ViveroContext db { get; set; }
        VariablesGlobales vg { get; set; }
        public RepositorioComprasEF(IRepositorioPlantas repoPlantas, ViveroContext ctx,VariablesGlobales vg)
        {
            this.repoPlantas = repoPlantas;
            db = ctx;
            this.vg = vg;
        }

        public bool Create(Compra obj)
        {
            bool resultado = false; //agregar validacion de COMPRA

            try
            {
                db.Add(obj);
                db.SaveChanges();
                resultado = true;
            }
            catch
            {
                return resultado;
            }
            return resultado;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Compra FindById(int id)
        {
            Compra compraBD = null;
            try
            {
                compraBD = db.Compras.Include(c=>c.Items).Where(c => c.id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return compraBD;
        }

        public IEnumerable<Compra> GetAll()
        {
            List<Compra> comprasBD = null;
            try
            {                
                comprasBD = db.Compras.Include(c=>c.Items).ThenInclude(i=>i.Planta).ThenInclude(p=>p.TipoPlanta).ToList();                
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion 
            }
            return comprasBD;
        }

        public bool Update(Compra obj)
        {
            throw new NotImplementedException();
        }

        public Compra FindByName(string cadena)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Compra> FindByTipoPlanta(int idTP)
        {
            List<Compra> comprasDB = null;
            try
            {
                comprasDB = GetAll().Where(c => c.Items
                                        .Any(i => i.Planta.TipoPlantaId == idTP)).ToList();
            }
            catch (Exception)
            {

                return null;
            }
            return comprasDB;
        }

        public decimal CalcularPrecioTotal(Compra compra)
        {
            throw new NotImplementedException();
        }
    }
}