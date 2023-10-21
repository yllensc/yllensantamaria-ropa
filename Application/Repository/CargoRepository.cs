using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
{
    private readonly ClothingDbContext _context;

    public CargoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
