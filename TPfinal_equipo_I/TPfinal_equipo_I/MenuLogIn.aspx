<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="MenuLogIn.aspx.cs" Inherits="TPfinal_equipo_I.MenuLogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="logIn row d-flex justify-content-center align-items-center">
        <div class="col">
            <h1 class="Text">Te logueaste correctamente.</h1>
            <p class="form-text mt-4">Bienvenido a la página de inicio.</p>
            <h2>Menú</h2>
            <ul>
                <li><a href="Default.aspx" class="fa-solid fa-box">Ir a productos</a></li>
                <li><a href="Carrito.aspx" class="fa-solid fa-cart-shopping">Ir al carrito</a></li>
                <li><a href="Contacto.aspx" class="fa-solid fa-envelope">Contactate</a></li>
                <li><a href="LogOut.aspx">Cerrar Sesión</a></li>

            </ul>
            <%if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).tipoUsuario == Dominio.TipoUsuario.Admin)
                {  %>
            <ul>
                <li><a href="Categorias.aspx" class="fa-solid fa-tags">Ir a la lista de categorías</a></li>
                <li><a href="AgregarCategoria.aspx" class="btn btn-outline-success">Agregar Categoría</a></li>
                <li><a href="Articulos.aspx" class="fa-solid fa-box">Ir a la lista de artículos</a></li>
                <li><a href="AgregarArticulo.aspx" class="btn btn-outline-success">Agregar Artículo</a></li>
                <li><a href="Usuarios.aspx" class="fa-solid fa-users">Ir a la lista de usuarios</a></li>

            </ul>
            <%} %>
        </div>
    </div>
</asp:Content>
