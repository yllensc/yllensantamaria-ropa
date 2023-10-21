using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MunicipioDto
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public int IdDep { get; set; }
        public ICollection<ClienteDto> Clientes { get; set; }
        public ICollection<ProveedorDto> Proveedores { get; set; }
        public ICollection<EmpleadoDto> Empleados { get; set; }
    }
}