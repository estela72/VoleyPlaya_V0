using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using GenericLib;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Infraestructure.Persistence;

public partial class VoleyPlayaOrganizationContext : GenericDbContext
{
    public VoleyPlayaOrganizationContext(DbContextOptions<VoleyPlayaOrganizationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Competicion> Competiciones { get; set; }
    public virtual DbSet<Equipo> Equipos { get; set; }
    public virtual DbSet<Tabla> Tablas { get; set; }

    public virtual DbSet<Temporada> Temporadas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaConfig());
        modelBuilder.ApplyConfiguration(new CompeticionConfig());
        modelBuilder.ApplyConfiguration(new EquipoConfig());
        modelBuilder.ApplyConfiguration(new TablaConfig());
        modelBuilder.ApplyConfiguration(new TemporadaConfig());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
