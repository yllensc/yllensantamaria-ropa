using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InsumoDto
    {
        public int Id {get; set;}
        public string Nombre { get; set; }
        public double ValorUnit { get; set; }
        public int StockMin { get; set; } = 30;
        public int StockMax { get; set;} = 300;
        public int IdProveedor { get; set; }
        public string Proveedor { get; set;}
        public ICollection<PrendaDto> Prendas { get; set; }
        public ICollection<InsumoPrendaDto> InsumoPrendas { get; set; }
    }
}