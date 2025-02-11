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
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { try
            {
                if (!IsPostBack)
                {

                    CategoriaDB listaCategorias = new CategoriaDB();
                    List<Categoria> lista = listaCategorias.listarCategoria();


                    listBoxCategorias.DataSource = lista;
                    listBoxCategorias.DataTextField = "Descripcion"; // Campo visible en el DropDownList
                    listBoxCategorias.DataValueField = "Id";    // Campo que actúa como el valor
                    listBoxCategorias.DataBind();
                }
            }catch(Exception ex )
            { Session.Add("Error", ex); }
            }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxCategorias.SelectedItem != null)
                {

                    Articulo articulo = new Articulo();
                    ArticuloDB articuloDB = new ArticuloDB();
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = int.Parse(listBoxCategorias.SelectedValue);
                    articulo.Precio = int.Parse(txtPrecio.Text);

                    articuloDB.agregar(articulo);
                    Response.Redirect("Default.aspx",false);

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }

        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgImagen.ImageUrl = txtImagenUrl.Text;
        }

    }
}