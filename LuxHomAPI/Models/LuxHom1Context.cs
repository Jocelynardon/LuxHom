using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LuxHomAPI.Models;

public partial class LuxHom1Context : DbContext
{
    public LuxHom1Context()
    {
    }

    public LuxHom1Context(DbContextOptions<LuxHom1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticuloPrefabricado> ArticuloPrefabricados { get; set; }

    public virtual DbSet<Publicacion> Publicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)

        {

            IConfigurationRoot configuration = new ConfigurationBuilder()

            .SetBasePath(Directory.GetCurrentDirectory())

                        .AddJsonFile("appsettings.json")

                        .Build();

            var connectionString = configuration.GetConnectionString("ConnectionDB");

            optionsBuilder.UseMySQL(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticuloPrefabricado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("articulo_prefabricado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasPrecision(10)
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Publicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usuario1).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Usuario1)
                .HasMaxLength(500)
                .HasColumnName("usuario");
            entity.Property(e => e.ApellidoCasada)
                .HasMaxLength(500)
                .HasColumnName("apellido_casada");
            entity.Property(e => e.Direccion)
                .HasMaxLength(700)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(500)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(1000)
                .HasColumnName("nombres");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
            entity.Property(e => e.PrimerAppelido)
                .HasMaxLength(500)
                .HasColumnName("primer_appelido");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(500)
                .HasColumnName("segundo_apellido");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
