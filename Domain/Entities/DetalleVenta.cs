using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleVenta : BaseEntity
    {
        public int IdVenta { get; set; }
        public int IdInventario { get; set; }
        public int IdTalla { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnit { get; set; }
        public Venta Venta { get; set; }
        public Inventario Inventario { get; set; }
        public Talla Talla { get; set; }

    }
}