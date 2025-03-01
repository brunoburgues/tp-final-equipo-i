using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPfinal_equipo_I
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).tipoUsuario == Dominio.TipoUsuario.Admin))
            {
                Session.Add("error", "No tiene permiso aquí.");
                Response.Redirect("LogIn.aspx", false);
            }

        }
    }
}