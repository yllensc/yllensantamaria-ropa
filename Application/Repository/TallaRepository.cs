using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TallaRepository : GenericRepository<Talla>, ITallaRepository
{
    private readonly ClothingDbContext _context;

    public TallaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
