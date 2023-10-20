using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class TallaConfiguration : IEntityTypeConfiguration<Talla>
{
    public void Configure(EntityTypeBuilder<Talla> builder)
    {
        builder.ToTable("Talla");
        builder.Property(p => p.Descripcion)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Descripcion)
            .IsUnique();
    }
}