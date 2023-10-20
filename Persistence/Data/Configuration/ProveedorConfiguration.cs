using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("Proveedor");
        builder.Property(p => p.NitProveedor)
        .HasMaxLength(20)
        .IsRequired();
        builder.HasIndex(p => p.NitProveedor)
            .IsUnique();
        builder.Property(p => p.Nombre)
        .HasMaxLength(150)
        .IsRequired();
        builder.HasOne(p => p.TipoPersona)
            .WithMany(f => f.Proveedores)
            .HasForeignKey(fk => fk.IdTipoPersona)
            .IsRequired();
        builder.HasOne(p => p.Municipio)
            .WithMany(f => f.Proveedores)
            .HasForeignKey(fk => fk.IdMunicipio)
            .IsRequired();
    }
}