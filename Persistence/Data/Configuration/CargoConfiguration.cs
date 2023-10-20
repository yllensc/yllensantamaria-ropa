using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
{
    public void Configure(EntityTypeBuilder<Cargo> builder)
    {
        builder.ToTable("Cargo");
        builder.Property(p => p.Descripcion)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Descripcion)
            .IsUnique();
        builder.Property(p => p.SueldoBase)
        .IsRequired();

    }
}