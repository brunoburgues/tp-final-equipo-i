<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPfinal_equipo_I.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Ingrese su usuario y contraseña</h1>
    <h2>Usuario</h2>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    <h2>Contraseña</h2>
    <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
    <h2>Aceptar</h2>
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
    <h2>Cancelar</h2>
    
    
</asp:Content>
