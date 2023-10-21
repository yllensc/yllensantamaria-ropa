using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVentaRepository
{
    private readonly ClothingDbContext _context;

    public DetalleVentaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
