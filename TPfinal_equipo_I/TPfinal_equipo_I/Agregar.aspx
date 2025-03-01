<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="TPfinal_equipo_I.Agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <h1>Agregar Artículos</h1>

            <label for="txtId" class="form-label">Id</label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <label for="txtNombre" class="form-label">Precio</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            <label for="txtNombre" class="form-label">Stock</label>
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
            <label for="txtNombre" class="form-label">Categoria</label>
            <asp:DropDownList ID="listBoxCategorias" runat="server" SelectionMode="Multiple"></asp:DropDownList>
            <label for="txtNombre" class="form-label"></label>
            <label for="txtNombre" class="form-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <div class=" mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ID="imgImagen" runat="server" CssClass="img-fluid" Width="60%" />
                </ContentTemplate>

            </asp:UpdatePanel>
            <asp:Label ID="alertaMensaje" class="form-text" runat="server" />
        </div>
        <div class="mb-3">
            <asp:Button ID="btnAceptar" CssClass="btn btn-outline-success" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" class="btn btn-success mt-4" />
            <asp:button ID="btnEditar" class="btn btn-outline-primary" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <a href="Default.aspx" class="btn btn-outline-warning">Cancelar</a>
        </div>
    </div>
    <div class ="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                        
                    </div>
                    <%if (ConfirmaEliminacion){ %>
                    <div class="alert alert-danger" role="alert">
                        ¿Está seguro que desea eliminar el artículo?
                        <asp:CheckBox ID="chkConfirmarEliminar"  runat="server" />
                        <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnCancelarEliminar" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger"  />
                </div>
                    <%} %>
                        </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
