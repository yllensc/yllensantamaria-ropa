using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class FormaPagoRepository : GenericRepository<FormaPago>, IFormaPagoRepository
{
    private readonly ClothingDbContext _context;

    public FormaPagoRepository(ClothingDbContext context) : base(context)
    {
       _context = context;
    }
}
