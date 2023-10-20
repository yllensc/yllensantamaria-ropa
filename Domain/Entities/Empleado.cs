using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdCargo { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public int IdMunicipio { get; set; }
        public Cargo Cargo { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public Municipio Municipio { get; set; }
        public ICollection<Venta> Ventas { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
    }
}