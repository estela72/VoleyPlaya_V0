using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Infraestructure.Persistence
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c=>c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(c => c.Nombre).IsUnique();
        }
    }
}
