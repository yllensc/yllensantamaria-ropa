using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PrendaRepository : GenericRepository<Prenda>, IPrendaRepository
{
    private readonly ClothingDbContext _context;

    public PrendaRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<IEnumerable<Prenda>> GetAllAsync()
    {
        return await _context.Prendas
            .Include(p => p.Estado)
            .Include(p => p.TipoProteccion)
            .Include(p => p.Genero)
            .ToListAsync();
    }
    public async Task<IEnumerable<object>> GetOrderInProduction(int numOrder){
        var prendas = await _context.Prendas.Include(p => p.Estado)
            .Include(p => p.TipoProteccion)
            .Include(p => p.Genero)
            .ToListAsync();
        var orden = await _context.Ordenes.Include(p => p.Estado).ToListAsync();
        var detalleOrden = await _context.DetalleOrdenes.ToArrayAsync();
        var resultado = prendas
                        .GroupJoin(detalleOrden, d => d.Id, p => p.IdOrden, 
                        (prenda, ordenDetalle) => new {
                            Prenda = prenda,
                            OrdenDetalle = ordenDetalle
                            .Join(orden, det => det.IdOrden, or => or.Id,
                             (prenda, ordenId) => new {
                                Prenda = prenda,
                                OrdenId = ordenId.Id,
                                OrdenEstado = ordenId.Estado.CodigoDescripcion
                             }).Where(o => o.OrdenId == numOrder && o.OrdenEstado == "Produccion").ToList()
                        }).ToList();
    return resultado;
   }
     public async Task<IEnumerable<object>> GetTypeProtectionGroup()
{
    var prendas = await _context.TipoProtecciones
        .Include(p => p.Prendas)
        .GroupBy(g => g.Descripcion)
        .Select(u => new
        {
            TipoProteccion = u.Key
        })
        .ToListAsync();

    return prendas;
}

}
