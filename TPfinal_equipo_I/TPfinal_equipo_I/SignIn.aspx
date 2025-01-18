<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="TPWeb_equipo_i.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1>Registrate </h1>
    
    
    <br />
    <div class="row g-3">
        <asp:Label runat="server" class="form-label" ID="lblPrueba" />

        <div class="col-md-6">
            <label for="txtDNI" class="form-label">Documento</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtDNI" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged" />
        </div>
        <div class="col-md-6">
            <label for="txtEmail" class="form-label">Correo Electrónico</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
        </div>
        <div class="col-12">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
        </div>
        <div class="col-12">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />
        </div>
        <div class="col-12">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccion" />
        </div>
        <div class="col-12">
            <label for="txtCiudad" class="form-label">Ciudad</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCiudad" />
        </div>
        <div class="col-12">
            <label for="txtCp" class="form-label">Código Postal</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCp" />
        </div>
        <div class="col-12">
            <asp:Button Text="Participar!" CssClass="btn btn-success mb-3" ID="btnRegistrar" OnClick="btnRegistrar_Click" runat="server" Width="122px" />
        </div>

        <p class="form-text text-center">
            Si ya tienes una cuenta ingresa
            <asp:HyperLink runat="server" Text="aquí" ID="linkLogIn" />.
        </p>
    </div>
    

    <br />
</asp:Content>

