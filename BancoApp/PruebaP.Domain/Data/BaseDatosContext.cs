using Microsoft.EntityFrameworkCore;
using PruebaP.Domain.Data.Settings;
using PruebaP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaP.Domain.Data
{
    public class BaseDatosContext : DbContext
    {
        public BaseDatosContext(DbContextOptions<BaseDatosContext> options) : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PersonaSetting());
            modelBuilder.ApplyConfiguration(new ClienteSetting());
            modelBuilder.ApplyConfiguration(new CuentaSetting());
            modelBuilder.ApplyConfiguration(new MovimientoSetting());
        }
    }
}
