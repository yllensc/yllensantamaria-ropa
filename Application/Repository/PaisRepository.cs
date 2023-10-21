using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PaisRepository : GenericRepository<Pais>, IPaisRepository
{
    private readonly ClothingDbContext _context;

    public PaisRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
