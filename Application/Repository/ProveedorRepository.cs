using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
{
    private readonly ClothingDbContext _context;

    public ProveedorRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<Proveedor>> GetTypePerson(string tipoPersona){
        return await _context.Proveedores
                .Include(p=> p.TipoPersona)
                .Where(p => p.TipoPersona.Nombre == tipoPersona)
                .ToListAsync();
    }
}
