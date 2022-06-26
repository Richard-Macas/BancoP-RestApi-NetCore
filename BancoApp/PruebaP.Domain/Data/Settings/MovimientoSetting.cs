using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaP.Domain.Data.Settings
{
    public class MovimientoSetting : IEntityTypeConfiguration<Movimiento>
    {
        public void Configure(EntityTypeBuilder<Movimiento> entity)
        {
            entity.ToTable("Movimiento");

            entity.HasIndex(e => e.IdCuenta, "Cuenta_Movimiento_FK");

            entity.Property(e => e.Fecha).IsRequired().HasColumnType("datetime");

            entity.Property(e => e.Saldo).IsRequired().HasColumnType("money");

            entity.Property(e => e.TipoMovimiento)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Valor).IsRequired().HasColumnType("money");

            entity.HasOne(d => d.IdCuentaNavigation)
                .WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.IdCuenta)
                .HasConstraintName("FK_MOVIMIEN_CUENTA_MO_CUENTA");
        }
    }
}
