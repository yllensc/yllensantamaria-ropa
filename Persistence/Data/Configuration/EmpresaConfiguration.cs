using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("Empresa");
        builder.Property(p => p.Nit)
        .HasMaxLength(20)
        .IsRequired();
        builder.HasIndex(p => p.Nit)
            .IsUnique();
        builder.Property(p => p.RazonSocial)
        .HasMaxLength(100)
        .IsRequired();
        builder.Property(p => p.RepresentanteLegal)
        .HasMaxLength(100)
        .IsRequired();
        builder.Property(p => p.FechaCreacion)
        .IsRequired();
        builder.HasOne(p => p.Municipio)
            .WithMany(f => f.Empresas)
            .HasForeignKey(fk => fk.IdMunicipio)
            .IsRequired();
    }
}