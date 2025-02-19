using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public int Id { get; set; }
        public int IdCarrito { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal Precio{ get; set; }
        public string ImagenUrl {  get; set; }
    }
}
