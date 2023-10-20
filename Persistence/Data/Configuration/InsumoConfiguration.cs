using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("Insumo");
        builder.Property(p => p.Nombre)
        .HasMaxLength(50)
        .IsRequired();
        builder.HasIndex(p => p.Nombre)
            .IsUnique();
        builder.Property(p => p.StockMin)
        .IsRequired();
        builder.Property(p => p.StockMax)
        .IsRequired();
        builder.HasOne(p => p.Proveedor)
            .WithMany(f => f.Insumos)
            .HasForeignKey(fk => fk.IdProveedor)
            .IsRequired();
        builder
           .HasMany(p => p.Prendas)
           .WithMany(r => r.Insumos)
           .UsingEntity<InsumoPrenda>(
               j => j
               .HasOne(pt => pt.Prenda)
               .WithMany(t => t.InsumoPrendas)
               .HasForeignKey(ut => ut.IdPrenda),
               j => j
               .HasOne(et => et.Insumo)
               .WithMany(et => et.InsumoPrendas)
               .HasForeignKey(el => el.IdInsumo),
               j =>
               {
                   j.ToTable("InsumoPrenda");
                   j.HasKey(t => new { t.IdInsumo, t.IdPrenda });
                   j.Property(p => p.Cantidad)
                   .IsRequired();
               });
        }
}