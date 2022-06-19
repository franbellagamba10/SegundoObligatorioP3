using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades.EntidadesAuxiliares;

namespace Datos
{
    public class RepositorioComprasEF : IRepositorioCompras
    {       
        ViveroContext Db { get; set; }
        public RepositorioComprasEF(ViveroContext ctx)
        {
            Db = ctx;
        }

        public bool Create(Compra obj)
        {
            bool resultado = false; //agregar validacion de COMPRA

            try
            {
                Db.Add(obj);
                Db.SaveChanges();
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
                compraBD = Db.Compras.Include(c=>c.Items).Where(c => c.id == id).SingleOrDefault();
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
                var test = Db.Plantas.ToList(); //<<----- BORRAR!!
                comprasBD = Db.Compras.Include(c=>c.Items).ThenInclude(i=>i.Planta).ThenInclude(p=>p.TipoPlanta).ToList();                
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

        public VariablesGlobales ObtenerVariablesGlobales()
        {
            var VG = Db.VariablesGlobales.FirstOrDefault();
            return VG;
        }

        public decimal CalcularPrecioTotal(Compra compra)
        {
            throw new NotImplementedException();
        }
    }
}
