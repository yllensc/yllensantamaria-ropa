using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrendaDto
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public double ValorUnitCop { get; set; }
        public double ValorUnitUsd { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoProteccion { get; set; }
        public int IdGenero { get; set; }
        public EstadoDto Estado { get; set; }
        public TipoProteccionDto TipoProteccion { get; set; }
        public string Genero { get; set; }
        public ICollection<DetalleOrdenDto> DetalleOrdenes { get; set; }
        public ICollection<InsumoDto> Insumos { get; set; }
        public ICollection<InsumoPrendaDto> InsumoPrendas { get; set; }
    }
}