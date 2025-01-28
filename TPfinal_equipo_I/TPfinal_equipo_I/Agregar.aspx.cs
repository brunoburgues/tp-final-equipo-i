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
        {
            if (!IsPostBack)
            { Categoria categoria = new Categoria();
            //listBoxCategorias.Items.Add(new ListItem(categoria.Descripcion, categoria.Id.ToString()));
            List<Categoria> categorias = new List<Categoria>
{
    new Categoria { Id = 1, Descripcion = "Electrónica" },
    new Categoria { Id = 2, Descripcion = "Ropa" },
    new Categoria { Id = 3, Descripcion = "Alimentos" }
};
                listBoxCategorias.DataSource = categorias;
                listBoxCategorias.DataTextField = "Descripcion"; // Campo visible en el DropDownList
                listBoxCategorias.DataValueField = "Id";    // Campo que actúa como el valor
                listBoxCategorias.DataBind();}
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listBoxCategorias.SelectedItem != null)
            {
                int idSeleccionado = int.Parse(listBoxCategorias.SelectedValue);

                // Lista de categorías cargada previamente
                List<Categoria> categorias = ObtenerCategorias();

                // Busca la categoría correspondiente
                Categoria categoriaSeleccionada = categorias.FirstOrDefault(c => c.Id == idSeleccionado);

                Articulo articulo = new Articulo();
            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            if (listBoxCategorias.SelectedItem != null)
            {
                articulo.Categoria = (List<Categoria>)listBoxCategorias.SelectedItem;
            }
            articulo.Precio= int.Parse(txtPrecio.Text);
            articulo.Imagenes = ;

        }
    }
}