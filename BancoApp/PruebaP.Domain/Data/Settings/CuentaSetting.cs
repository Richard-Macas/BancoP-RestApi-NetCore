using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaP.Domain.Data.Settings
{
    public class CuentaSetting : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> entity)
        {
            entity.ToTable("Cuenta");

            entity.HasIndex(e => e.IdCliente, "ClienteCuenta_FK");

            entity.HasIndex(e => e.NumeroCuenta, "UQ__Cuenta__E039507B9A0239F1")
                    .IsUnique();

            entity.Property(e => e.NumeroCuenta)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            entity.Property(e => e.SaldoInicial).HasColumnType("money").IsRequired();

            entity.Property(e => e.TipoCuenta)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.Cuentas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_CUENTA_CLIENTE_C_PERSONA");
        }
    }
}
