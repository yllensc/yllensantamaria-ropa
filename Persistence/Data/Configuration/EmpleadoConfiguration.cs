using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("Empleado");
        builder.Property(p => p.Nombre)
        .HasMaxLength(100)
        .IsRequired();
        builder.Property(p => p.FechaIngreso)
        .HasMaxLength(100)
        .IsRequired();
        builder.HasOne(p => p.Municipio)
            .WithMany(f => f.Empleados)
            .HasForeignKey(fk => fk.IdMunicipio)
            .IsRequired();
        builder.HasOne(p => p.Cargo)
            .WithMany(f => f.Empleados)
            .HasForeignKey(fk => fk.IdCargo)
            .IsRequired();
        builder.HasOne(p => p.User)
            .WithMany(f => f.Empleados)
            .HasForeignKey(fk => fk.IdUser)
            .IsRequired();
    }
}