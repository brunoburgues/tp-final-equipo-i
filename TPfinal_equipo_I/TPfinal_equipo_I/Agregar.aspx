<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="TPfinal_equipo_I.Agregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
    <h1>Agregar Artículos</h1>

    <label for="txtNombre" class="form-label">Codigo</label>
    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Nombre</label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtPrecio" class="form-label">Precio</label>
    <asp:TextBox ID="txtPrecio" runat="server" textmode="Month" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Stock</label>
    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Categoria</label>
        <asp:ListBox ID="listBoxCategorias" runat="server" SelectionMode="Multiple"></asp:ListBox>    
    <label for="txtNombre" class="form-label">Imagen</label>
    <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Descripcion</label>
    <asp:TextBox ID="txtDescripcion" textmode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="alertaMensaje" class="form-text" runat="server" />
            </div>
        <div class="mb-3">
            <asp:Button ID="btnAceptar" cssclass="btn btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" class="btn btn-success mt-4" />
            <a href="Default.aspx">Cancelar</a>
        </div>
        </div>
</asp:Content>
