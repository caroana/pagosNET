using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pagos.Models;

public partial class PagosContext : DbContext
{
    public PagosContext()
    {
    }

    public PagosContext(DbContextOptions<PagosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comercio> Comercios { get; set; }

    public virtual DbSet<Transaccione> Transacciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see  For more guidance on storing connection strings, see 
            //        => optionsBuilder.UseSqlServer("server=localhost; database=pagos; integrated security=true; trustServerCertificate=false; Encrypt=false");
        }

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comercio>(entity =>
        {
            entity.HasKey(e => e.CodigoComercio).HasName("PK__Comercio__E01DE7B8DC8E9F1B");

            entity.HasIndex(e => e.Nit, "IX_Comercio_NIT");

            entity.HasIndex(e => e.Nombre, "IX_Comercio_Nombre");

            entity.HasIndex(e => e.CodigoComercio, "PK_Comercio_Codigo");

            entity.HasIndex(e => e.CodigoComercio, "UQ__Comercio__E01DE7B9FC3E4AFA").IsUnique();

            entity.Property(e => e.CodigoComercio).ValueGeneratedNever();
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaccione>(entity =>
        {
            entity.HasKey(e => e.CodigoTransaccion).HasName("PK__Transacc__A7EC8DDF00F14620");

            entity.HasIndex(e => e.CodigoTransaccion, "UQ__Transacc__A7EC8DDE1BC3ABD6").IsUnique();

            entity.HasIndex(e => e.CodigoTransaccion, "idx_CodigoTransaccion");

            entity.HasIndex(e => e.Fecha, "idx_Fecha");

            entity.HasIndex(e => e.CodigoComercio, "idx_IDComercio");

            entity.HasIndex(e => e.Idusuario, "idx_IDUsuario");

            entity.Property(e => e.CodigoTransaccion).ValueGeneratedNever();
            entity.Property(e => e.Concepto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Idusuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDUsuario");

            entity.HasOne(d => d.CodigoComercioNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.CodigoComercio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__Codig__403A8C7D");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacci__IDUsu__412EB0B6");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuarios__523111691FD0D615");

            entity.HasIndex(e => e.Idusuario, "UQ__Usuarios__5231116871199898").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__6B0F5AE0D17C415E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105349139D477").IsUnique();

            entity.HasIndex(e => e.Idusuario, "idx_IDUsuario");

            entity.HasIndex(e => e.NombreUsuario, "idx_NombreUsuario");

            entity.Property(e => e.Idusuario)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IDUsuario");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
