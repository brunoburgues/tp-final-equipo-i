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
        public bool ConfirmaEliminacion { get; set; }
        

       protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false; // Asegúrate de que esta variable esté declarada en la clase.

            if (!IsPostBack)
            {
                try
                {
                    // Cargar lista de categorías
                    CategoriaDB listaCategorias = new CategoriaDB();
                    List<Categoria> lista = listaCategorias.listarCategoria();

                    listBoxCategorias.DataSource = lista;
                    listBoxCategorias.DataTextField = "Descripcion"; // Campo visible en el ListBox
                    listBoxCategorias.DataValueField = "Id";    // Campo que actúa como el valor
                    listBoxCategorias.DataBind();

                    // Imagen por defecto
                    string urlImagen = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
                    imgImagen.ImageUrl = urlImagen;
                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex);
                }
            }

            // Cargar datos del artículo si se pasa un ID por la URL
            if (Request.QueryString["Id"] != null)
            {
                try
                {
                    string idString = Request.QueryString["Id"];
                    Response.Write("<script>console.log('ID recibido como string: " + idString + "');</script>");

                    if (int.TryParse(idString, out int Id))
                    {
                        Response.Write("<script>console.log('ID convertido correctamente: " + Id + "');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error: ID no válido. Valor recibido: " + idString + "');</script>");
                    }

                    // Verificar si la sesión contiene artículos antes de acceder a ellos
                    if (Session["Articulos"] != null)
                    {
                        List<Articulo> articulos = (List<Articulo>)Session["Articulos"];
                        Articulo articulo = articulos.Find(x => x.Id == Id);

                        if (articulo != null)
                        {
                            txtId.Text = articulo.Id.ToString();
                            txtNombre.Text = articulo.Nombre;
                            txtDescripcion.Text = articulo.Descripcion;
                            txtPrecio.Text = articulo.Precio.ToString();
                            listBoxCategorias.SelectedValue = articulo.Categoria.Id.ToString();

                            // Verificar si el artículo tiene imágenes antes de acceder a la primera
                            if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                            {
                                imgImagen.ImageUrl = articulo.Imagenes[0].Url;
                            }
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
                if (listBoxCategorias.SelectedItem != null)
                {
                    Articulo articulo = new Articulo();
                    ArticuloDB articuloDB = new ArticuloDB();

                    articulo.Nombre = txtNombre.Text.Trim();
                    articulo.Descripcion = txtDescripcion.Text.Trim();

                    // Validar categoría seleccionada
                    if (!int.TryParse(listBoxCategorias.SelectedValue, out int categoriaId))
                    {
                        Response.Write("<script>alert('Error: Categoría inválida.');</script>");
                        return;
                    }

                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = categoriaId;

                    // Validar precio antes de convertirlo
                    if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                    {
                        Response.Write("<script>alert('Error: El precio ingresado no es válido.');</script>");
                        return;
                    }

                    articulo.Precio = precio;

                    articuloDB.agregar(articulo);
                    Response.Redirect("Articulos.aspx", false);
                }
                else
                {
                    Response.Write("<script>alert('Error: No has seleccionado una categoría.');</script>");
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
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminar.Checked)
                {
                    ConfirmaEliminacion = true;

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        ArticuloDB articuloDB = new ArticuloDB();
                        articuloDB.eliminar(id);
                        Response.Redirect("articulos.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
    }
}