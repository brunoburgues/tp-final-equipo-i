<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="recuperarContraseña.aspx.cs" Inherits="TPfinal_equipo_I.recuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Recuperar contraseña</h1>
    <p>Ingrese su correo electrónico para recuperar su contraseña.</p>
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
    <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" OnClick="btnRecuperar_Click" class="btn btn-success mt-4" />
    <asp:Label ID="alertaMensaje" class="form-text" runat="server" />



</asp:Content>
