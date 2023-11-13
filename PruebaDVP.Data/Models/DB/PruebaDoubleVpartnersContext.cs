using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaDVP.Data.Models.DB;

public partial class PruebaDoubleVpartnersContext : DbContext
{
    public PruebaDoubleVpartnersContext()
    {
    }

    public PruebaDoubleVpartnersContext(DbContextOptions<PruebaDoubleVpartnersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Identificador);

            entity.ToTable("Persona");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(50);

            entity.HasOne(d => d.TipoIdentificacionNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.TipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_TipoIdentificacion");
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.Identificador).HasName("PK_TipoIdenficacion");

            entity.ToTable("TipoIdentificacion");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Identificador);

            entity.ToTable("Usuario");

            entity.Property(e => e.Identificador).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);

            entity.HasOne(d => d.IdentificadorNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.Identificador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
