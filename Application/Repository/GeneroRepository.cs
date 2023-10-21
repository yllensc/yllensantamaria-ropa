using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
{
    private readonly ClothingDbContext _context;

    public GeneroRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
