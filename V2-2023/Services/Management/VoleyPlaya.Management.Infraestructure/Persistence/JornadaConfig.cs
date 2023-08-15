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
    public class JornadaConfig : IEntityTypeConfiguration<Jornada>
    {
        public void Configure(EntityTypeBuilder<Jornada> builder)
        {
            builder.Property(c => c.UpdatedDate).IsConcurrencyToken();
        }
    }
}
