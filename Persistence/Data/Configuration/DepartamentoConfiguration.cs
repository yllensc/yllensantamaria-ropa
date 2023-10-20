using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");
        builder.Property(p => p.Nombre)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Nombre)
            .IsUnique();
        builder.HasOne(p => p.Pais)
            .WithMany(f => f.Departamentos)
            .HasForeignKey(fk => fk.IdPais)
            .IsRequired();
    }
}