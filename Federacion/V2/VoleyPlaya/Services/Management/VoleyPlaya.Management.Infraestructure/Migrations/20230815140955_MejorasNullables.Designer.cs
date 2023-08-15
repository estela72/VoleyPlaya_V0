﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoleyPlaya.Management.Infraestructure.Persistence;

#nullable disable

namespace VoleyPlaya.Management.Infraestructure.Migrations
{
    [DbContext(typeof(VoleyPlayaManagementContext))]
    [Migration("20230815140955_MejorasNullables")]
    partial class MejorasNullables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Edicion", b =>
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int?>("ModeloCompeticion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Prueba")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TemporadaId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CompeticionId");

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.HasIndex("TemporadaId", "CompeticionId", "CategoriaId", "Genero", "Prueba")
                        .IsUnique();

                    b.ToTable("Ediciones");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.EdicionGrupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdicionId")
                        .HasColumnType("int");

                    b.Property<int>("Fase")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EdicionId", "Nombre")
                        .IsUnique();

                    b.ToTable("EdicionGrupos");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Jornada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdicionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EdicionId");

                    b.ToTable("Jornada");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Parcial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartidoId")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoLocal")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoVisitante")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PartidoId");

                    b.ToTable("Parcial");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("ConResultado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EdicionGrupoId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoLocalId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoVisitanteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("JornadaId")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreLocal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreVisitante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumPartido")
                        .HasColumnType("int");

                    b.Property<string>("Pista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResultadoLocal")
                        .HasColumnType("int");

                    b.Property<int?>("ResultadoVisitante")
                        .HasColumnType("int");

                    b.Property<string>("Ronda")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .IsConcurrencyToken()
                        .HasColumnType("datetime2");

                    b.Property<string>("UserResultado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("UserValidador")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<bool?>("Validado")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("(CONVERT([bit],(0)))");

                    b.HasKey("Id");

                    b.HasIndex("EdicionGrupoId");

                    b.HasIndex("EquipoLocalId");

                    b.HasIndex("EquipoVisitanteId");

                    b.HasIndex("JornadaId");

                    b.HasIndex("Label")
                        .IsUnique();

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.EdicionGrupo", b =>
                {
                    b.HasOne("VoleyPlaya.Management.Domain.Edicion", "Edicion")
                        .WithMany("EdicionGrupos")
                        .HasForeignKey("EdicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Edicion");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Jornada", b =>
                {
                    b.HasOne("VoleyPlaya.Management.Domain.Edicion", "Edicion")
                        .WithMany("Jornada")
                        .HasForeignKey("EdicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Edicion");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Parcial", b =>
                {
                    b.HasOne("VoleyPlaya.Management.Domain.Partido", "Partido")
                        .WithMany("Parciales")
                        .HasForeignKey("PartidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partido");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Partido", b =>
                {
                    b.HasOne("VoleyPlaya.Management.Domain.EdicionGrupo", "EdicionGrupo")
                        .WithMany("Partidos")
                        .HasForeignKey("EdicionGrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VoleyPlaya.Management.Domain.Jornada", "Jornada")
                        .WithMany()
                        .HasForeignKey("JornadaId");

                    b.Navigation("EdicionGrupo");

                    b.Navigation("Jornada");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Edicion", b =>
                {
                    b.Navigation("EdicionGrupos");

                    b.Navigation("Jornada");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.EdicionGrupo", b =>
                {
                    b.Navigation("Partidos");
                });

            modelBuilder.Entity("VoleyPlaya.Management.Domain.Partido", b =>
                {
                    b.Navigation("Parciales");
                });
#pragma warning restore 612, 618
        }
    }
}
