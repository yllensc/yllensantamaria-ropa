using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estado");
        builder.Property(p => p.Codigo)
        .HasMaxLength(20)
        .IsRequired();
        builder.HasIndex(p => p.Codigo)
            .IsUnique();
        builder.Property(p => p.CodigoDescripcion)
        .IsRequired();
    }
}