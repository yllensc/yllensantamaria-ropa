using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Venta");
        builder.Property(p => p.Fecha)
        .IsRequired();
        builder.HasOne(p => p.Empleado)
            .WithMany(f => f.Ventas)
            .HasForeignKey(fk => fk.IdEmpleado)
            .IsRequired();
        builder.HasOne(p => p.Cliente)
            .WithMany(f => f.Ventas)
            .HasForeignKey(fk => fk.IdCliente)
            .IsRequired();
        builder.HasOne(p => p.FormaPago)
            .WithMany(f => f.Ventas)
            .HasForeignKey(fk => fk.IdFormaPago)
            .IsRequired();
    }
}