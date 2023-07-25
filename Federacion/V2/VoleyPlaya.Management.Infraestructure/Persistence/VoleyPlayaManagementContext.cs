using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using VoleyPlaya.Management.Domain;

namespace VoleyPlaya.Management.Infraestructure.Persistence;

public partial class VoleyPlayaManagementContext : DbContext
{
    public VoleyPlayaManagementContext()
    {
    }

    public VoleyPlayaManagementContext(DbContextOptions<VoleyPlayaManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EdicionGrupo> EdicionGrupos { get; set; }

    public virtual DbSet<Edicion> Ediciones { get; set; }

    public virtual DbSet<Jornada> Jornada { get; set; }

    //public virtual DbSet<Parcial> Parciales { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<EdicionGrupo>(entity =>
        {
            entity.HasIndex(e => new { e.EdicionId, e.Nombre }, "IX_EdicionGrupo")
                .IsUnique()
                .HasFilter("([Nombre] IS NOT NULL)");

            entity.HasOne(d => d.Edicion).WithMany(p => p.EdicionGrupos)
                .HasForeignKey(d => d.EdicionId)
                .HasConstraintName("Fk_dbo.EdicionGrupoEdicion_Id");
        });

        modelBuilder.Entity<Edicion>(entity =>
        {
            entity.HasIndex(e => e.Nombre, "IX_Edicion")
                .IsUnique()
                .HasFilter("([Nombre] IS NOT NULL)");

            entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.CategoriaId, e.Genero, e.Prueba }, "IX_EdicionKey").IsUnique();

            entity.HasIndex(e => e.CategoriaId, "IX_Ediciones_CategoriaId");

            entity.HasIndex(e => e.CompeticionId, "IX_Ediciones_CompeticionId");

            entity.Property(e => e.CreatedBy).HasMaxLength(256);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Genero).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Prueba).HasDefaultValueSql("(N'')");
            entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //entity.HasOne(d => d.Categoria).WithMany(p => p.Ediciones)
            //    .HasForeignKey(d => d.CategoriaId)
            //    .HasConstraintName("FK_dbo.EdicionCategoria_Id");

            //entity.HasOne(d => d.Competicion).WithMany(p => p.Ediciones)
            //    .HasForeignKey(d => d.CompeticionId)
            //    .HasConstraintName("FK_dbo.EdicionCompeticion_Id");

            //entity.HasOne(d => d.Temporada).WithMany(p => p.Ediciones)
            //    .HasForeignKey(d => d.TemporadaId)
            //    .HasConstraintName("FK_dbo.EdicionTemporada_Id");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasIndex(e => e.Nombre, "IX_Partido")
                .IsUnique()
                .HasFilter("([Nombre] IS NOT NULL)");

            entity.HasIndex(e => e.EquipoLocalId, "IX_Partidos_EquipoLocalId");

            entity.HasIndex(e => e.EquipoVisitanteId, "IX_Partidos_EquipoVisitanteId");

            entity.HasIndex(e => e.GrupoId, "IX_Partidos_GrupoId");

            entity.Property(e => e.ConResultado)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.CreatedBy).HasMaxLength(256);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ronda).HasDefaultValueSql("(N'')");
            entity.Property(e => e.UpdatedBy).HasMaxLength(256);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserResultado).HasDefaultValueSql("(N'')");
            entity.Property(e => e.UserValidador).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Validado)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");

            //entity.HasOne(d => d.EquipoLocal).WithMany(p => p.PartidoEquipoLocals)
            //    .HasForeignKey(d => d.EquipoLocalId)
            //    .HasConstraintName("FK_dbo.PartidoLocal_Id");

            //entity.HasOne(d => d.EquipoVisitante).WithMany(p => p.PartidoEquipoVisitantes)
            //    .HasForeignKey(d => d.EquipoVisitanteId)
            //    .HasConstraintName("FK_dbo.PartidoVisitante_Id");

            //entity.HasOne(d => d.Grupo).WithMany(p => p.Partidos)
            //    .HasForeignKey(d => d.GrupoId)
            //    .HasConstraintName("FK_dbo.PartidoEdicion_Id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
