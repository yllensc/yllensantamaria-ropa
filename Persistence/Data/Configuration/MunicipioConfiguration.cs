using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("Municipio");
        builder.Property(p => p.Nombre)
        .HasMaxLength(100)
        .IsRequired();
        builder.HasIndex(p => p.Nombre)
            .IsUnique();
        builder.HasOne(p => p.Departamento)
            .WithMany(f => f.Municipios)
            .HasForeignKey(fk => fk.IdDep)
            .IsRequired();
    }
}