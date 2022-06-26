using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaP.Domain.Entities;
using PruebaP.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaP.Domain.Data.Settings
{
    public class PersonaSetting : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> entity)
        {
            entity.HasDiscriminator<TipoPersona>("TipoPersona")
            .HasValue<Persona>(TipoPersona.Persona)
            .HasValue<Cliente>(TipoPersona.Cliente);

        }
    }
}
