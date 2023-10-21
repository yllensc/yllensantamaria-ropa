using Domain.Entities;

namespace Domain.Interfaces;

    public interface IPrendaRepository : IGenericRepository<Prenda> { 
        Task<IEnumerable<object>> GetOrderInProduction(int numOrder);
        Task<IEnumerable<object>> GetTypeProtectionGroup();
    }

