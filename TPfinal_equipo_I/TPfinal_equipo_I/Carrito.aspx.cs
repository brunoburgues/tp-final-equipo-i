using Basededatos;
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
                int idCarrito = 1;
                CarritoDB carritoDB = new CarritoDB();
                List<Carrito> carrito = carritoDB.ListarArticulos(idCarrito);
                repArticulos.DataSource = carrito;
                repArticulos.DataBind();
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

        protected void btnMenos_Click(object sender, EventArgs e)
        {

        }

        protected void btnMas_Click(object sender, EventArgs e)
        {

        }

        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            CarritoDB carritoDB = new CarritoDB();
            int idArticulo = Convert.ToInt32(e.CommandArgument);
            int idCarrito = 1;
            Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");

            if (lblCantidad != null)
            {
                int cantidad = int.Parse(lblCantidad.Text);

                if (e.CommandName == "Menos")
                {
                    if (cantidad > 0){
                        cantidad--;
                    }
                }
                else if (e.CommandName == "Mas")
                {
                    cantidad++;
                }
                lblCantidad.Text = Convert.ToString(cantidad);
                //carritoDB = carritoDB.ActualizarCantidad(idCarrito, idArticulo, cantidad);
            }
            //List<Carrito> carrito = carritoDB.ListarArticulos(idCarrito);
            //repArticulos.DataSource = carrito;
            //.DataBind();
        }
    }
}