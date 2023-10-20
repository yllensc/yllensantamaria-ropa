using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly ClothingDbContext _context;

    public RolRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
