using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Datos
{
    public class RepositorioTipoIluminacionEF : IRepositorio<TipoIluminacion>
    {
        public ViveroContext Db { get; set; }

        public RepositorioTipoIluminacionEF(ViveroContext ctx)
        {
            Db = ctx;
        }

        public bool Create(TipoIluminacion obj)
        {
            bool resultado = false;
            try
            {                
                Db.TiposIluminacion.Add(obj);
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
                TipoIluminacion unTI = Db.TiposIluminacion.Find(id);
                if (unTI == null)
                    return resultado;

                Db.TiposIluminacion.Remove(unTI);
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

        public TipoIluminacion FindById(int id)
        {
            TipoIluminacion unTI = null;
            try
            {
                unTI = Db.TiposIluminacion.Find(id);
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return unTI;
        }

        public TipoIluminacion FindByName(string cadena)
        {
            return Db.TiposIluminacion.Where(x => x.iluminacion == cadena).FirstOrDefault();
        }

        public IEnumerable<TipoIluminacion> GetAll()
        {
            return Db.TiposIluminacion.ToList();
        }

        public bool Update(TipoIluminacion obj)
        {

            if (obj == null)
                return false;

            try
            {
                Db.TiposIluminacion.Update(obj);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        

        public bool YaExisteString(string cadena) //no se si lo vamos a usar, comprobar luego
        {
            if (Db.TiposIluminacion.Any(x => x.iluminacion.ToLower() == cadena.ToLower().Trim()))
                return true;
            return false;
        }
    }
}