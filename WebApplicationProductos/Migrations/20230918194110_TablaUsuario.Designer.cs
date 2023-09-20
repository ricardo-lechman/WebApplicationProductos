﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationProductos.DAL.DataContext;

#nullable disable

namespace WebApplicationProductos.Migrations
{
    [DbContext(typeof(AplicatiosDbContext))]
    [Migration("20230918194110_TablaUsuario")]
    partial class TablaUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplicationProductos.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("WebApplicationProductos.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("Telefono")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebApplicationProductos.Models.DetalleDeVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Id_Factura")
                        .HasColumnType("int");

                    b.Property<int>("NumFactura")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DetalleDeVentas");
                });

            modelBuilder.Entity("WebApplicationProductos.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contenido")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreProducto")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<bool>("Stock")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("WebApplicationProductos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
