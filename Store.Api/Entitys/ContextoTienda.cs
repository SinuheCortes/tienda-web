using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Store.Api.Entitys;

public partial class ContextoTienda : DbContext
{
    public ContextoTienda()
    {
    }

    public ContextoTienda(DbContextOptions<ContextoTienda> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticuloTienda> ArticuloTienda { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<Tienda> Tienda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=tiendabd;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Articulo__06370DAD3E82CC90");

            entity.ToTable("Articulo");

            entity.Property(e => e.Codigo).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1200)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<ArticuloTienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Articulo__3214EC077215DE22");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ArticuloT__IdArt__412EB0B6");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ArticuloT__IdTie__4222D4EF");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cliente__3214EC079EE6BEEC");

            entity.ToTable("Cliente");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClienteA__3214EC079DF99FC6");

            entity.ToTable("ClienteArticulo");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClienteAr__IdArt__47DBAE45");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClienteAr__IdCli__46E78A0C");
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tienda__3214EC07E2FA07CF");

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
