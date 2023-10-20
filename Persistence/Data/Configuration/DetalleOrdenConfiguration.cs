using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("DetalleOrden");
        builder.Property(p => p.CantidadAProducir)
        .IsRequired();
        builder.Property(p => p.CantidadProducida)
        .IsRequired();
        builder.HasOne(p => p.Orden)
            .WithMany(f => f.DetalleOrdenes)
            .HasForeignKey(fk => fk.IdOrden)
            .IsRequired();
        builder.HasOne(p => p.Prenda)
            .WithMany(f => f.DetalleOrdenes)
            .HasForeignKey(fk => fk.IdPrenda)
            .IsRequired();
        builder.HasOne(p => p.Color)
            .WithMany(f => f.DetalleOrdenes)
            .HasForeignKey(fk => fk.IdColor)
            .IsRequired();
        builder.HasOne(p => p.Estado)
            .WithMany(f => f.DetalleOrdenes)
            .HasForeignKey(fk => fk.IdEstado)
            .IsRequired();
    }
}