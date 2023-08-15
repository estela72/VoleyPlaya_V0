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
    public class PartidoConfig : IEntityTypeConfiguration<Partido>
    {
        public void Configure(EntityTypeBuilder<Partido> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(e => e.Label).IsUnique();
            builder.HasIndex(e => e.EquipoLocalId);
            builder.HasIndex(e => e.EquipoVisitanteId);
            builder.HasIndex(e => e.EdicionGrupoId);
            builder.Property(e => e.ConResultado).IsRequired().HasDefaultValueSql("(CONVERT([bit],(0)))");
            builder.Property(e => e.Ronda).HasDefaultValueSql("(N'')");
            builder.Property(e => e.UserResultado).HasDefaultValueSql("(N'')");
            builder.Property(e => e.UserValidador).HasDefaultValueSql("(N'')");
            builder.Property(e => e.Validado).IsRequired().HasDefaultValueSql("(CONVERT([bit],(0)))");
        }
    }
}
