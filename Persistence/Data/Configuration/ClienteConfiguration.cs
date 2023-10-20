using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.Property(p => p.Nombre)
        .HasMaxLength(100)
        .IsRequired();
        builder.Property(p => p.FechaRegistro)
        .IsRequired();
        builder.HasOne(p => p.TipoPersona)
            .WithMany(f => f.Clientes)
            .HasForeignKey(fk => fk.IdTipoPersona)
            .IsRequired();
        builder.HasOne(p => p.Municipio)
            .WithMany(f => f.Clientes)
            .HasForeignKey(fk => fk.IdMunicipio)
            .IsRequired();
    }
}