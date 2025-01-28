<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="TPfinal_equipo_I.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Modificar Artículos</h1>
    <label for="txtNombre" class="form-label">Codigo</label>
    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Nombre</label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Precio</label>
    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Stock</label>
    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Categoria</label>
    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Imagen</label>
    <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control"></asp:TextBox>
    <label for="txtNombre" class="form-label">Descripcion</label>
    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:Label ID="alertaMensaje" class="form-text" runat="server" />

</asp:Content>
