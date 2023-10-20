using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int IdMunicipio { get; set; }
        public TipoPersona TipoPersona {get; set;}
        public Municipio Municipio{ get; set; }
        public ICollection<Orden> Ordenes {get; set; }
        public ICollection<Venta> Ventas {get; set; }
    }
}