using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;

using Common.Infraestructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Infraestructure.Persistence;

public partial class VoleyPlayaOrganizationContext : GenericDbContext
{
    //public VoleyPlayaOrganizationContext():base()
    //{ }
    public VoleyPlayaOrganizationContext(DbContextOptions<VoleyPlayaOrganizationContext> options/*, IIdentity identity*/)
        : base(options/*,identity*/)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Competicion> Competiciones { get; set; }
    public virtual DbSet<Equipo> Equipos { get; set; }
    public virtual DbSet<Tabla> Tablas { get; set; }

    public virtual DbSet<Temporada> Temporadas { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //}
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
