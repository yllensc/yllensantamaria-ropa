using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DetalleOrdenRepository : GenericRepository<DetalleOrden>, IDetalleOrdenRepository
{
    private readonly ClothingDbContext _context;

    public DetalleOrdenRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
