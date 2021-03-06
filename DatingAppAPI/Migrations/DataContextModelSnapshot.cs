﻿// <auto-generated />
using System;
using DatingAppAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatingAppAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("DatingAppAPI.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("EsPrincipal");

                    b.Property<DateTime>("FechaCarga");

                    b.Property<string>("Nombre");

                    b.Property<string>("Url");

                    b.Property<int>("usuarioID");

                    b.HasKey("Id");

                    b.HasIndex("usuarioID");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("DatingAppAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alias");

                    b.Property<string>("Buscando");

                    b.Property<string>("Ciudad");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<DateTime>("FechaUltimoIngreso");

                    b.Property<string>("Genero");

                    b.Property<string>("Interes");

                    b.Property<string>("Pais");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Presentacion");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DatingAppAPI.Models.Valor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Valores");
                });

            modelBuilder.Entity("DatingAppAPI.Models.Foto", b =>
                {
                    b.HasOne("DatingAppAPI.Models.Usuario", "Usuario")
                        .WithMany("Fotos")
                        .HasForeignKey("usuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
