using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Dominio.Entidades.Planta;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class RepositorioPlantasEF : IRepositorioPlantas
    {
        IRepositorio<TipoPlanta> repoTiposPlanta { get; set; }
        IRepositorio<Ficha> repoFichas { get; set; }
        IRepositorioUsuarios repoUsuarios { get; set; }
        public ViveroContext Db { get; set; } 

        public RepositorioPlantasEF(IRepositorio<TipoPlanta> repoTipos, IRepositorio<Ficha> repoFichas, IRepositorioUsuarios repoUsuarios,ViveroContext ctx)
        {
            repoTiposPlanta = repoTipos;
            this.repoFichas = repoFichas;
            this.repoUsuarios = repoUsuarios;
            Db = ctx;
        }
        public bool Create(Planta obj)
        {
            bool resultado = false;
            try
            {
                Planta unaPlanta = FindByName(obj.nombreCientifico);
                if (unaPlanta != null)
                    return resultado;

                Db.Plantas.Add(obj);
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
                Planta user = Db.Plantas.Find(id);
                if (user == null)
                    return resultado;

                Db.Plantas.Remove(user);
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

        public Planta FindById(int id)
        {
            Planta plantaBD = null;
            try
            {
               

                //plantaBD = Db.Plantas.Include(x=>x.Ficha).ThenInclude(f=>f.tipoIluminacion)
                //                  .Include(x=>x.Ficha).ThenInclude(f=>f.frecuenciaRiego)
                //                  .Include(x=>x.TipoPlanta)
                //                  .Where(x=>x.id == id).SingleOrDefault();
                
                plantaBD = Db.Plantas.Include(x=>x.Ficha.tipoIluminacion).Include(x => x.Ficha.frecuenciaRiego).Include(x => x.TipoPlanta).Include(x=>x.Usuario).Where(x => x.id == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return plantaBD;
        }

        public IEnumerable<Planta> GetAll()
        {
            List<Planta> plantas = null;
            try
            {
                plantas = Db.Plantas.Include(x => x.Ficha.tipoIluminacion).Include(x => x.Ficha.frecuenciaRiego).Include(x => x.TipoPlanta).Include(x => x.Usuario).ToList();
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return plantas;
        }

        public bool Update(Planta obj)
        {
            if (obj == null)
                return false;

            try
            {
                Db.Plantas.Update(obj);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }       

        public Planta FindByName(string nombreCientifico)
        {
            return Db.Plantas.Include(x => x.Ficha.tipoIluminacion).Include(x => x.Ficha.frecuenciaRiego).Include(x => x.TipoPlanta).Include(x => x.Usuario).Where(x => x.nombreCientifico.Equals(nombreCientifico)).SingleOrDefault();
        }
        

        public IEnumerable<Planta> QuerySearch(string nombre, TipoPlanta tipoPlanta, int alturaMaximaDesde, int alturaMaximaHasta, int ambiente)
        {
            var plantas = GetAll();
            
            try
            {                
                if (!string.IsNullOrWhiteSpace(nombre))
                    plantas = plantas.Where(x => x.nombresVulgares.Contains(nombre) || x.nombreCientifico.Contains(nombre));

                if (tipoPlanta != null)
                    plantas = plantas.Select(x => x).Where(x => x.TipoPlanta == tipoPlanta);

                if (alturaMaximaDesde > 0)
                    plantas = plantas.Where(x => x.alturaMaxima >= alturaMaximaDesde);

                if (alturaMaximaHasta > 0)
                    plantas = plantas.Where(x => x.alturaMaxima < alturaMaximaHasta);

                if (ambiente != 0)
                    plantas = plantas.Where(x => x.ambiente == (Ambiente)ambiente);
            }
            catch
            {
                return null;
            }
            return plantas;
        }


    }
}