using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<Articulo> Articulos { get; set; }
        public Pago Pago { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Direccion { get; set; }

    }
}
