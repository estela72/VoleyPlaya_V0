using Ligamania.Repository.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ligamania.Repository
{
    public class LigamaniaDbContext : IdentityDbContext<LigamaniaApplicationUser, IdentityRole, string>
    {
        private readonly IConfiguration _configuration;

        public LigamaniaDbContext() : base()
        {
        }

        public LigamaniaDbContext(DbContextOptions<LigamaniaDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) return;
            optionsBuilder.EnableSensitiveDataLogging();
            // connect to sql server database
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        ////OBSOLETO
        //[Obsolete]
        //public virtual DbSet<TemporadaJugadorObsolete> OldTemporadaJugador { get; set; }
        //[Obsolete]
        //public virtual DbSet<TemporadaClubJugadorDTO> TemporadaClubJugador { get; set; }
        //[Obsolete]
        //public virtual DbSet<TemporadaPuestoJugadorDTO> TemporadaPuestoJugador { get; set; }
        //[Obsolete]
        //public virtual DbSet<EntrenadorDTO> Entrenador { get; set; }
        //[Obsolete]
        //public virtual DbSet<oldAspNetRolesDTO> OldRoles { get; set; }
        //[Obsolete]
        //public virtual DbSet<oldAspNetUsersDTO> OldUsers { get; set; }
        //[Obsolete]
        //public virtual DbSet<oldAspNetUserRolesDTO> OldUserRoles { get; set; }
        //[Obsolete]
        //public virtual DbSet<TemporadaCuadroDTO> TemporadaCuadro { get; set; }
        ///// <summary>
        ///// FIN OBSOLETO
        ///// </summary>

        //public virtual DbSet<MenuMasterViewModel> MenuMaster { get; set; }
        public virtual DbSet<EquipoDTO> Equipo { get; set; }

        public virtual DbSet<TemporadaJugadorDTO> TemporadaJugador { get; set; }
        public virtual DbSet<TemporadaDTO> Temporada { get; set; }
        public virtual DbSet<JugadorDTO> Jugador { get; set; }
        public virtual DbSet<ClubDTO> Club { get; set; }
        public virtual DbSet<PuestoDTO> Puesto { get; set; }
        public virtual DbSet<TemporadaCompeticionDTO> TemporadaCompeticion { get; set; }
        public virtual DbSet<CompeticionDTO> Competicion { get; set; }
        public virtual DbSet<EstadoCompeticionDTO> EstadoCompeticion { get; set; }
        public virtual DbSet<OperacionCompeticionDTO> OperacionCompeticion { get; set; }
        public virtual DbSet<TemporadaCompeticionOperacionDTO> TemporadaCompeticionOperacion { get; set; }
        public virtual DbSet<NoticiaDTO> Noticia { get; set; }
        public virtual DbSet<TemporadaCompeticionJornadaDTO> TemporadaCompeticionJornada { get; set; }
        public virtual DbSet<TemporadaJornadaJugadorDTO> TemporadaJornadaJugador { get; set; }
        public virtual DbSet<CategoriaDTO> Categoria { get; set; }
        public virtual DbSet<TemporadaClasificacionDTO> TemporadaClasificacion { get; set; }
        public virtual DbSet<CompeticionCategoriaDTO> CompeticionCategoria { get; set; }
        public virtual DbSet<TemporadaCompeticionCategoriaDTO> TemporadaCompeticionCategoria { get; set; }
        public virtual DbSet<TemporadaCompeticionCategoriaReferenciaDTO> TemporadaCompeticionCategoriaReferencia { get; set; }
        public virtual DbSet<HistoricoDTO> Historico { get; set; }
        public virtual DbSet<PuntuacionHistoricaDTO> PuntuacionHistorica { get; set; }
        public virtual DbSet<CambiosEquipoDTO> CambiosEquipos { get; set; }
        public virtual DbSet<TemporadaEquipoDTO> TemporadaEquipo { get; set; }
        public virtual DbSet<TemporadaContabilidadDTO> TemporadaContabilidad { get; set; }
        public virtual DbSet<TemporadaPremiosDTO> TemporadaPremios { get; set; }
        public virtual DbSet<TemporadaPremiosPuestoDTO> TemporadaPremiosPuestos { get; set; }
        public virtual DbSet<AlineacionDTO> Alineacion { get; set; }
        public virtual DbSet<AlineacionCambioDTO> AlineacionCambio { get; set; }
        public virtual DbSet<AlineacionPreviaDTO> AlineacionPrevia { get; set; }
        public virtual DbSet<AlineacionHistoricoDTO> HistoricoAlineacion { get; set; }
        public virtual DbSet<ControlUsuarioDTO> ControlUsuario { get; set; }
        public virtual DbSet<CalendarioDTO> Calendario { get; set; }
        public virtual DbSet<CalendarioDetalleDTO> CalendarioDetalle { get; set; }
        public virtual DbSet<DocumentsDTO> Documents { get; set; }
        public virtual DbSet<SettingsDTO> Settings { get; set; }
        public virtual DbSet<TemporadaPartidoDTO> TemporadaPartido { get; set; }

        public virtual DbSet<CuadroCopaDTO> CuadroCopa { get; set; }
        public virtual DbSet<TemporadaRondaDTO> Ronda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //#region ToRemove - Tablas Obsoletas
            modelBuilder.Entity<TemporadaCuadroDTO>(entity =>
            {
                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Criterio).HasMaxLength(256);

                entity.Property(e => e.EquipoACategoriaId).HasColumnName("EquipoA_Categoria_ID");

                entity.Property(e => e.EquipoACompeticionId).HasColumnName("EquipoA_Competicion_ID");

                entity.Property(e => e.EquipoAPuesto).HasColumnName("EquipoA_Puesto");

                entity.Property(e => e.EquipoBCategoriaId).HasColumnName("EquipoB_Categoria_ID");

                entity.Property(e => e.EquipoBCompeticionId).HasColumnName("EquipoB_Competicion_ID");

                entity.Property(e => e.EquipoBPuesto).HasColumnName("EquipoB_Puesto");

                entity.Property(e => e.NombreEquipoA)
                    .HasColumnName("Nombre_EquipoA")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEquipoB)
                    .HasColumnName("Nombre_EquipoB")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.NombreGanador)
                    .HasColumnName("Nombre_Ganador")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroPartido).HasColumnName("Numero_Partido");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaCuadroCompeticion)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCuadro_dbo.TemporadaCompeticion_Competicion_ID");

                entity.HasOne(d => d.EquipoACategoria)
                    .WithMany(p => p.TemporadaCuadroEquipoACategoria)
                    .HasForeignKey(d => d.EquipoACategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCuadro_dbo.TemporadaCompeticionCategoria_EquipoA_Categoria_ID");

                entity.HasOne(d => d.EquipoACompeticion)
                    .WithMany(p => p.TemporadaCuadroEquipoACompeticion)
                    .HasForeignKey(d => d.EquipoACompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCuadro_dbo.TemporadaCompeticion_EquipoA_Competicion_ID");

                entity.HasOne(d => d.EquipoBCategoria)
                    .WithMany(p => p.TemporadaCuadroEquipoBCategoria)
                    .HasForeignKey(d => d.EquipoBCategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCuadro_dbo.TemporadaCompeticionCategoria_EquipoB_Categoria_ID");

                entity.HasOne(d => d.EquipoBCompeticion)
                    .WithMany(p => p.TemporadaCuadroEquipoBCompeticion)
                    .HasForeignKey(d => d.EquipoBCompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCuadro_dbo.TemporadaCompeticion_EquipoB_Competicion_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaCuadro)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCuadro_dbo.Temporada_Temporada_ID");
            });
            //modelBuilder.Entity<oldAspNetRolesDTO>(entity =>
            //{
            //    entity.ToTable("oldAspNetRoles");

            //    entity.HasKey(e => e.Id);

            //    entity.HasIndex(e => e.Name)
            //        .HasName("OLDRoleNameIndex")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasMaxLength(128)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(256);
            //});

            //////modelBuilder.Entity<oldAspNetUserClaims_DTO>(entity =>
            //////{
            //////    entity.Property(e => e.UserId)
            //////        .IsRequired()
            //////        .HasMaxLength(128);

            //////    entity.HasOne(d => d.User)
            //////        .WithMany(p => p.AspNetUserClaims)
            //////        .HasForeignKey(d => d.UserId)
            //////        .OnDelete(DeleteBehavior.ClientSetNull)
            //////        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            //////});

            //////modelBuilder.Entity<oldAspNetUserLogins_DTO>(entity =>
            //////{
            //////    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

            //////    entity.Property(e => e.LoginProvider).HasMaxLength(128);

            //////    entity.Property(e => e.ProviderKey).HasMaxLength(128);

            //////    entity.Property(e => e.UserId).HasMaxLength(128);

            //////    entity.HasOne(d => d.User)
            //////        .WithMany(p => p.AspNetUserLogins)
            //////        .HasForeignKey(d => d.UserId)
            //////        .OnDelete(DeleteBehavior.ClientSetNull)
            //////        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            ////////});

            //modelBuilder.Entity<oldAspNetUserRolesDTO>(entity =>
            //{
            //    entity.ToTable("oldAspNetUserRoles");

            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.Property(e => e.UserId).HasMaxLength(128);

            //    entity.Property(e => e.RoleId).HasMaxLength(128);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("OLDFK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("OLDFK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            //});

            //modelBuilder.Entity<oldAspNetUsersDTO>(entity =>
            //{
            //    entity.ToTable("oldAspNetUsers");

            //    entity.HasKey(e => e.Id);

            //    entity.HasIndex(e => e.UserName)
            //        .HasName("OLDUserNameIndex")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasMaxLength(128)
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.LastLogin).HasColumnType("datetime");

            //    entity.Property(e => e.LastLogout).HasColumnType("datetime");

            //    entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasMaxLength(256);
            //});

            //modelBuilder.Entity<EntrenadorDTO>(entity =>
            //{
            //    entity.HasIndex(e => e.Nombre)
            //        .HasName("IX_Entrenador")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Email)
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EsBot).HasColumnName("EsBOT");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});
            ////modelBuilder.Entity<TemporadaJugador_Obsolete>(entity =>
            ////{
            ////    entity.ToTable("oldTemporadaJugador");
            ////});

            //modelBuilder.Entity<TemporadaJugadorObsolete>(entity =>
            //{
            //    entity.HasIndex(e => new { e.Temporada_ID, e.Jugador_ID })
            //        .HasName("IX_TemporadaJugador")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Jugador_ID).HasColumnName("Jugador_ID");

            //    entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    //entity.HasOne(d => d.Jugador)
            //    //    .WithMany(p => p.TemporadaJugador_obsolete)
            //    //    .HasForeignKey(d => d.Jugador_ID)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.Jugador_Jugador_ID");

            //    //entity.HasOne(d => d.Temporada)
            //    //    .WithMany(p => p.TemporadaJugador_obsolete)
            //    //    .HasForeignKey(d => d.Temporada_ID)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.Temporada_Temporada_ID");

            //});
            //modelBuilder.Entity<TemporadaClubJugadorDTO>(entity =>
            //{
            //    entity.HasIndex(e => new { e.TemporadaId, e.ClubId, e.JugadorId })
            //        .HasName("IX_TemporadaClubJugador")
            //        .IsUnique();

            //    entity.Property(e => e.ClubId).HasColumnName("Club_ID");

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.FechaAlta).HasColumnType("datetime");

            //    entity.Property(e => e.FechaBaja).HasColumnType("datetime");

            //    entity.Property(e => e.JugadorId).HasColumnName("Jugador_ID");

            //    entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    //entity.HasOne(d => d.Club)
            //    //    .WithMany(p => p.TemporadaClubJugador)
            //    //    .HasForeignKey(d => d.ClubId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaClubJugador_dbo.Club_Club_ID");

            //    //entity.HasOne(d => d.Jugador)
            //    //    .WithMany(p => p.TemporadaClubJugador)
            //    //    .HasForeignKey(d => d.JugadorId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaClubJugador_dbo.Jugador_Jugador_ID");

            //    //entity.HasOne(d => d.Temporada)
            //    //    .WithMany(p => p.TemporadaClubJugador)
            //    //    .HasForeignKey(d => d.TemporadaId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaClubJugador_dbo.Temporada_Temporada_ID");
            //});

            //modelBuilder.Entity<TemporadaPuestoJugadorDTO>(entity =>
            //{
            //    entity.HasIndex(e => new { e.TemporadaId, e.PuestoId, e.JugadorId })
            //        .HasName("IX_TemporadaPuestoJugador")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.FechaAlta).HasColumnType("datetime");

            //    entity.Property(e => e.FechaBaja).HasColumnType("datetime");

            //    entity.Property(e => e.JugadorId).HasColumnName("Jugador_ID");

            //    entity.Property(e => e.PuestoId).HasColumnName("Puesto_ID");

            //    entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    //entity.HasOne(d => d.Jugador)
            //    //    .WithMany(p => p.TemporadaPuestoJugador)
            //    //    .HasForeignKey(d => d.JugadorId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaPuestoJugador_dbo.Jugador_Jugador_ID");

            //    //entity.HasOne(d => d.Puesto)
            //    //    .WithMany(p => p.TemporadaPuestoJugador)
            //    //    .HasForeignKey(d => d.PuestoId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaPuestoJugador_dbo.Puesto_Puesto_ID");

            //    //entity.HasOne(d => d.Temporada)
            //    //    .WithMany(p => p.TemporadaPuestoJugador)
            //    //    .HasForeignKey(d => d.TemporadaId)
            //    //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    //    .HasConstraintName("FK_dbo.TemporadaPuestoJugador_dbo.Temporada_Temporada_ID");
            //});
            //#endregion

            modelBuilder.Entity<TemporadaJugadorDTO>(entity =>
            {
                entity.ToTable("TemporadaJugador");

                entity.HasIndex(e => new { e.Temporada_ID, e.Jugador_ID })
                    .HasDatabaseName("IX_TemporadaJugador")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Jugador_ID).HasColumnName("Jugador_ID");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.TemporadaJugador)
                    .HasForeignKey(d => d.Jugador_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.Jugador_Jugador_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaJugador)
                    .HasForeignKey(d => d.Temporada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.Temporada_Temporada_ID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.TemporadaJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.Club_Club_ID");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.TemporadaJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.Puesto_Puesto_ID");

                entity.HasOne(d => d.LastJornadaEliminacion)
                    .WithMany(p => p.TemporadaJugador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJugador_dbo.TemporadaCompeticionJornada_ID");
            });
            modelBuilder.Entity<EquipoDTO>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasDatabaseName("IX_Equipo")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Entrenador_Id).HasColumnName("Entrenador_Id");

                entity.Property(e => e.EsBot).HasColumnName("EsBOT");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Entrenador)
                //    .WithMany(p => p.Equipos)
                //    .HasForeignKey(d => d.Entrenador_Id)
                //    .HasConstraintName("FK_dbo.Equipo_dbo.Equipo_ApplicationUser_Id");
            });
            modelBuilder.Entity<TemporadaCompeticionDTO>(entity =>
            {
                entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId })
                    .HasDatabaseName("IX_TemporadaCompeticion")
                    .IsUnique();

                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DescripcionEstado)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoActualId).HasColumnName("EstadoActual_Id");

                entity.Property(e => e.OperacionActualId).HasColumnName("OperacionActual_Id");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaCompeticion)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticion_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.EstadoActual)
                    .WithMany(p => p.TemporadaCompeticion)
                    .HasForeignKey(d => d.EstadoActualId)
                    .HasConstraintName("FK_dbo.TemporadaCompeticion_dbo.EstadoCompeticion_EstadoActual_Id");

                entity.HasOne(d => d.OperacionActual)
                    .WithMany(p => p.TemporadaCompeticion)
                    .HasForeignKey(d => d.OperacionActualId)
                    .HasConstraintName("FK_dbo.TemporadaCompeticion_dbo.OperacionCompeticion_OperacionActual_Id");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaCompeticion)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticion_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<CompeticionDTO>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasDatabaseName("IX_Competicion")
                    .IsUnique();

                entity.Property(e => e.CompeticionCopiarAliIni)
                    .HasColumnName("Competicion_CopiarAliIni")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CopiarAlineacionInicial).HasColumnName("Copiar_AlineacionInicial");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<OperacionCompeticionDTO>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<EstadoCompeticionDTO>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<TemporadaCompeticionOperacionDTO>(entity =>
            {
                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_Id");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EstadoCompeticionId).HasColumnName("EstadoCompeticion_Id");

                entity.Property(e => e.EstadoSiguienteId).HasColumnName("EstadoSiguiente_Id");

                entity.Property(e => e.OperacionCompeticionId).HasColumnName("OperacionCompeticion_Id");

                entity.Property(e => e.OperacionSiguienteId).HasColumnName("OperacionSiguiente_Id");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaCompeticionOperacion)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionOperacion_dbo.TemporadaCompeticion_Competicion_Id");

                entity.HasOne(d => d.EstadoCompeticion)
                    .WithMany(p => p.TemporadaCompeticionOperacionEstadoCompeticion)
                    .HasForeignKey(d => d.EstadoCompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionOperacion_dbo.EstadoCompeticion_EstadoCompeticion_Id");

                entity.HasOne(d => d.EstadoSiguiente)
                    .WithMany(p => p.TemporadaCompeticionOperacionEstadoSiguiente)
                    .HasForeignKey(d => d.EstadoSiguienteId)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionOperacion_dbo.EstadoCompeticion_EstadoSiguiente_Id");

                entity.HasOne(d => d.OperacionCompeticion)
                    .WithMany(p => p.TemporadaCompeticionOperacionOperacionCompeticion)
                    .HasForeignKey(d => d.OperacionCompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionOperacion_dbo.OperacionCompeticion_OperacionCompeticion_Id");

                entity.HasOne(d => d.OperacionSiguiente)
                    .WithMany(p => p.TemporadaCompeticionOperacionOperacionSiguiente)
                    .HasForeignKey(d => d.OperacionSiguienteId)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionOperacion_dbo.OperacionCompeticion_OperacionSiguiente_Id");
            });
            modelBuilder.Entity<NoticiaDTO>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Texto)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CuadroCopaDTO>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasIndex(e => new { e.Ronda, e.NumPartido })
                        .HasDatabaseName("IX_CuadroCopa")
                        .IsUnique();

                    entity.HasOne(e => e.CompeticionCategoriaEquipoA)
                        .WithMany(p => p.CuadroCopaEquipoA)
                        .HasForeignKey(e => new { e.CompeticionEquipoAId, e.CategoriaEquipoAId })
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_dbo.CuadoCopa_dbo.CompeticionCategoriaEquipoAId");

                    entity.HasOne(e => e.CompeticionCategoriaEquipoB)
                        .WithMany(p => p.CuadroCopaEquipoB)
                        .HasForeignKey(e => new { e.CompeticionEquipoBId, e.CategoriaEquipoBId })
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_dbo.CuadoCopa_dbo.CompeticionCategoriaEquipoBId");
                });

            modelBuilder.Entity<CompeticionCategoriaDTO>(entity =>
            {
                entity.HasKey(e => new { e.Categoria_Id, e.Competicion_Id });

                entity.Property(e => e.Categoria_Id).HasColumnName("Categoria_Id");

                entity.Property(e => e.Competicion_Id).HasColumnName("Competicion_Id");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.CompeticionCategoria)
                    .HasForeignKey(d => d.Categoria_Id)
                    .HasConstraintName("FK_dbo.CompeticionCategoria_dbo.Categoria_Categoria_Id");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.CompeticionCategoria)
                    .HasForeignKey(d => d.Competicion_Id)
                    .HasConstraintName("FK_dbo.CompeticionCategoria_dbo.Competicion_Competicion_Id");
            });
            modelBuilder.Entity<TemporadaCompeticionJornadaDTO>(entity =>
            {
                entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.NumeroJornada })
                    .HasDatabaseName("IX_TemporadaCompeticionJornada")
                    .IsUnique();

                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.NumeroJornada).HasColumnName("Numero_Jornada");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaCompeticionJornada)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionJornada_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaCompeticionJornada)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionJornada_dbo.Temporada_Temporada_ID");

                entity.HasOne(d => d.Ronda)
                    .WithMany(r => r.JornadasFinal)
                    .HasForeignKey(r => r.RondaId)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionJornadaIda_dbo.TemporadaRonda_RondaId");
            });
            modelBuilder.Entity<TemporadaJornadaJugadorDTO>(entity =>
            {
                entity.HasIndex(e => new { e.TemporadaId, e.JornadaId, e.JugadorId })
                    .HasDatabaseName("IX_TemporadaJornadaJugador")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.JornadaId).HasColumnName("Jornada_ID");

                entity.Property(e => e.JugadorId).HasColumnName("Jugador_ID");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.TemporadaJornadaJugador)
                    .HasForeignKey(d => d.JornadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJornadaJugador_dbo.TemporadaCompeticionJornada_Jornada_ID");

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.TemporadaJornadaJugador)
                    .HasForeignKey(d => d.JugadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJornadaJugador_dbo.Jugador_Jugador_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaJornadaJugador)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaJornadaJugador_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<CategoriaDTO>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasDatabaseName("IX_Categoria")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<TemporadaClasificacionDTO>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EquipoId).HasColumnName("Equipo_ID");

                entity.Property(e => e.FechaIns).HasColumnType("datetime");

                entity.Property(e => e.JornadaId).HasColumnName("Jornada_ID");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.TemporadaClasificacion)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaClasificacion_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaClasificacion)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaClasificacion_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.TemporadaClasificacion)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaClasificacion_dbo.Equipo_Equipo_ID");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.TemporadaClasificacion)
                    .HasForeignKey(d => d.JornadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaClasificacion_dbo.TemporadaCompeticionJornada_Jornada_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaClasificacion)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaClasificacion_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<TemporadaCompeticionCategoriaDTO>(entity =>
            {
                entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.CategoriaId })
                    .HasDatabaseName("IX_TemporadaCompeticionCategoria")
                    .IsUnique();

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NumeroMaximoJugadorEliminar).HasColumnName("NumeroMaximoJugador_Eliminar");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.TemporadaCompeticionCategoria)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionCategoria_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaCompeticionCategoria)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionCategoria_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaCompeticionCategoria)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaCompeticionCategoria_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<TemporadaCompeticionCategoriaReferenciaDTO>(entity =>
            {
                entity.ToTable("TemporadaCompeticionCategoriaReferencia");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.PosicionFinal).HasColumnName("Posicion_Final");

                entity.Property(e => e.PosicionInicial).HasColumnName("Posicion_Inicial");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<HistoricoDTO>(entity =>
            {
                entity.HasIndex(e => new { e.Temporada_ID, e.Equipo_ID, e.Categoria_ID, e.Puesto })
                    .HasDatabaseName("IX_Historico")
                    .IsUnique();

                entity.Property(e => e.Categoria_ID).HasColumnName("Categoria_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Equipo_ID).HasColumnName("Equipo_ID");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.TemporadaCompeticionCategoria)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.Categoria_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Historico_dbo.TemporadaCompeticionCategoria_Categoria_ID");

                entity.HasOne(d => d.TemporadaEquipo)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.Equipo_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Historico_dbo.TemporadaEquipo_Equipo_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.Historico)
                    .HasForeignKey(d => d.Temporada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Historico_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<PuntuacionHistoricaDTO>(entity =>
            {
                entity.Property(e => e.Categoria_Id).HasColumnName("Categoria_Id");

                entity.Property(e => e.Competicion_Id).HasColumnName("Competicion_Id");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.PuntuacionHistorica)
                    .HasForeignKey(d => d.Categoria_Id)
                    .HasConstraintName("FK_dbo.PuntuacionHistorica_dbo.Categoria_Categoria_Id");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.PuntuacionHistorica)
                    .HasForeignKey(d => d.Competicion_Id)
                    .HasConstraintName("FK_dbo.PuntuacionHistorica_dbo.Competicion_Competicion_Id");
            });
            modelBuilder.Entity<CambiosEquipoDTO>(entity =>
            {
                entity.ToTable("CambiosEquipo");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EquipoDestino_ID).HasColumnName("Equipo_Destino_Id");

                entity.Property(e => e.EquipoOrigen_ID).HasColumnName("Equipo_Origen_Id");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_Id");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EquipoDestino)
                    .WithMany(p => p.CambiosEquipoEquipoDestino)
                    .HasForeignKey(d => d.EquipoDestino_ID)
                    .HasConstraintName("FK_dbo.CambiosEquipo_dbo.Equipo_Equipo_Destino_Id");

                entity.HasOne(d => d.EquipoOrigen)
                    .WithMany(p => p.CambiosEquipoEquipoOrigen)
                    .HasForeignKey(d => d.EquipoOrigen_ID)
                    .HasConstraintName("FK_dbo.CambiosEquipo_dbo.Equipo_Equipo_Origen_Id");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.CambiosEquipo)
                    .HasForeignKey(d => d.Temporada_ID)
                    .HasConstraintName("FK_dbo.CambiosEquipo_dbo.Temporada_Temporada_Id");
            });
            modelBuilder.Entity<TemporadaEquipoDTO>(entity =>
            {
                entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.CategoriaId, e.EquipoId })
                    .HasDatabaseName("IX_TemporadaEquipo")
                    .IsUnique();

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EquipoId).HasColumnName("Equipo_ID");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.TemporadaEquipo)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaEquipo_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaEquipo)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaEquipo_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.TemporadaEquipo)
                    .HasForeignKey(d => d.EquipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaEquipo_dbo.Equipo_Equipo_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaEquipo)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaEquipo_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<TemporadaContabilidadDTO>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaContabilidad)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaContabilidad_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<TemporadaPremiosDTO>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.TemporadaPremios)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaPremios_dbo.TemporadaCompeticionCategoria_Categoria_ID");
            });
            modelBuilder.Entity<TemporadaPremiosPuestoDTO>(entity =>
            {
                entity.ToTable("TemporadaPremiosPuesto");
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PremioCategoriaId).HasColumnName("PremioCategoria_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.PremioCategoria)
                    .WithMany(p => p.TemporadaPremiosPuesto)
                    .HasForeignKey(d => d.PremioCategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaPremiosPuesto_dbo.TemporadaPremios_PremioCategoria_ID");
            });
            modelBuilder.Entity<AlineacionDTO>(entity =>
            {
                entity.HasIndex(e => e.Equipo_ID)
                    .HasDatabaseName("IX_Alineacion_2");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Jornada_ID })
                    .HasDatabaseName("IX_Alineacion_3");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Equipo_ID, e.Jornada_ID, e.Jugador_ID })
                    .HasDatabaseName("IX_Alineacion")
                    .IsUnique();

                entity.Property(e => e.Categoria_ID).HasColumnName("Categoria_ID");

                entity.Property(e => e.Club_ID).HasColumnName("Club_ID");

                entity.Property(e => e.Competicion_ID).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Equipo_ID).HasColumnName("Equipo_ID");

                entity.Property(e => e.Jornada_ID).HasColumnName("Jornada_ID");

                entity.Property(e => e.Jugador_ID).HasColumnName("Jugador_ID");

                entity.Property(e => e.Puesto_ID).HasColumnName("Puesto_ID");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Categoria_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Club_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.Club_Club_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Competicion_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Equipo_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.TemporadaEquipo_Equipo_ID");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Jornada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.TemporadaCompeticionJornada_Jornada_ID");

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Jugador_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.Jugador_Jugador_ID");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Puesto_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.Puesto_Puesto_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.Alineacion)
                    .HasForeignKey(d => d.Temporada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<AlineacionCambioDTO>(entity =>
            {
                entity.ToTable("Alineacion_Cambio");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Equipo_ID })
                    .HasDatabaseName("IX_AlineacionCambio_2");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Equipo_ID, e.Jugador_ID })
                    .HasDatabaseName("IX_AlineacionCambio")
                    .IsUnique();

                entity.Property(e => e.Categoria_ID).HasColumnName("Categoria_ID");

                //entity.Property(e => e.ClubCambio_ID).HasColumnName("ClubCambio_ID");

                entity.Property(e => e.Club_ID).HasColumnName("Club_ID");

                entity.Property(e => e.Competicion_ID).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Equipo_ID).HasColumnName("Equipo_ID");

                //entity.Property(e => e.JugadorCambio_ID).HasColumnName("JugadorCambio_ID");

                entity.Property(e => e.Jugador_ID).HasColumnName("Jugador_ID");

                entity.Property(e => e.Puesto_ID).HasColumnName("Puesto_ID");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.AlineacionCambio)
                    .HasForeignKey(d => d.Categoria_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Categoria_Categoria_ID");

                //entity.HasOne(d => d.ClubCambio)
                //    .WithMany(p => p.AlineacionCambioClubCambio)
                //    .HasForeignKey(d => d.ClubCambio_ID)
                //    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Club_ClubCambio_ID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.AlineacionCambioClub)
                    .HasForeignKey(d => d.Club_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Club_Club_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.AlineacionCambio)
                    .HasForeignKey(d => d.Competicion_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.AlineacionCambio)
                    .HasForeignKey(d => d.Equipo_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.TemporadaEquipo_Equipo_ID");

                //entity.HasOne(d => d.JugadorCambio)
                //    .WithMany(p => p.AlineacionCambioJugadorCambio)
                //    .HasForeignKey(d => d.JugadorCambio_ID)
                //    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Jugador_JugadorCambio_ID");

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.AlineacionCambioJugador)
                    .HasForeignKey(d => d.Jugador_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Jugador_Jugador_ID");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.AlineacionCambio)
                    .HasForeignKey(d => d.Puesto_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Puesto_Puesto_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.AlineacionCambio)
                    .HasForeignKey(d => d.Temporada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Cambio_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<AlineacionPreviaDTO>(entity =>
            {
                entity.ToTable("Alineacion_Previa");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Equipo_ID, e.Jugador_ID })
                    .HasDatabaseName("IX_AlineacionPrevia")
                    .IsUnique();

                entity.Property(e => e.Categoria_ID).HasColumnName("Categoria_ID");

                entity.Property(e => e.Club_ID).HasColumnName("Club_ID");

                entity.Property(e => e.Competicion_ID).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Equipo_ID).HasColumnName("Equipo_ID");

                entity.Property(e => e.Jugador_ID).HasColumnName("Jugador_ID");

                entity.Property(e => e.Puesto_ID).HasColumnName("Puesto_ID");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Categoria_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Club_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.Club_Club_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Competicion_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Equipo_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.TemporadaEquipo_Equipo_ID");

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Jugador_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.Jugador_Jugador_ID");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Puesto_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.Puesto_Puesto_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.AlineacionPrevia)
                    .HasForeignKey(d => d.Temporada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Alineacion_Previa_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<AlineacionHistoricoDTO>(entity =>
            {
                entity.ToTable("HistoricoAlineacion");

                entity.HasIndex(e => e.Equipo_ID)
                    .HasDatabaseName("IX_HistoricoAlineacion_2");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Jornada_ID })
                    .HasDatabaseName("IX_HistoricoAlineacion_3");

                entity.HasIndex(e => new { e.Temporada_ID, e.Competicion_ID, e.Categoria_ID, e.Equipo_ID, e.Jornada_ID, e.Jugador_ID })
                    .HasDatabaseName("IX_HistoricoAlineacion")
                    .IsUnique();

                entity.Property(e => e.Categoria_ID).HasColumnName("Categoria_ID");

                entity.Property(e => e.Club_ID).HasColumnName("Club_ID");

                entity.Property(e => e.Competicion_ID).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Equipo_ID).HasColumnName("Equipo_ID");

                entity.Property(e => e.Jornada_ID).HasColumnName("Jornada_ID");

                entity.Property(e => e.Jugador_ID).HasColumnName("Jugador_ID");

                entity.Property(e => e.Puesto_ID).HasColumnName("Puesto_ID");

                entity.Property(e => e.Temporada_ID).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Categoria_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Club_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.Club_Club_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Competicion_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.Equipo)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Equipo_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.TemporadaEquipo_Equipo_ID");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Jornada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.TemporadaCompeticionJornada_Jornada_ID");

                entity.HasOne(d => d.Jugador)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Jugador_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.Jugador_Jugador_ID");

                entity.HasOne(d => d.Puesto)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Puesto_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.Puesto_Puesto_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.AlineacionHistorica)
                    .HasForeignKey(d => d.Temporada_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.HistoricoAlineacion_dbo.Temporada_Temporada_ID");
            });
            modelBuilder.Entity<ControlUsuarioDTO>(entity =>
            {
                entity.Property(e => e.Accion)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<CalendarioDTO>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<CalendarioDetalleDTO>(entity =>
            {
                entity.Property(e => e.Calendario_ID).HasColumnName("Calendario_Id");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Calendario)
                    .WithMany(p => p.CalendarioDetalle)
                    .HasForeignKey(d => d.Calendario_ID)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_dbo.CalendarioDetalle_dbo.Calendario_Calendario_Id");
            });
            modelBuilder.Entity<DocumentsDTO>(entity =>
            {
                entity.HasIndex(e => e.Nombre)
                    .HasDatabaseName("IX_Documents")
                    .IsUnique();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
            modelBuilder.Entity<SettingsDTO>(entity =>
            {
                entity.Property(e => e.ClasificacionRotuloCopa).HasColumnName("Clasificacion_RotuloCopa");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TemporadaPremios).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VerCuadroCopa).HasColumnName("Ver_CuadroCopa");

                entity.Property(e => e.VerEquiposPretemporada).HasColumnName("Ver_EquiposPretemporada");

                entity.Property(e => e.VerNoticias).HasColumnName("Ver_Noticias");
            });
            modelBuilder.Entity<TemporadaPartidoDTO>(entity =>
            {
                entity.HasIndex(e => new { e.TemporadaId, e.CompeticionId, e.CategoriaId, e.JornadaId, e.EquipoAId, e.EquipoBId })
                    .HasDatabaseName("IX_TemporadaPartido_2")
                    .IsUnique();

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.CompeticionId).HasColumnName("Competicion_ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EquipoAId).HasColumnName("Equipo_A_Id");

                entity.Property(e => e.EquipoBId).HasColumnName("Equipo_B_Id");

                entity.Property(e => e.EquipoGanadorId).HasColumnName("Equipo_Ganador_Id");

                entity.Property(e => e.JornadaId).HasColumnName("Jornada_ID");

                entity.Property(e => e.NumeroPartido).HasColumnName("Numero_Partido");

                entity.Property(e => e.ResultadoA).HasColumnName("Resultado_A");

                entity.Property(e => e.ResultadoB).HasColumnName("Resultado_B");

                entity.Property(e => e.TemporadaId).HasColumnName("Temporada_ID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.TemporadaPartido)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.Categoria_Categoria_ID");

                entity.HasOne(d => d.Competicion)
                    .WithMany(p => p.TemporadaPartido)
                    .HasForeignKey(d => d.CompeticionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.Competicion_Competicion_ID");

                entity.HasOne(d => d.EquipoA)
                    .WithMany(p => p.TemporadaPartidoEquipoA)
                    .HasForeignKey(d => d.EquipoAId)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.Equipo_Equipo_A_Id");

                entity.HasOne(d => d.EquipoB)
                    .WithMany(p => p.TemporadaPartidoEquipoB)
                    .HasForeignKey(d => d.EquipoBId)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.Equipo_Equipo_B_Id");

                entity.HasOne(d => d.EquipoGanador)
                    .WithMany(p => p.TemporadaPartidoEquipoGanador)
                    .HasForeignKey(d => d.EquipoGanadorId)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.Equipo_Equipo_Ganador_Id");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.TemporadaPartido)
                    .HasForeignKey(d => d.JornadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.TemporadaCompeticionJornada_Jornada_ID");

                entity.HasOne(d => d.Temporada)
                    .WithMany(p => p.TemporadaPartido)
                    .HasForeignKey(d => d.TemporadaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaPartido_dbo.Temporada_Temporada_ID");
            });

            modelBuilder.Entity<TemporadaRondaDTO>(entity =>
            {
                entity.ToTable("TemporadaRonda");

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasIndex(e => new { e.TemporadaID, e.CompeticionID, e.NumRonda })
                    .HasDatabaseName("IX_TemporadaRonda")
                    .IsUnique();

                entity.HasOne(e => e.Temporada)
                    .WithMany(t => t.Rondas)
                    .HasForeignKey(e => e.TemporadaID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaRonda_dbo.Temporada_TemporadaID");
                entity.HasOne(e => e.Competicion)
                    .WithMany(t => t.Rondas)
                    .HasForeignKey(e => e.CompeticionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.TemporadaRonda_dbo.Competicion_CompeticionID");
                //entity.HasOne(e => e.JornadaIda)
                //    .WithOne(t => t.Ronda)
                //    .HasForeignKey<TemporadaCompeticionJornada_DTO>(e=>e.Ronda)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_dbo.TemporadaRonda_dbo.JornadaIda_JornadaIdaID");
                //entity.HasOne(e => e.JornadaVuelta)
                //    .WithOne(t => t.Ronda)
                //    .HasForeignKey<TemporadaCompeticionJornada_DTO>(e => e.Ronda)
                //   .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_dbo.TemporadaRonda_dbo.JornadaVuelta_JornadaIdaID");
            });

            //modelBuilder.Entity<Club_DTO>(entity =>
            //{
            //    entity.HasIndex(e => e.Nombre)
            //        .HasName("IX_Club")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<Jugador_DTO>(entity =>
            //{
            //    entity.HasIndex(e => e.Nombre)
            //        .HasName("IX_Jugador")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<Puesto_DTO>(entity =>
            //{
            //    entity.HasIndex(e => e.Nombre)
            //        .HasName("IX_Puesto")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<Temporada_DTO>(entity =>
            //{
            //    entity.HasIndex(e => e.Nombre)
            //        .HasName("IX_Temporada")
            //        .IsUnique();

            //    entity.Property(e => e.CreatedBy).HasMaxLength(256);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.ImgClasificacion)
            //        .HasColumnName("Img_Clasificacion")
            //        .HasColumnType("image");

            //    entity.Property(e => e.Nombre)
            //        .HasMaxLength(200)
            //        .IsUnicode(false);

            //    entity.Property(e => e.UpdatedBy).HasMaxLength(256);

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});
        }

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(x => x.Entity is IEntity
        //            && (x.State == EntityState.Added || x.State == EntityState.Modified));

        //    foreach (var entry in modifiedEntries)
        //    {
        //        if (entry.Entity is IEntity entity)
        //        {
        //            string identityName = string.Empty;// GetIdentity();
        //            //string identityName = "not identified";
        //            //try
        //            //{
        //            //    identityName = WindowsIdentity.GetCurrent().Name;
        //            //}
        //            //catch { }
        //            //finally { }
        //            DateTime now = DateTime.UtcNow;

        //            if (entry.State == EntityState.Added)
        //            {
        //                entity.CreatedBy = identityName;
        //                entity.CreatedDate = now;
        //            }
        //            else
        //            {
        //                base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //            }

        //            entity.UpdatedBy = identityName;
        //            entity.UpdatedDate = now;
        //        }
        //    }

        //    var entities = from e in ChangeTracker.Entries()
        //                   where e.State == EntityState.Added
        //                       || e.State == EntityState.Modified
        //                   select e.Entity;
        //    foreach (var entity in entities)
        //    {
        //        var validationContext = new ValidationContext(entity);
        //        Validator.ValidateObject(entity, validationContext);
        //    }

        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}
        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        var modifiedEntries = ChangeTracker.Entries()
        //            .Where(x => x.Entity is IEntity
        //                && (x.State == EntityState.Added || x.State == EntityState.Modified));

        //        foreach (var entry in modifiedEntries)
        //        {
        //            if (entry.Entity is IEntity entity)
        //            {
        //                string identityName = WindowsIdentity.GetCurrent().Name;
        //                // string.Empty;// GetIdentity();
        //                                                   //string identityName = "not identified";
        //                                                   //try
        //                                                   //{
        //                                                   //    identityName = WindowsIdentity.GetCurrent().Name;
        //                                                   //}
        //                                                   //catch { }
        //                                                   //finally { }
        //                DateTime now = DateTime.UtcNow;

        //                if (entry.State == EntityState.Added)
        //                {
        //                    entity.CreatedBy = identityName;
        //                    entity.CreatedDate = now;
        //                }
        //                else
        //                {
        //                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
        //                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
        //                }

        //                entity.UpdatedBy = identityName;
        //                entity.UpdatedDate = now;
        //            }
        //        }

        //        var entities = from e in ChangeTracker.Entries()
        //                       where e.State == EntityState.Added
        //                           || e.State == EntityState.Modified
        //                       select e.Entity;
        //        foreach (var entity in entities)
        //        {
        //            var validationContext = new ValidationContext(entity);
        //            Validator.ValidateObject(entity, validationContext);
        //        }

        //        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //    }
        //    catch (DbUpdateConcurrencyException updateConcException)
        //    {
        //        Console.WriteLine("error " + updateConcException);
        //        return null;
        //    }
        //    catch (DbUpdateException updateException)
        //    {
        //        Console.WriteLine("error " + updateException);
        //        return null;
        //    }
        //}
    }
}