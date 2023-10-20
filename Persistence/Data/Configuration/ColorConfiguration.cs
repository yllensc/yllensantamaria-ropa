using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Color");
        builder.Property(p => p.Descripcion)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Descripcion)
            .IsUnique();
    }
}