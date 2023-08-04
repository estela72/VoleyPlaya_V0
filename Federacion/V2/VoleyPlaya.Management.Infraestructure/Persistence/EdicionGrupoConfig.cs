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
    public class EdicionGrupoConfig : IEntityTypeConfiguration<EdicionGrupo>
    {
        public void Configure(EntityTypeBuilder<EdicionGrupo> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
            builder.HasIndex(e => new { e.EdicionId, e.Nombre }).IsUnique();
            builder.HasOne(d => d.Edicion).WithMany(p => p.EdicionGrupos)
                .HasForeignKey(d => d.EdicionId);
        }
    }
}
