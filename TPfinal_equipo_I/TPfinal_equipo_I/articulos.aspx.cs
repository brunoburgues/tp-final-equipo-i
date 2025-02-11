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
            List<Articulo> lista = articulo.ListarArticulos();
            GridView1.DataSource = lista;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          var id  =GridView1.SelectedDataKey.Value.ToString();
            Response.Redirect("Agregar.aspx?id=" + id);
        }
    }
}