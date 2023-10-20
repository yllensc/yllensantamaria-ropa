using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estado : BaseEntity
    {
        public string Codigo { get; set; }
        public string CodigoDescripcion { get; set; }
        public ICollection<Prenda> Prendas { get; set; }
        public ICollection<Orden> Ordenes { get; set; }
        public ICollection<DetalleOrden> DetalleOrdenes { get; set; }
    }
}