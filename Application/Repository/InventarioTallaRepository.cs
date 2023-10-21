using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InventarioTallaRepository : GenericRepository<InventarioTalla>, IInventarioTallaRepository
{
    private readonly ClothingDbContext _context;

    public InventarioTallaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
