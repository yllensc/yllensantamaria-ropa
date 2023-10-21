using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorDto
    {
        public int Id {get; set;}
        public string NitProveedor { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdMunicipio { get; set; }
        public string TipoPersona { get; set; } 
        public string Municipio { get; set; }
        public ICollection<InsumoDto> Insumos { get; set; }
    }
}