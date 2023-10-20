using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("Inventario");
        builder.Property(p => p.ValorVtaCop)
        .IsRequired();
        builder.Property(p => p.ValorVtaUsd)
        .IsRequired();
        builder.HasOne(p => p.Prenda)
            .WithMany(f => f.Inventarios)
            .HasForeignKey(fk => fk.IdPrenda)
            .IsRequired();
        builder
           .HasMany(p => p.Tallas)
           .WithMany(r => r.Inventarios)
           .UsingEntity<InventarioTalla>(
               j => j
               .HasOne(pt => pt.Talla)
               .WithMany(t => t.InventarioTallas)
               .HasForeignKey(ut => ut.IdTalla),
               j => j
               .HasOne(et => et.Inventario)
               .WithMany(et => et.InventarioTallas)
               .HasForeignKey(el => el.IdInv),
               j =>
               {
                   j.ToTable("InventarioTalla");
                   j.HasKey(t => new { t.IdInv, t.IdTalla });
                   j.Property(p => p.Cantidad)
                   .IsRequired();
               });
    }
}