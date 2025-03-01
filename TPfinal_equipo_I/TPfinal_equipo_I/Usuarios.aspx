<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPfinal_equipo_I.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Usuarios</h1>
    <asp:DataGrid ID="dgUsuarios" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
        <Columns>
            <asp:BoundColumn DataField="id" HeaderText="Id" />
            <asp:BoundColumn DataField="nombre" HeaderText="Nombre" />
            <asp:BoundColumn DataField="apellido" HeaderText="Apellido" />
            <asp:BoundColumn DataField="email" HeaderText="Email" />
            <asp:BoundColumn DataField="tipoUsuario" HeaderText="Tipo de Usuario" />
            <asp:ButtonColumn Text="Eliminar" CommandName="Eliminar" />
        </Columns>
        </asp:DataGrid>
</asp:Content>
