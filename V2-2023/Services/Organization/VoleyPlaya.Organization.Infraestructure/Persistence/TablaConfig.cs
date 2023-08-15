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
    public class TablaConfig : IEntityTypeConfiguration<Tabla>
    {
        public void Configure(EntityTypeBuilder<Tabla> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(c => c.Nombre).IsUnique();
        }
    }
}
