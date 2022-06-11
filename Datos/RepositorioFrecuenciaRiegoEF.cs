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
    public class RepositorioFrecuenciaRiegoEF : IRepositorio<FrecuenciaRiego>
    {
        public ViveroContext Db { get; set; }

        public RepositorioFrecuenciaRiegoEF(ViveroContext ctx)
        {
            Db = ctx;

        }
        public bool Create(FrecuenciaRiego obj)
        {
            bool resultado = false;
            try
            {
                Db.FrecuenciasRiego.Add(obj);
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
                FrecuenciaRiego unTI = Db.FrecuenciasRiego.Find(id);
                if (unTI == null)
                    return resultado;

                Db.FrecuenciasRiego.Remove(unTI);
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

        public FrecuenciaRiego FindById(int id)
        {
            FrecuenciaRiego unTI = null;
            try
            {
                unTI = Db.FrecuenciasRiego.Find(id);
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return unTI;
        }

        public FrecuenciaRiego FindByName(string cadena)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FrecuenciaRiego> GetAll()
        {
            return Db.FrecuenciasRiego.ToList();
        }

        public bool Update(FrecuenciaRiego obj)
        {
            if (obj == null)
                return false;

            try
            {
                Db.FrecuenciasRiego.Update(obj);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool YaExisteString(string cadena)
        {
            throw new NotImplementedException();
        }
    }
}