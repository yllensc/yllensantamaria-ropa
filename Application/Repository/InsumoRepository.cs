using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class InsumoRepository : GenericRepository<Insumo>, IInsumoRepository
{
    private readonly ClothingDbContext _context;

    public InsumoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
