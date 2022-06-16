using Dominio.Entidades;
using Dominio.Interfaces;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Datos
{
    public class RepositorioUsuariosEF : IRepositorioUsuarios
    { 
        public ViveroContext Db { get; set; }

        public RepositorioUsuariosEF(ViveroContext ctx)
        {
            Db = ctx;
           
        }

        public bool Create(Usuario obj)
        {
            bool resultado = false;            
            try
            {
                Usuario unUser = FindByName(obj.Email);
                if (unUser != null)
                    return resultado;

                Db.Usuarios.Add(obj);
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
                Usuario user = Db.Usuarios.Find(id);
                if (user == null)
                    return resultado;

                Db.Usuarios.Remove(user);
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

        public Usuario FindById(int id)
        {
            Usuario user = null;
            try
            {
                user = Db.Usuarios.Find(id);                
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return user;
        }
        
        public IEnumerable<Usuario> GetAll()
        {
            IQueryable<Usuario> users = null;
            try
            {
                users = Db.Usuarios;
            }
            catch (Exception ex)
            {
                //log de error
                //notificacion               
            }
            return users;
        }

        public bool Update(Usuario obj)
        {
            if (obj == null)
                return false;

            try
            {
                Db.Usuarios.Update(obj);
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }
               
        public Usuario FindByName(string mail) //Por Email
        {
            return Db.Usuarios.Where(x => x.Email.Equals(mail)).SingleOrDefault();
        }

        public bool YaExisteString(string cadena)
        {
            throw new NotImplementedException();
        }
    }
}
