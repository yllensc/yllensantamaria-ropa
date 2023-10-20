using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Orden : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }
        public int IdEstado { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public Estado Estado { get; set; } 
        public ICollection<DetalleOrden> DetalleOrdenes { get; set;}
    }
}