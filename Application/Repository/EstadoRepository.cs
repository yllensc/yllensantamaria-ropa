using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EstadoRepository : GenericRepository<Estado>, IEstadoRepository
{
    private readonly ClothingDbContext _context;

    public EstadoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
