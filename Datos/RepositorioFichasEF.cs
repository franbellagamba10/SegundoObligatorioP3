using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class RepositorioFichasEF : IRepositorio<Ficha>
    {
        IRepositorio<FrecuenciaRiego> repoFrecuenciaRiego; //get set?
        IRepositorio<TipoIluminacion> repoTipoIluminacion;
        public ViveroContext Db { get; set; }

        public RepositorioFichasEF(IRepositorio<FrecuenciaRiego> repoFrecuenciaRiego, IRepositorio<TipoIluminacion> repoTipoIluminacion, ViveroContext ctx)
        {
            this.repoFrecuenciaRiego = repoFrecuenciaRiego;
            this.repoTipoIluminacion = repoTipoIluminacion;
            Db = ctx;
        }
        public bool Create(Ficha obj)
        {
            bool resultado = false;
            try
            {
                Db.Fichas.Add(obj);
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
                Ficha unaFicha = Db.Fichas.Find(id);
                if (unaFicha == null)
                    return resultado;

                Db.Fichas.Remove(unaFicha);
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

        public Ficha FindById(int id)
        {
            Ficha unaFicha = null;
            try
            {
                unaFicha = Db.Fichas.Include(f=>f.frecuenciaRiego)
                                    .Include(f=>f.tipoIluminacion)
                                    .Where(f=>f.id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return unaFicha;
        }

        //El objeto simple no tiene un nombre que podamos buscar,
        //pero podriamos hacer algo con el ToString()
        //y buscar el prooducto de ese metodo
        public Ficha FindByName(string cadena) 
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ficha> GetAll()
        {
            var fichas = Db.Fichas.Select(x=>x).Include(f => f.frecuenciaRiego).Include(f => f.tipoIluminacion).ToList();
            return fichas;
        }

        public bool Update(Ficha obj)
        {
            if (obj == null)
                return false;

            try
            {
                Db.Fichas.Update(obj);
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