using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int IdMunicipio { get; set; }
        public TipoPersonaDto TipoPersona {get; set;}
        public MunicipioDto Municipio{ get; set; }
        public ICollection<OrdenDto> Ordenes {get; set; }
        public ICollection<VentaDto> Ventas {get; set; }
    }
}