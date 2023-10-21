using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    private readonly ClothingDbContext _context;

    public ClienteRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
