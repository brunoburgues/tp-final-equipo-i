using BaseDatos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPfinal_equipo_I
{
    public partial class Default : System.Web.UI.Page
    { public bool FiltroAvanzado {get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {ArticuloDB articuloFiltro = new ArticuloDB();
            Session.Add("listaArticulos", articuloFiltro.ListarArticulos());
            idRepeater.DataSource = Session["listaArticulos"];
            idRepeater.DataBind();
                FiltroAvanzado = chkAdvanceFilter.Checked;

            if (!IsPostBack)
            {
                ArticuloDB articuloDB = new ArticuloDB();
                List<Articulo> lista = articuloDB.ListarArticulos();
                idRepeater.DataSource = lista; 
                idRepeater.DataBind();
                repeaterMasVendidos.DataSource = lista;
                repeaterMasVendidos.DataBind();
                repeaterProductos.DataSource = lista;
                repeaterProductos.DataBind();
            }
        }

        protected void btnVerProducto_Click(object sender, EventArgs e)
        {

        }

        

        protected void txtBuscar_TextChanged(object sender)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscar.Text.ToUpper()));
            idRepeater.DataSource = listaFiltrada;
            idRepeater.DataBind();
        }

        protected void chkAdvanceFilter_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado= chkAdvanceFilter.Checked;
            txtBuscar.Enabled= !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a ");
               ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con ");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloDB articulo = new ArticuloDB();
                idRepeater.DataSource = articulo.FiltrarArticulos(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtBuscar.Text);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}