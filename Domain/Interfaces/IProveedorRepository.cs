using Domain.Entities;

namespace Domain.Interfaces;

    public interface IProveedorRepository : IGenericRepository<Proveedor> { 
        Task<IEnumerable<Proveedor>> GetTypePerson(string tipoPersona);
    }

