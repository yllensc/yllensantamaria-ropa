using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class MunicipioRepository : GenericRepository<Municipio>, IMunicipioRepository
{
    private readonly ClothingDbContext _context;

    public MunicipioRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
