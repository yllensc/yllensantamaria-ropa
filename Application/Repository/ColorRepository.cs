using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ColorRepository : GenericRepository<Color>, IColorRepository
{
    private readonly ClothingDbContext _context;

    public ColorRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
