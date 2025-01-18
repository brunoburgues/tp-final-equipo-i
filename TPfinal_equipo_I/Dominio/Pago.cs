using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Pago
    {
       
            public int Id { get; set; }
            public decimal Cantidad { get; set; }
            public string MetodoPago { get; set; }
            public DateTime FechaPago { get; set; }



    }
}
