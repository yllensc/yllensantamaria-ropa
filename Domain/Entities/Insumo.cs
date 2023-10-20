using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Insumo : BaseEntity
    {
        public string Nombre { get; set; }
        public double ValorUnit { get; set; }
        public int StockMin { get; set; } = 30;
        public int StockMax { get; set;} = 300;
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set;}
        public ICollection<Prenda> Prendas { get; set; }
        public ICollection<InsumoPrenda> InsumoPrendas { get; set; }

    }
}