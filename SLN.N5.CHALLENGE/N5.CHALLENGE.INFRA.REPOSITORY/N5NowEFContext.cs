using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using N5.CHALLENGE.DOMAIN.Entities;

namespace N5.CHALLENGE.INFRA.REPOSITORY
{
    public class N5NowEFContext : DbContext
    {
        public N5NowEFContext()
        {
        }

        public N5NowEFContext(DbContextOptions<N5NowEFContext> options)
            : base(options)
        {
        }

        public DbSet<Permiso> Permisos { get; set; } = null!;
        public DbSet<TipoPermiso> TipoPermisos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.ApellidoEmpleado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPermiso).HasColumnType("datetime");

                entity.Property(e => e.NombreEmpleado)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.ToTable("TipoPermiso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

        }

    }
}
