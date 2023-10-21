using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class OrdenRepository : GenericRepository<Orden>, IOrdenRepository
{
    private readonly ClothingDbContext _context;

    public OrdenRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }

}
