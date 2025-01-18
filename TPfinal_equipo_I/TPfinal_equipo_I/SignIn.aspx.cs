using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDatos;
using Dominio;
using Microsoft.SqlServer.Server;
using static System.Net.Mime.MediaTypeNames;


namespace TPWeb_equipo_i
{
    public partial class SignIn : System.Web.UI.Page
    {
       
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            }

        protected void btnRegistrar_Click(object sender, EventArgs e)

        {}

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
          
        }
        
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}