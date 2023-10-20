using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("Orden");
        builder.Property(p => p.Fecha)
        .IsRequired();
       builder.HasOne(p => p.Empleado)
            .WithMany(f => f.Ordenes)
            .HasForeignKey(fk => fk.IdEmpleado)
            .IsRequired();
        builder.HasOne(p => p.Cliente)
            .WithMany(f => f.Ordenes)
            .HasForeignKey(fk => fk.IdCliente)
            .IsRequired();
        builder.HasOne(p => p.Estado)
            .WithMany(f => f.Ordenes)
            .HasForeignKey(fk => fk.IdEstado)
            .IsRequired();
    }
}