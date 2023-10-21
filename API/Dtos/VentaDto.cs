using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VentaDto
    {
        public int Id {get; set;}
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        public int IdFormaPago { get; set; }
        public EmpleadoDto Empleado { get; set; }
        public ClienteDto Cliente { get; set; } 
        public string FormaPago { get; set; }
        public ICollection<DetalleVentaDto> DetalleVentas { get; set; }
    }
}