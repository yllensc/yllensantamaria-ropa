using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("DetalleVenta");
        builder.Property(p => p.Cantidad)
        .IsRequired();
        builder.Property(p => p.ValorUnit)
        .IsRequired();
        builder.HasOne(p => p.Venta)
            .WithMany(f => f.DetalleVentas)
            .HasForeignKey(fk => fk.IdVenta)
            .IsRequired();
        builder.HasOne(p => p.Inventario)
            .WithMany(f => f.DetalleVentas)
            .HasForeignKey(fk => fk.IdInventario)
            .IsRequired();
        builder.HasOne(p => p.Talla)
            .WithMany(f => f.DetalleVentas)
            .HasForeignKey(fk => fk.IdTalla)
            .IsRequired();
    }
}