using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstadoDto
    {
        public int Id {get; set;}
        public string Codigo { get; set; }
        public string CodigoDescripcion { get; set; }
        public ICollection<PrendaDto> Prendas { get; set; }
        public ICollection<OrdenDto> Ordenes { get; set; }
        public ICollection<DetalleOrdenDto> DetalleOrdenes { get; set; }
    }
}