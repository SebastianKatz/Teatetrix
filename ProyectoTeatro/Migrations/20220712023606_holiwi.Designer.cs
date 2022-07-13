﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoTeatro.Context;

namespace ProyectoTeatro.Migrations
{
    [DbContext(typeof(TeatroDbContext))]
    [Migration("20220712023606_holiwi")]
    partial class holiwi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoTeatro.Models.Butaca", b =>
                {
                    b.Property<int>("IdButaca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaOcupada")
                        .HasColumnType("bit");

                    b.Property<int>("NroButaca")
                        .HasColumnType("int");

                    b.Property<int?>("ObraIdObra")
                        .HasColumnType("int");

                    b.HasKey("IdButaca");

                    b.HasIndex("ObraIdObra");

                    b.ToTable("Butacas");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.ButacaReserva", b =>
                {
                    b.Property<int>("IdButacaReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdObra")
                        .HasColumnType("int");

                    b.Property<int>("IdReserva")
                        .HasColumnType("int");

                    b.Property<int>("NroButaca")
                        .HasColumnType("int");

                    b.HasKey("IdButacaReserva");

                    b.ToTable("ButacaReserva");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NroButaca")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.Obra", b =>
                {
                    b.Property<int>("IdObra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdObra");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaObra")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdObra")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("ObraIdObra")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("ObraIdObra");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.Butaca", b =>
                {
                    b.HasOne("ProyectoTeatro.Models.Obra", "Obra")
                        .WithMany("Butacas")
                        .HasForeignKey("ObraIdObra");
                });

            modelBuilder.Entity("ProyectoTeatro.Models.Reserva", b =>
                {
                    b.HasOne("ProyectoTeatro.Models.Obra", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraIdObra");
                });
#pragma warning restore 612, 618
        }
    }
}
