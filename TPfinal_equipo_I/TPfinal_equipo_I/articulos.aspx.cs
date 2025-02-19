using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using BaseDatos;

namespace TPfinal_equipo_I
{
    public partial class articulos1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {ArticuloDB articulo = new ArticuloDB();
            Session.Add("listaArticulos",  articulo.ListarArticulos());
            GridView1.DataSource = Session["listaArticulos"];
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          var id  =GridView1.SelectedDataKey.Value.ToString();
            Response.Redirect("Agregar.aspx?id=" + id);
        }
        protected void Filtro_TextChanged(object sender ,EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            GridView1.DataSource = listaFiltrada;
            GridView1.DataBind();
        }
    }
}