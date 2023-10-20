using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cargo : BaseEntity
    {
        public string Descripcion { get; set; }
        public double SueldoBase { get; set; } = 0;
        public ICollection<Empleado> Empleados { get; set; }
    }
}