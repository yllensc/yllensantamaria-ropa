using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class FormaPagoConfiguration : IEntityTypeConfiguration<FormaPago>
{
    public void Configure(EntityTypeBuilder<FormaPago> builder)
    {
        builder.ToTable("FormaPago");
        builder.Property(p => p.Descripcion)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Descripcion)
            .IsUnique();
    }
}