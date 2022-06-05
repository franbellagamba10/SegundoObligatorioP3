using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class ViveroContext : DbContext
    {
        #region DBSets
        //public DbSet<Item> Items { get; set; }  no se si vamos a almacenar Items en la BD
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraImportacion> ComprasImportacion { get; set; }
        public DbSet<CompraPlaza> ComprasPlaza { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<FrecuenciaRiego> FrecuenciasRiego { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<TipoIluminacion> TiposIluminacion { get; set; }
        public DbSet<TipoPlanta> TiposPlanta { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        public ViveroContext(DbContextOptions<ViveroContext> opciones) : base(opciones)
        {
            
        }
    }
}
