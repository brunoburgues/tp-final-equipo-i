using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDatos;
using Dominio;

namespace TPfinal_equipo_I
{
    public partial class Categorias : System.Web.UI.Page
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
                try
                {
                    CategoriaDB categoriaDB = new CategoriaDB();
                   
                    GridView1.DataSource = categoriaDB.listarCategoria();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                }
            }

        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}