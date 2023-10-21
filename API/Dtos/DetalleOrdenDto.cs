using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetalleOrdenDto
    {
        public int Id {get; set;}
        public int IdOrden { get; set; }
        public int IdPrenda { get; set; }
        public int CantidadAProducir { get; set; }
        public int CantidadProducida { get; set; } = 0;
        public int IdEstado { get; set; }
        public PrendaDto Prenda { get; set; }
        public string Color { get; set; }
        public string EstadoCodigo { get; set; }

    }
}