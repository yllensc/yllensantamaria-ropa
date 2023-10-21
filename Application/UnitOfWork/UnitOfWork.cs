using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ClothingDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    private IUserRol _userole;
    private ICargoRepository _cargo;
    private IClienteRepository _cliente;
    private IColorRepository _color;
    private IDepartamentoRepository _departamento;
    private IDetalleOrdenRepository _detalleOrden;
    private IDetalleVentaRepository _detalleVenta;
    private IEmpleadoRepository _empleado;
    private IEmpresaRepository _empresa;
    private IEstadoRepository _estado;
    private IFormaPagoRepository _formaPago;
    private IGeneroRepository _genero;
    private IInsumoRepository _insumo;
    private IInsumoPrendaRepository _insumoPrenda;
    private IInventarioRepository _inventario;
    private IInventarioTallaRepository _inventarioTalla;
    private IMunicipioRepository _municipio;
    private IOrdenRepository _orden;
    private IPaisRepository _pais;
    private IPrendaRepository _prenda;
    private IProveedorRepository _proveedor;
    private ITallaRepository _talla;
    private ITipoPersonaRepository _tipoPersona;
    private ITipoProteccionRepository _tipoProteccion;
    private IVentaRepository _venta;

    
    public UnitOfWork(ClothingDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }
    public IUserRol UserRoles
    {
        get
        {
            if (_userole == null)
            {
                _userole = new UseroleRepository(_context);
            }
            return _userole;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    ICargoRepository IUnitOfWork.Cargos
    {
        get
        {
            if (_cargo == null)
            {
                _cargo = new CargoRepository(_context);
            }
            return _cargo;
        }
    }

    IClienteRepository IUnitOfWork.Clientes
     {
        get
        {
            if (_cliente == null)
            {
                _cliente = new ClienteRepository(_context);
            }
            return _cliente;
        }
    }
    IColorRepository IUnitOfWork.Colores  {
        get
        {
            if (_color == null)
            {
                _color = new ColorRepository(_context);
            }
            return _color;
        }
    }

    IDepartamentoRepository IUnitOfWork.Departamentos  {
        get
        {
            if (_departamento == null)
            {
                _departamento = new DepartamentoRepository(_context);
            }
            return _departamento;
        }
    }

    IDetalleOrdenRepository IUnitOfWork.DetalleOrdenes  {
        get
        {
            if (_detalleOrden == null)
            {
                _detalleOrden = new DetalleOrdenRepository(_context);
            }
            return _detalleOrden;
        }
    }

    IDetalleVentaRepository IUnitOfWork.DetalleVentas  {
        get
        {
            if (_detalleVenta == null)
            {
                _detalleVenta = new DetalleVentaRepository(_context);
            }
            return _detalleVenta;
        }
    }

    IEmpleadoRepository IUnitOfWork.Empleados  {
        get
        {
            if (_empleado == null)
            {
                _empleado = new EmpleadoRepository(_context);
            }
            return _empleado;
        }
    }

    IEmpresaRepository IUnitOfWork.Empresas  {
        get
        {
            if (_empresa == null)
            {
                _empresa = new EmpresaRepository(_context);
            }
            return _empresa;
        }
    }

    IEstadoRepository IUnitOfWork.Estados  {
        get
        {
            if (_estado == null)
            {
                _estado = new EstadoRepository(_context);
            }
            return _estado;
        }
    }

    IFormaPagoRepository IUnitOfWork.FormaPagos  {
        get
        {
            if (_formaPago == null)
            {
                _formaPago = new FormaPagoRepository(_context);
            }
            return _formaPago;
        }
    }

    IGeneroRepository IUnitOfWork.Generos  {
        get
        {
            if (_genero == null)
            {
                _genero = new GeneroRepository(_context);
            }
            return _genero;
        }
    }

    IInsumoRepository IUnitOfWork.Insumos  {
        get
        {
            if (_insumo == null)
            {
                _insumo = new InsumoRepository(_context);
            }
            return _insumo;
        }
    }

    IInsumoPrendaRepository IUnitOfWork.InsumoPrendas  {
        get
        {
            if (_insumoPrenda == null)
            {
                _insumoPrenda = new InsumoPrendaRepository(_context);
            }
            return _insumoPrenda;
        }
    }

    IInventarioRepository IUnitOfWork.Inventarios  {
        get
        {
            if (_inventario == null)
            {
                _inventario = new InventarioRepository(_context);
            }
            return _inventario;
        }
    }

    IInventarioTallaRepository IUnitOfWork.InventarioTallas  {
        get
        {
            if (_inventarioTalla == null)
            {
                _inventarioTalla = new InventarioTallaRepository(_context);
            }
            return _inventarioTalla;
        }
    }

    IMunicipioRepository IUnitOfWork.Municipios  {
        get
        {
            if (_municipio == null)
            {
                _municipio = new MunicipioRepository(_context);
            }
            return _municipio;
        }
    }

    IOrdenRepository IUnitOfWork.Ordenes  {
        get
        {
            if (_orden == null)
            {
                _orden = new OrdenRepository(_context);
            }
            return _orden;
        }
    }

    IPaisRepository IUnitOfWork.Paises  {
        get
        {
            if (_pais == null)
            {
                _pais = new PaisRepository(_context);
            }
            return _pais;
        }
    }

    IPrendaRepository IUnitOfWork.Prendas  {
        get
        {
            if (_prenda == null)
            {
                _prenda = new PrendaRepository(_context);
            }
            return _prenda;
        }
    }

    IProveedorRepository IUnitOfWork.Proveedores  {
        get
        {
            if (_proveedor == null)
            {
                _proveedor = new ProveedorRepository(_context);
            }
            return _proveedor;
        }
    }

    ITallaRepository IUnitOfWork.Tallas  {
        get
        {
            if (_talla == null)
            {
                _talla = new TallaRepository(_context);
            }
            return _talla;
        }
    }

    ITipoPersonaRepository IUnitOfWork.TipoPersonas  {
        get
        {
            if (_tipoPersona == null)
            {
                _tipoPersona = new TipoPersonaRepository(_context);
            }
            return _tipoPersona;
        }
    }

    ITipoProteccionRepository IUnitOfWork.TipoProtecciones  {
        get
        {
            if (_tipoProteccion == null)
            {
                _tipoProteccion = new TipoProteccionRepository(_context);
            }
            return _tipoProteccion;
        }
    }

    IVentaRepository IUnitOfWork.Ventas  {
        get
        {
            if (_venta == null)
            {
                _venta = new VentaRepository(_context);
            }
            return _venta;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    Task<int> IUnitOfWork.SaveAsync()
    {
        throw new NotImplementedException();
    }
}
