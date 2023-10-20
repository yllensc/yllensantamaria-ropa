using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InsumoPrenda : BaseEntity
    {
        public int IdInsumo { get; set; }
        public int IdPrenda { get; set; }
        public int Cantidad { get; set; }
        public Insumo Insumo { get; set; }
        public Prenda Prenda { get; set; } 
    }
}