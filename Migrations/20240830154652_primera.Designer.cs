﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservasCarAPI.Context;

#nullable disable

namespace ReservasCarAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240830154652_primera")]
    partial class primera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReservasCarAPI.Models.Reservas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_usuario")
                        .HasColumnType("int");

                    b.Property<int>("Id_vechiculo")
                        .HasColumnType("int");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<int>("NroTarjeta")
                        .HasColumnType("int");

                    b.Property<DateTime>("VencimientoTarjeta")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id_usuario");

                    b.HasIndex("Id_vechiculo");

                    b.ToTable("reservas");
                });

            modelBuilder.Entity("ReservasCarAPI.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ReservasCarAPI.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_roles")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Id_roles");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ReservasCarAPI.Models.Vehiculos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CapacidadCarga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cilindrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Disponibilidad")
                        .HasColumnType("int");

                    b.Property<string>("Gama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Modelo")
                        .HasColumnType("int");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<string>("Procedencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puertas")
                        .HasColumnType("int");

                    b.Property<string>("Traccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("vehiculos");
                });

            modelBuilder.Entity("ReservasCarAPI.Models.Reservas", b =>
                {
                    b.HasOne("ReservasCarAPI.Models.Usuarios", "usuarios")
                        .WithMany()
                        .HasForeignKey("Id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservasCarAPI.Models.Vehiculos", "Vehiculos")
                        .WithMany()
                        .HasForeignKey("Id_vechiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculos");

                    b.Navigation("usuarios");
                });

            modelBuilder.Entity("ReservasCarAPI.Models.Usuarios", b =>
                {
                    b.HasOne("ReservasCarAPI.Models.Roles", "roles")
                        .WithMany()
                        .HasForeignKey("Id_roles")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}
