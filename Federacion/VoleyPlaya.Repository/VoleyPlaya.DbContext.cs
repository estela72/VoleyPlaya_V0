using VoleyPlaya.Repository.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Hosting;

namespace VoleyPlaya.Repository
{
    public class VoleyPlayaDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Competicion> Competiciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Edicion> Ediciones { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<ParcialPartido> Parciales { get; set; }
        public DbSet<EdicionGrupo> EdicionGrupos { get; set; }
        public DbSet<TablaCalendario> Tablas { get; set; }

        IHostingEnvironment _environment;

        public VoleyPlayaDbContext(DbContextOptions<VoleyPlayaDbContext> options, IConfiguration configuration, IHostingEnvironment environment)
            : base(options)
        {
            _configuration = configuration;
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"),
                x => x.MigrationsAssembly("VoleyPlaya.GestionWeb"))
            ;
            if (_environment.IsDevelopment())
            {
                optionsBuilder
                    .EnableSensitiveDataLogging();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and overrIde the defaults if needed.
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
                entity.HasIndex(e => new {e.EdicionId, e.EdicionGrupoId, e.Nombre })
                    .HasDatabaseName("IX_Equipo")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Edicion)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey("EdicionId")
                    .HasConstraintName("FK_dbo.Equipo_dbo.Edicion_Id");
                //entity.HasOne(d => d.EdicionGrupo)
                //    .WithMany(p => p.Equipos)
                //    .HasForeignKey("EdicionGrupoId")
                //    .HasConstraintName("FK_dbo.Equipo_dbo.EdicionGrupo_Id")
                //    ;
                entity.HasMany(d => d.Grupos)
                    .WithMany(p => p.Equipos);
            });
            modelBuilder.Entity<Edicion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.Nombre })
                    .HasDatabaseName("IX_Edicion")
                    .IsUnique();
                entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.CategoriaId, e.Genero, e.Prueba })
                    .HasDatabaseName("IX_EdicionKey")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Temporada)
                  .WithMany(p => p.Ediciones)
                  .HasForeignKey("TemporadaId")
                  .HasConstraintName("FK_dbo.EdicionTemporada_Id");
                entity.HasOne(d => d.Competicion)
                  .WithMany(p => p.Ediciones)
                  .HasForeignKey("CompeticionId")
                  .HasConstraintName("FK_dbo.EdicionCompeticion_Id");
                entity.HasOne(d => d.Categoria)
                  .WithMany(p => p.Ediciones)
                  .HasForeignKey("CategoriaId")
                  .HasConstraintName("FK_dbo.EdicionCategoria_Id");
            });
            modelBuilder.Entity<EdicionGrupo>(entity =>
            {
                entity.HasIndex(e => new { e.EdicionId, e.Nombre })
                    .HasDatabaseName("IX_EdicionGrupo")
                    .IsUnique();
                entity.HasOne(d => d.Edicion)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey("EdicionId")
                    .HasConstraintName("Fk_dbo.EdicionGrupoEdicion_Id");
            });
            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.HasIndex(e => new { e.EdicionId, e.Numero })
                    .HasDatabaseName("IX_Jornada")
                    .IsUnique();
                entity.HasOne(j => j.Edicion)
                    .WithMany(e => e.Jornadas)
                    .HasForeignKey("EdicionId")
                    .HasConstraintName("Fk_dbo.EdicionJornada_Id");
                }
            );
            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasIndex(e => new {e.Nombre })
                    .HasDatabaseName("IX_Partido")
                    .IsUnique();
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Grupo).WithMany(p => p.Partidos).HasForeignKey("GrupoId")
                      .HasConstraintName("FK_dbo.PartidoEdicion_Id");
                entity.HasOne(d => d.Local)
                      .WithMany(p => p.Locales)
                      .HasForeignKey("EquipoLocalId")
                      .HasConstraintName("FK_dbo.PartidoLocal_Id");
                entity.HasOne(d => d.Visitante)
                      .WithMany(p => p.Visitantes)
                      .HasForeignKey("EquipoVisitanteId")
                      .HasConstraintName("FK_dbo.PartidoVisitante_Id");
                entity.Navigation(p => p.Parciales).AutoInclude();
                entity.Navigation(p => p.Local).AutoInclude();
                entity.Navigation(p => p.Visitante).AutoInclude();
            });
            modelBuilder.Entity<ParcialPartido>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
                entity.HasOne(d => d.Partido)
                      .WithMany(p => p.Parciales)
                      .HasForeignKey("PartidoId")
                      .OnDelete(DeleteBehavior.ClientCascade)
                      .HasConstraintName("FK_dbo.ParcialPartido_Id");
            });
            modelBuilder.Entity<TablaCalendario>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(256);
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
    }
}