using Microsoft.EntityFrameworkCore;
using VoleyPlaya.Organization.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoleyPlaya.Organization.Infraestructure.Persistence
{
    public class TemporadaConfig : IEntityTypeConfiguration<Temporada>
    {
        public void Configure(EntityTypeBuilder<Temporada> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(c => c.Nombre).IsUnique();
        }
    }
}
