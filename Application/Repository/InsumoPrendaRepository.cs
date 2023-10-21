using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InsumoPrendaRepository : GenericRepository<InsumoPrenda>, IInsumoPrendaRepository
{
    private readonly ClothingDbContext _context;

    public InsumoPrendaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
