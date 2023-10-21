using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
{
    private readonly ClothingDbContext _context;

    public EmpresaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
