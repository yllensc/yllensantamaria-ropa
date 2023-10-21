using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TipoPersonaDto
    {
       public int Id {get; set;} 
       public string Nombre { get; set; }
        public ICollection<ProveedorDto> Proveedores { get; set; }
    }
}