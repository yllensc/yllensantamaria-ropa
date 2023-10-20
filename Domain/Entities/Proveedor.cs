using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Proveedor : BaseEntity
    {
        public string NitProveedor { get; set; }
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdMunicipio { get; set; }
        public TipoPersona TipoPersona { get; set; } 
        public Municipio Municipio { get; set; }
        public ICollection<Insumo> Insumos { get; set; }
    }
}