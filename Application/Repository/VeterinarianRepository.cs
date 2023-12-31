using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

/*namespace Application.Repository;
public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    private readonly ClothingDbContext _context;

    public EmpleadoRepository(ClothingDbContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRecords, IEnumerable<Empleado> records)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRecords = await query.CountAsync();
        var records = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRecords, records);
    }

    public async Task<IEnumerable<Empleado>> GetCardiovascularSurgeonAsync()
    {
        return await _context.Empleados
                            .Where(p => p.Specialty.ToLower() == "cirugía vascular")
                            .ToListAsync();
    }

    public async Task<(int totalRecords, IEnumerable<Empleado> records)> GetCardiovascularSurgeonAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Empleados as IQueryable<Empleado>;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Name.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRecords = await query.CountAsync();
        var records = await query
            .Where(p => p.Specialty.ToLower() == "cirugía vascular")
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRecords, records);
    }
}
*/