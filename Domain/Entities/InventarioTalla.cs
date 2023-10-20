using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InventarioTalla : BaseEntity
    {
        public int IdInv { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public Inventario Inventario { get; set; }
        public Talla Talla { get; set; }
    }
}