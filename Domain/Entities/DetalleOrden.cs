using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleOrden : BaseEntity
    {
        public int IdOrden { get; set; }
        public int IdPrenda { get; set; }
        public int CantidadAProducir { get; set; }
        public int IdColor { get; set; }
        public int CantidadProducida { get; set; } = 0;
        public int IdEstado { get; set; }
        public Orden Orden  { get; set; }
        public Prenda Prenda { get; set; }
        public Color Color { get; set; }
        public Estado Estado { get; set; }

    }
}