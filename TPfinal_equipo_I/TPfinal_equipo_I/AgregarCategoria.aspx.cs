using BaseDatos;
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
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).tipoUsuario == Dominio.TipoUsuario.Admin))
            {
                Session.Add("error", "No tiene permiso aquí.");
                Response.Redirect("LogIn.aspx", false);
            }
            txtId.Enabled = false;
            if(!IsPostBack)
            {
                try
                {
                    ConfirmaEliminacion = false;
                    string idString = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
                    {
                        CategoriaDB categoriaDB = new CategoriaDB();
                       // Dominio.Categoria categoria = categoriaDB.listarCategoria(id);
                        if (categoria != null)
                        {
                            txtId.Text = categoria.Id.ToString();
                            txtNombre.Text = categoria.Descripcion;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                }
            }
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
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfirmaEliminacion = true;

                if (chkConfirmarEliminar.Checked)
                {
                    Response.Write("<script>alert('Checkbox marcado');</script>");

                    string idString = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
                    {
                        Response.Write("<script>alert('ID recibido: " + id + "');</script>");

                        CategoriaDB categoriaDB = new CategoriaDB();
                        categoriaDB.eliminar(id);

                        Response.Redirect("Categorias.aspx", false);
                    }
                    else
                    {
                        Response.Write("<script>alert('Error: ID no válido.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Error: Debes confirmar la eliminación.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }

        }
    }
}