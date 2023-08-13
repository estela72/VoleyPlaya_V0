using System;
using System.Collections.Generic;
using System.Security.Principal;

using Common.Infraestructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Infraestructure.Persistence;

public partial class VoleyPlayaManagementContext : GenericDbContext
{
    public VoleyPlayaManagementContext(DbContextOptions<VoleyPlayaManagementContext> options/*,IIdentity identity*/)
        : base(options/*,identity*/)
    {
    }
    public virtual DbSet<EdicionGrupo> EdicionGrupos { get; set; }

    public virtual DbSet<Edicion> Ediciones { get; set; }

    public virtual DbSet<Jornada> Jornada { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EdicionConfig());
        modelBuilder.ApplyConfiguration(new EdicionGrupoConfig());
        modelBuilder.ApplyConfiguration(new JornadaConfig());
        modelBuilder.ApplyConfiguration(new PartidoConfig());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
