﻿using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class ViveroContext : DbContext
    {
        #region DBSets
        
        public DbSet<Item> Items { get; set; }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasKey(a => new { a.idPlanta, a.idCompra });
            modelBuilder.Entity<TipoIluminacion>().HasMany(ti => ti.Fichas).WithOne(f=>f.tipoIluminacion);
            modelBuilder.Entity<FrecuenciaRiego>().HasMany(ti => ti.Fichas).WithOne(f => f.frecuenciaRiego);
            
            /*
             * modelBuilder.Entity<Company>()
             .HasMany(c => c.Employees)
                 .WithOne(e => e.Company);
             */


            base.OnModelCreating(modelBuilder);
        
        }
    }    

}

