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
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).tipoUsuario == Dominio.TipoUsuario.Admin))
            {
                Session.Add("error", "No tiene permiso aquí.");
                Response.Redirect("LogIn.aspx", false);
            }

            if (!IsPostBack)
            {
                try
                {
                    ConfirmaEliminacion = false;
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

                            btnAceptar.Visible = false; // Se deshabilita "Agregar"
                            btnEditar.Visible = true;   // Se habilita "Editar"
                            ViewState["ArticuloID"] = Id; // Guardamos el ID para usarlo en btnEditar_Click
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
                Articulo articulo = new Articulo();
                ArticuloDB articuloDB = new ArticuloDB();

                // Asignar valores comunes
                articulo.Nombre = txtNombre.Text.Trim();
                articulo.Descripcion = txtDescripcion.Text.Trim();

                if (!int.TryParse(listBoxCategorias.SelectedValue, out int categoriaId))
                {
                    Response.Write("<script>alert('Error: Categoría inválida.');</script>");
                    return;
                }
                articulo.Categoria = new Categoria();
                articulo.Categoria.Id = categoriaId;

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    Response.Write("<script>alert('Error: El precio ingresado no es válido.');</script>");
                    return;
                }
                articulo.Precio = precio;

                // Si existe un ID en la URL, se asume edición; de lo contrario, es inserción
                if (Request.QueryString["Id"] != null)
                {
                    if (int.TryParse(Request.QueryString["Id"], out int id))
                    {
                        articulo.Id = id;
                        articuloDB.modificar(articulo);  // Método UPDATE (debe existir en tu código)
                    }
                    else
                    {
                        Response.Write("<script>alert('Error: ID inválido.');</script>");
                        return;
                    }
                }
                else
                {
                    articuloDB.agregar(articulo);  // Método INSERT (corrige para que no incluya Id)
                }

                Response.Redirect("Articulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Write("<script>alert('Editar presionado');</script>");

                if (ViewState["ArticuloID"] != null && int.TryParse(ViewState["ArticuloID"].ToString(), out int id))
                {
                    Response.Write("<script>alert('ID: " + id + "');</script>");

                    Articulo articulo = new Articulo();
                    ArticuloDB articuloDB = new ArticuloDB();

                    articulo.Id = id;
                    articulo.Nombre = txtNombre.Text.Trim();
                    articulo.Descripcion = txtDescripcion.Text.Trim();

                    if (!int.TryParse(listBoxCategorias.SelectedValue, out int categoriaId))
                    {
                        Response.Write("<script>alert('Error: Categoría inválida.');</script>");
                        return;
                    }

                    articulo.Categoria = new Categoria { Id = categoriaId };

                    if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                    {
                        Response.Write("<script>alert('Error: Precio inválido.');</script>");
                        return;
                    }

                    articulo.Precio = precio;

                    articuloDB.modificar(articulo);
                    Response.Write("<script>alert('Artículo editado correctamente');</script>");
                    Response.Redirect("Articulos.aspx", false);
                }
                else
                {
                    Response.Write("<script>alert('Error: No se pudo obtener el ID del artículo.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
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
                ConfirmaEliminacion = true;

                if (chkConfirmarEliminar.Checked)
                {
                    Response.Write("<script>alert('Checkbox marcado');</script>");

                    string idString = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
                    {
                        Response.Write("<script>alert('ID recibido: " + id + "');</script>");

                        ArticuloDB articuloDB = new ArticuloDB();
                        articuloDB.eliminar(id);

                        Response.Redirect("articulos.aspx", false);
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