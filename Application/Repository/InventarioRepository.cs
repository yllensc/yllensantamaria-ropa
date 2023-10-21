using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InventarioRepository : GenericRepository<Inventario>, IInventarioRepository
{
    private readonly ClothingDbContext _context;

    public InventarioRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
