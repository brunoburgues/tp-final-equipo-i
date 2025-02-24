using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPfinal_equipo_I
{
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDatos.CategoriaDB categoriaDB = new BaseDatos.CategoriaDB();
                Dominio.Categoria categoria = new Dominio.Categoria();
                categoria.Descripcion = txtNombre.Text.Trim();
                categoriaDB.agregar(categoria);
                Response.Redirect("Categorias.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
    }
}}