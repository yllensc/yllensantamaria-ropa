using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoDto
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public int IdCargo { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public int IdMunicipio { get; set; }
        public string Cargo { get; set; }
        public ICollection<VentaDto> Ventas { get; set; }
        public ICollection<OrdenDto> Ordenes { get; set; }
    }
}