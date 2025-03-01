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

        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).tipoUsuario == Dominio.TipoUsuario.Admin))
            {
                Session.Add("error", "No tiene permiso aquí.");
                Response.Redirect("LogIn.aspx", false);
            }
            if (!IsPostBack)
            {
                
                
                    ArticuloDB articuloDB = new ArticuloDB();
                    List<Articulo> listaArticulos = articuloDB.ListarArticulos();
                    Session["Articulos"] = listaArticulos;  // Aseguramos que la sesión tenga datos
                


                GridView1.DataSource = Session["listaArticulos"];
                GridView1.DataBind();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (GridView1.SelectedDataKey != null)
            {
                var Id = GridView1.SelectedDataKey.Value.ToString();

                // 🔍 Depuración: Muestra el ID antes de redirigir
                Response.Write("<script>console.log('Redirigiendo a: Agregar.aspx?id=" + Id + "');</script>");

                // ✅ Redirección optimizada
                Response.Redirect("Agregar.aspx?id=" + Id, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Write("<script>alert('Error: No se pudo obtener el ID.');</script>");
            }


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