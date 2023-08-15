using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Infraestructure.Persistence
{
    public class EdicionConfig : IEntityTypeConfiguration<Edicion>
    {
        public void Configure(EntityTypeBuilder<Edicion> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(c => c.Nombre).IsUnique();
            builder.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.CategoriaId, e.Genero, e.Prueba }).IsUnique();
            builder.HasIndex(e => e.CategoriaId);
            builder.HasIndex(e => e.CompeticionId);
        }
    }
}
