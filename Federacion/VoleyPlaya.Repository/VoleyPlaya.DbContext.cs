using VoleyPlaya.Repository.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VoleyPlaya.Repository
{
    public class VoleyPlayaDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Competicion> Competiciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Edicion> Ediciones { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<ParcialPartido> Parciales { get; set; }

        public VoleyPlayaDbContext(DbContextOptions<VoleyPlayaDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = _configuration.GetRequiredSection("ConnectionStrings:DatabaseConnection").Value;
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.Entity<Temporada>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre})
                    .HasDatabaseName("IX_Temporada")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<Competicion>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_Competicion")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_Categoria")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_Equipo")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Edicion)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey("EdicionID")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Equipo_dbo.Edicion_ID");
            });
            modelBuilder.Entity<Edicion>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_Edicion")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Temporada)
                  .WithMany(p => p.Ediciones)
                  .HasForeignKey("TemporadaID")
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_dbo.EdicionTemporada_ID");
                entity.HasOne(d => d.Competicion)
                  .WithMany(p => p.Ediciones)
                  .HasForeignKey("CompeticionID")
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_dbo.EdicionCompeticion_ID");
                entity.HasOne(d => d.Categoria)
                  .WithMany(p => p.Ediciones)
                  .HasForeignKey("CategoriaID")
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_dbo.EdicionCategoria_ID");
            });
            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_Partido")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Edicion)
                      .WithMany(p => p.Partidos)
                      .HasForeignKey("PartidoID")
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_dbo.PartidoEdicion_ID");
                entity.HasOne(d => d.Local)
                      .WithMany(p => p.Locales)
                      .HasForeignKey("EquipoLocalID")
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_dbo.PartidoLocal_ID");
                entity.HasOne(d => d.Visitante)
                      .WithMany(p => p.Visitantes)
                      .HasForeignKey("EquipoVisitanteID")
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_dbo.PartidoVisitante_ID");
            });
            modelBuilder.Entity<ParcialPartido>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_ParcialPartido")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Partido)
                      .WithMany(p => p.Parciales)
                      .HasForeignKey("PartidoID")
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_dbo.ParcialPartido_ID");
            });

        }
    }
}