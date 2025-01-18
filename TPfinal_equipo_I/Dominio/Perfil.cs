﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Articulo> Articulos { get; set; }



        public override string ToString()
        {
            return Nombre;
        }
    }
}
