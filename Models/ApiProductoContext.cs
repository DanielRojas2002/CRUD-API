using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models;

public partial class ApiProductoContext : DbContext
{
    public ApiProductoContext()
    {
    }

    public ApiProductoContext(DbContextOptions<ApiProductoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DANIELROJAS; Database=API_PRODUCTO; Trusted_Connection=True;  Encrypt=False ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__09889210C688AB6D");

            entity.ToTable("PRODUCTO");

            entity.HasIndex(e => e.CodigoBarra, "UQ__PRODUCTO__F504A763B78CA197").IsUnique();

            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
