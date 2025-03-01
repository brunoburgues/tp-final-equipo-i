using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using BaseDatos;
using Basededatos;

namespace TPfinal_equipo_I
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioDB usuarioDB = new UsuarioDB();
            try
            {
                usuario= new Usuario(txtUsuario.Text, txtContraseña.Text, false);
                if(usuarioDB.Loguear(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("MenuLogIn.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }


                
            }catch(Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}