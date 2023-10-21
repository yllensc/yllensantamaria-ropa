using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    private readonly ClothingDbContext _context;

    public EmpleadoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .Include(p => p.Cargo)
            .Include(P => P.Ordenes).ThenInclude(p => p.DetalleOrdenes)
            .ToListAsync();
    }
    public override async Task<(int totalRecords, IEnumerable<Empleado> records)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;

        if (!String.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRecords = await query.CountAsync();
        var records = await query
            .Include(p => p.Cargo)
            .Include(P => P.Ordenes).ThenInclude(p => p.DetalleOrdenes)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRecords, records);
    }
}
