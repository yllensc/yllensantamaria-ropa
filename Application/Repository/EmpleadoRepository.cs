using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    private readonly ClothingDbContext _context;

    public EmpleadoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
