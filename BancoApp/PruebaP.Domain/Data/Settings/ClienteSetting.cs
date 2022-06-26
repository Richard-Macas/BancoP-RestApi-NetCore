using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaP.Domain.Data.Settings
{
    public class ClienteSetting : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("Persona");

            entity.Property(e => e.ClienteId)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Contrasena)
                .IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.Direccion)
                .HasMaxLength(150).IsRequired()
                .IsUnicode(false);

            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasIndex(e => e.Identificacion, "UQ__Persona__D6F931E5E43C8645")
                    .IsUnique();

            entity.Property(e => e.Identificacion)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(true);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Estado).IsRequired();

            // Se agrega la herencia de persona
            entity.HasBaseType<Persona>();
        }
    }
}
