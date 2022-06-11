using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datos
{
    public class RepositorioTiposPlantaEF : IRepositorio<TipoPlanta>
    {
        public ViveroContext Db { get; set; }

        public RepositorioTiposPlantaEF(ViveroContext ctx)
        {
            Db = ctx;
        }
        public bool Create(TipoPlanta obj)
        {
            bool resultado = false;
            try
            {
                Db.TiposPlanta.Add(obj);
                Db.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion
                resultado = false;
            }
            return resultado;
        }

        public bool Delete(int id)
        {
            bool resultado = false;
            try
            {
                TipoPlanta unTP = Db.TiposPlanta.Find(id);
                if (unTP == null)
                    return resultado;

                Db.TiposPlanta.Remove(unTP);
                Db.SaveChanges();
                resultado = true;
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion
                resultado = false;
            }
            return resultado;

        }

        public bool Update(TipoPlanta obj)
        {
            if (obj == null)
                return false;

            try
            {
                Db.TiposPlanta.Update(obj);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TipoPlanta FindById(int id)
        {
            TipoPlanta unTP = null;
            try
            {
                unTP = Db.TiposPlanta.Find(id);
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return unTP;
        }

        public IEnumerable<TipoPlanta> GetAll()
        {
            return Db.TiposPlanta.ToList();
        }

        
        public TipoPlanta FindByName(string nombreTP)
        {
            return Db.TiposPlanta.Where(x => x.nombre.Equals(nombreTP)).SingleOrDefault();                                
        }        
    }
}