using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta : BaseEntity
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        public int IdFormaPago { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; } 
        public FormaPago FormaPago { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}