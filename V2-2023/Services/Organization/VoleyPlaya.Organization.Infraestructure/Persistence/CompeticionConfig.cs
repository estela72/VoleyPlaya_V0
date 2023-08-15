using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Infraestructure.Persistence
{
    public class CompeticionConfig : IEntityTypeConfiguration<Competicion>
    {
        public void Configure(EntityTypeBuilder<Competicion> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(c => c.Nombre).IsUnique();
        }
    }
}
