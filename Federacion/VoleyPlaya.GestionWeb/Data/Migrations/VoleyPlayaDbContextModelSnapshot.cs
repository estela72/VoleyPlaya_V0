﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoleyPlaya.Repository;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    [DbContext(typeof(VoleyPlayaDbContext))]
    partial class VoleyPlayaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_Categoria")
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Competicion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_Competicion")
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Competiciones");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Edicion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("CompeticionId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lugar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModeloCompeticion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TemporadaId")
                        .HasColumnType("int");

                    b.Property<string>("TipoCalendario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CompeticionId");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_Edicion")
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.HasIndex("TemporadaId");

                    b.ToTable("Ediciones");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.EdicionGrupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdicionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EdicionId", "Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_EdicionGrupo")
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("EdicionGrupos");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Coeficiente")
                        .HasColumnType("float");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("EdicionGrupoId")
                        .HasColumnType("int");

                    b.Property<int?>("EdicionId")
                        .HasColumnType("int");

                    b.Property<int?>("Ganados")
                        .HasColumnType("int");

                    b.Property<int?>("Jugados")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("OrdenCalendario")
                        .HasColumnType("int");

                    b.Property<int?>("OrdenEntrada")
                        .HasColumnType("int");

                    b.Property<int?>("Perdidos")
                        .HasColumnType("int");

                    b.Property<int?>("Puntos")
                        .HasColumnType("int");

                    b.Property<int?>("PuntosContra")
                        .HasColumnType("int");

                    b.Property<int?>("PuntosFavor")
                        .HasColumnType("int");

                    b.Property<bool?>("Retirado")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EdicionGrupoId");

                    b.HasIndex("EdicionId", "EdicionGrupoId", "Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_Equipo")
                        .HasFilter("[EdicionId] IS NOT NULL AND [EdicionGrupoId] IS NOT NULL AND [Nombre] IS NOT NULL");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Jornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdicionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EdicionId", "Numero")
                        .IsUnique()
                        .HasDatabaseName("IX_Jornada");

                    b.ToTable("Jornada");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.ParcialPartido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoLocal")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoVisitante")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.ToTable("Parciales");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("EquipoLocalId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoVisitanteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GrupoId")
                        .HasColumnType("int");

                    b.Property<int?>("Jornada")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("NumPartido")
                        .HasColumnType("int");

                    b.Property<string>("Pista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResultadoLocal")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoVisitante")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EquipoLocalId");

                    b.HasIndex("EquipoVisitanteId");

                    b.HasIndex("GrupoId");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_Partido")
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.TablaCalendario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Equipo1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipo2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Jornada")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumEquipos")
                        .HasColumnType("int");

                    b.Property<int>("NumGrupos")
                        .HasColumnType("int");

                    b.Property<int>("NumPartido")
                        .HasColumnType("int");

                    b.Property<string>("Ronda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Tablas");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Temporada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasDatabaseName("IX_Temporada")
                        .HasFilter("[Nombre] IS NOT NULL");

                    b.ToTable("Temporadas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Edicion", b =>
                {
                    b.HasOne("VoleyPlaya.Repository.Models.Categoria", "Categoria")
                        .WithMany("Ediciones")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.EdicionCategoria_Id");

                    b.HasOne("VoleyPlaya.Repository.Models.Competicion", "Competicion")
                        .WithMany("Ediciones")
                        .HasForeignKey("CompeticionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.EdicionCompeticion_Id");

                    b.HasOne("VoleyPlaya.Repository.Models.Temporada", "Temporada")
                        .WithMany("Ediciones")
                        .HasForeignKey("TemporadaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.EdicionTemporada_Id");

                    b.Navigation("Categoria");

                    b.Navigation("Competicion");

                    b.Navigation("Temporada");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.EdicionGrupo", b =>
                {
                    b.HasOne("VoleyPlaya.Repository.Models.Edicion", "Edicion")
                        .WithMany("Grupos")
                        .HasForeignKey("EdicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_dbo.EdicionGrupoEdicion_Id");

                    b.Navigation("Edicion");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Equipo", b =>
                {
                    b.HasOne("VoleyPlaya.Repository.Models.EdicionGrupo", "EdicionGrupo")
                        .WithMany("Equipos")
                        .HasForeignKey("EdicionGrupoId")
                        .HasConstraintName("FK_dbo.Equipo_dbo.EdicionGrupo_Id");

                    b.HasOne("VoleyPlaya.Repository.Models.Edicion", "Edicion")
                        .WithMany("Equipos")
                        .HasForeignKey("EdicionId")
                        .HasConstraintName("FK_dbo.Equipo_dbo.Edicion_Id");

                    b.Navigation("Edicion");

                    b.Navigation("EdicionGrupo");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Jornada", b =>
                {
                    b.HasOne("VoleyPlaya.Repository.Models.Edicion", "Edicion")
                        .WithMany("Jornadas")
                        .HasForeignKey("EdicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_dbo.EdicionJornada_Id");

                    b.Navigation("Edicion");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.ParcialPartido", b =>
                {
                    b.HasOne("VoleyPlaya.Repository.Models.Partido", "Partido")
                        .WithMany("Parciales")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_dbo.ParcialPartido_Id");

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Partido", b =>
                {
                    b.HasOne("VoleyPlaya.Repository.Models.Equipo", "Local")
                        .WithMany("Locales")
                        .HasForeignKey("EquipoLocalId")
                        .HasConstraintName("FK_dbo.PartidoLocal_Id");

                    b.HasOne("VoleyPlaya.Repository.Models.Equipo", "Visitante")
                        .WithMany("Visitantes")
                        .HasForeignKey("EquipoVisitanteId")
                        .HasConstraintName("FK_dbo.PartidoVisitante_Id");

                    b.HasOne("VoleyPlaya.Repository.Models.EdicionGrupo", "Grupo")
                        .WithMany("Partidos")
                        .HasForeignKey("GrupoId")
                        .HasConstraintName("FK_dbo.PartidoEdicion_Id");

                    b.Navigation("Grupo");

                    b.Navigation("Local");

                    b.Navigation("Visitante");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Categoria", b =>
                {
                    b.Navigation("Ediciones");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Competicion", b =>
                {
                    b.Navigation("Ediciones");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Edicion", b =>
                {
                    b.Navigation("Equipos");

                    b.Navigation("Grupos");

                    b.Navigation("Jornadas");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.EdicionGrupo", b =>
                {
                    b.Navigation("Equipos");

                    b.Navigation("Partidos");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Equipo", b =>
                {
                    b.Navigation("Locales");

                    b.Navigation("Visitantes");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Partido", b =>
                {
                    b.Navigation("Parciales");
                });

            modelBuilder.Entity("VoleyPlaya.Repository.Models.Temporada", b =>
                {
                    b.Navigation("Ediciones");
                });
#pragma warning restore 612, 618
        }
    }
}
