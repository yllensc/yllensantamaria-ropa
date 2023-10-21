using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
{
    private readonly ClothingDbContext _context;

    public ProveedorRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
