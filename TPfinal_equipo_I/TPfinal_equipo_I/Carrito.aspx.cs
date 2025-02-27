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
        private void ActualizarMontoTotalEInterfaz(CarritoDB carritoDB, int idCarrito)
        {
            List<Carrito> carrito = carritoDB.ListarArticulos(idCarrito);
            decimal total = calcularMontoTotal(carrito);
            montoTotal.Text = $"{formatoPrecio(total)}";
            carritoDB.actualizarMontoTotal(idCarrito, total);
            cargarArticulos(carritoDB, idCarrito);
        }
        public string formatoPrecio(decimal precio)
        {
            var culture = new System.Globalization.CultureInfo("es-AR");
            return precio.ToString("#,##0", culture);
        }
        private void cargarArticulos(CarritoDB carritoDB, int idCarrito)
        {
            List<Carrito> carrito = carritoDB.ListarArticulos(idCarrito);
            repArticulos.DataSource = carrito;
            repArticulos.DataBind();
        }
        private decimal calcularMontoTotal(List<Carrito> carrito)
        {
            decimal montoTotal = 0;
            foreach (Carrito c in carrito)
            {
                montoTotal += c.Precio * c.Cantidad;
            }
            return montoTotal;
        }
        //eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //OBTENER EL IDCARRITO CORRESPONDIENTE DE CADA USUARIO
                int idCarrito = 1;
                CarritoDB carritoDB = new CarritoDB();
                List<Carrito> carrito = carritoDB.ListarArticulos(idCarrito);
                decimal total = calcularMontoTotal(carrito);
                montoTotal.Text = $"{formatoPrecio(total)}";


                cargarArticulos(carritoDB, idCarrito);
            }
        }
        //comprar
        protected void Button1_Click(object sender, EventArgs e)
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
            string[] argumentos = e.CommandArgument.ToString().Split(',');
            int idArticulo = Convert.ToInt32(argumentos[0]);
            int idCarrito = Convert.ToInt32(argumentos[1]);

            if (e.CommandName == "Eliminar")
            {
                carritoDB.eliminarArticulo(idArticulo);
            }
            else
            {
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

                    lblCantidad.Text = cantidad.ToString();
                    carritoDB.actualizarCantidad(idCarrito, idArticulo, cantidad);
                }
            }

            ActualizarMontoTotalEInterfaz(carritoDB, idCarrito);
        }

        protected void repArticulos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblCantidad = (Label)e.Item.FindControl("lblCantidad");
                if (lblCantidad != null)
                {
                    int cantidad = int.Parse(lblCantidad.Text);

                    Button btnMenos = (Button)e.Item.FindControl("btnMenos");
                    Button btnMas = (Button)e.Item.FindControl("btnMas");
                    if (btnMenos != null && btnMas != null)
                    {
                        btnMenos.Enabled = (cantidad > 1);
                        //Traer el stock y verificar que no lo superé
                        btnMas.Enabled = (cantidad < 3);
                    }
                }
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        protected void btnVaciar_Click(object sender, EventArgs e)
        {
            int idCarrito = 1;
            CarritoDB carritoDB = new CarritoDB();
            carritoDB.eliminarCarrito(idCarrito);
        }

        
    }
}