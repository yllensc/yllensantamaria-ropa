using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVentaRepository
{
    private readonly ClothingDbContext _context;

    public VentaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
