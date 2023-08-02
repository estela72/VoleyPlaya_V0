using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VoleyPlaya.Organization.Domain;

namespace VoleyPlaya.Organization.Infraestructure.Persistence;

public partial class VoleyPlayaOrganizationContext : DbContext
{
    public VoleyPlayaOrganizationContext(DbContextOptions<VoleyPlayaOrganizationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Competicion> Competiciones { get; set; }

    public virtual DbSet<Tabla> Tablas { get; set; }

    public virtual DbSet<Temporada> Temporadas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriaConfig());
        modelBuilder.ApplyConfiguration(new CompeticionConfig());
        modelBuilder.ApplyConfiguration(new EquipoConfig());
        modelBuilder.ApplyConfiguration(new TablaConfig());
        modelBuilder.ApplyConfiguration(new TemporadaConfig());

        //modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        //modelBuilder.Entity<Categoria>(entity =>
        //{
        //    entity.HasIndex(e => e.Nombre, "IX_Categoria")
        //        .IsUnique()
        //        .HasFilter("([Nombre] IS NOT NULL)");

        //    entity.Property(e => e.CreatedBy).HasMaxLength(256);
        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);
        //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Competicion>(entity =>
        //{
        //    entity.HasIndex(e => e.Nombre, "IX_Competicion")
        //        .IsUnique()
        //        .HasFilter("([Nombre] IS NOT NULL)");

        //    entity.Property(e => e.CreatedBy).HasMaxLength(256);
        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);
        //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Equipo>(entity =>
        //{
        //    entity.HasIndex(e => new { e.EdicionId, e.Nombre }, "IX_Equipo")
        //        .IsUnique()
        //        .HasFilter("([EdicionId] IS NOT NULL AND [Nombre] IS NOT NULL)");

        //    entity.Property(e => e.CreatedBy).HasMaxLength(256);
        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);
        //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Tabla>(entity =>
        //{
        //    entity.Property(e => e.CreatedBy).HasMaxLength(256);
        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);
        //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //});

        //modelBuilder.Entity<Temporada>(entity =>
        //{
        //    entity.HasIndex(e => e.Nombre, "IX_Temporada")
        //        .IsUnique()
        //        .HasFilter("([Nombre] IS NOT NULL)");

        //    entity.Property(e => e.Actual)
        //        .IsRequired()
        //        .HasDefaultValueSql("(CONVERT([bit],(0)))");
        //    entity.Property(e => e.CreatedBy).HasMaxLength(256);
        //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);
        //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
