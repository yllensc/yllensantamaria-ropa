using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoRepository
{
    private readonly ClothingDbContext _context;

    public DepartamentoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
