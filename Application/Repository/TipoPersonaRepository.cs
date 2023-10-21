using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersonaRepository
{
    private readonly ClothingDbContext _context;

    public TipoPersonaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
