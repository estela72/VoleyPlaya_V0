using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VoleyPlaya.Organization.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Organization.Infraestructure.Persistence
{
    public class EquipoConfig : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(c => c.Nombre).IsUnique();
        }
    }
}
