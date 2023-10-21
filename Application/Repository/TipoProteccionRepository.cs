using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TipoProteccionRepository : GenericRepository<TipoProteccion>, ITipoProteccionRepository
{
    private readonly ClothingDbContext _context;

    public TipoProteccionRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
