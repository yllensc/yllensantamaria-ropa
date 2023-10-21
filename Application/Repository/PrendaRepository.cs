using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PrendaRepository : GenericRepository<Prenda>, IPrendaRepository
{
    private readonly ClothingDbContext _context;

    public PrendaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
