using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("Prenda");
        builder.Property(p => p.Nombre)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Nombre)
            .IsUnique();
        builder.Property(p => p.ValorUnitCop)
        .IsRequired();
        builder.Property(p => p.ValorUnitUsd)
        .IsRequired();
        builder.HasOne(p => p.Estado)
            .WithMany(f => f.Prendas)
            .HasForeignKey(fk => fk.IdEstado)
            .IsRequired();
        builder.HasOne(p => p.TipoProteccion)
            .WithMany(f => f.Prendas)
            .HasForeignKey(fk => fk.IdTipoProteccion)
            .IsRequired();
        builder.HasOne(p => p.Genero)
            .WithMany(f => f.Prendas)
            .HasForeignKey(fk => fk.IdGenero)
            .IsRequired();
    }
}