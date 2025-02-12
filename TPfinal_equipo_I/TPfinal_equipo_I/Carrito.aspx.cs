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
        //métodos
        private void cargarArticulos(CarritoDB carritoDB, int idCarrito)
        {
            List<Carrito> carrito = carritoDB.ListarArticulos(idCarrito);
            repArticulos.DataSource = carrito;
            repArticulos.DataBind();
        }
        //eventos
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

            if (e.CommandName == "Eliminar")
            {
                string[] listaArgumentos = e.CommandArgument.ToString().Split(',');
                int id = Convert.ToInt32(listaArgumentos[0]);
                int idC = Convert.ToInt32(listaArgumentos[1]);

                carritoDB.eliminar(id);
                cargarArticulos(carritoDB, idC);
                return;
            }

            string[] argumentos = e.CommandArgument.ToString().Split(',');
            int idArticulo = Convert.ToInt32(argumentos[0]);
            int idCarrito = Convert.ToInt32(argumentos[1]);

            Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");

            if (lblCantidad != null)
            {
                int cantidad = int.Parse(lblCantidad.Text);

                if (e.CommandName == "Menos" && cantidad > 1)
                {
                    cantidad--;
                }
                else if (e.CommandName == "Mas")
                {
                    cantidad++;
                }
                lblCantidad.Text = Convert.ToString(cantidad);
                carritoDB.actualizarCantidad(idCarrito, idArticulo, cantidad);
            }
            cargarArticulos(carritoDB, idCarrito);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
        }
    }
}