﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set;}

        public List<Articulo> Articulos { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

        public static explicit operator Categoria(System.Web.UI.WebControls.ListItem v)
        {
            throw new NotImplementedException();
        }
    }
}
