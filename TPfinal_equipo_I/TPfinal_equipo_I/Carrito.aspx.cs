﻿using BaseDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPfinal_equipo_I
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloDB articuloDB = new ArticuloDB();
                List<Articulo> lista = articuloDB.ListarArticulos();
                repArticulos.DataSource = lista;
                repArticulos.DataBind();
                //dgvCarrito.DataSource = lista;
                //dgvCarrito.DataBind();
            }
        }
        //comprar
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        // vaciar carrito
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}