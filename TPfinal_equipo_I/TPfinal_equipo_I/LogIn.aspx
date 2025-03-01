<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPfinal_equipo_I.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="logIn row d-flex justify-content-center align-items-center">
        <div class="col">
            <h2 class="text-center mb-4 titulo">Inicio Sesión</h2>
            <label for="txtUsuario" class="form-label">Usuario</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            <label for="txtContraseña" class="form-label mt-2"></label>Contraseña
            <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:Label ID="alertaMensaje" class="form-text" runat="server" />
            <div class="text-center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" class="btn btn-success mt-4" />
                <p class="form-text mt-4">Si todavía no tienes una cuenta, puedes crearla <asp:HyperLink runat="server" Text="aquí" ID="linkSignIn"/>.</p>
            <label for="text" class="form-label">Olvido su constraseña haga click aquí.</label>
            </div>
        </div>
    </div>

</asp:Content>

