using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    IUserRol UserRoles {get; }
    ICargoRepository Cargos { get; }
    IClienteRepository Clientes { get; }
    IColorRepository Colores { get; }
    IDepartamentoRepository Departamentos { get; }
    IDetalleOrdenRepository DetalleOrdenes { get; }
    IDetalleVentaRepository DetalleVentas { get; }
    IEmpleadoRepository Empleados { get; }
    IEmpresaRepository Empresas { get; }
    IEstadoRepository Estados { get; }
    IFormaPagoRepository FormaPagos { get; }
    IGeneroRepository Generos { get; }
    IInsumoRepository Insumos { get; }
    IInsumoPrendaRepository InsumoPrendas { get; }
    IInventarioRepository Inventarios { get; }
    IInventarioTallaRepository InventarioTallas { get; }
    IMunicipioRepository Municipios { get; }
    IOrdenRepository Ordenes { get; }
    IPaisRepository Paises { get; }
    IPrendaRepository Prendas { get; }
    IProveedorRepository Proveedores { get; }
    ITallaRepository Tallas { get; }
    ITipoPersonaRepository TipoPersonas { get; }
    ITipoProteccionRepository TipoProtecciones { get; }
    IVentaRepository Ventas { get; }
    Task<int> SaveAsync();

}
