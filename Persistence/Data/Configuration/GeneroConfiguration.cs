using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("Genero");
        builder.Property(p => p.Descripcion)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Descripcion)
            .IsUnique();
    }
}