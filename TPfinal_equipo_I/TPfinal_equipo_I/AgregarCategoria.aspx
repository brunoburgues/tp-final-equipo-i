<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="TPfinal_equipo_I.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <h1>Agregar Categorías</h1>
            <label for="txtId" class="form-label">Id</label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="alertaMensaje" class="form-text" runat="server" />

        </div>
    </div>
    <div>  <asp:Button ID="btnAceptar" CssClass="btn btn-outline-success" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" class="btn btn-success mt-4" />
        <a href="Categorias.aspx" class="btn btn-outline-warning">Cancelar</a></div>
        <asp:Button ID="Eliminar" CssClass="btn btn-outline-danger" runat="server" Text="Eliminar" OnClick="Eliminar_Click" class="btn btn-danger mt-4" />
            <%if (ConfirmaEliminacion){ %>
    <div class="alert alert-danger" role="alert">
        ¿Está seguro que desea eliminar el artículo?
        <asp:CheckBox ID="chkConfirmarEliminar"  runat="server" />
        <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Confirmar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnCancelarEliminar" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger"  />
</div>
    <%} %>
    
</asp:Content>
