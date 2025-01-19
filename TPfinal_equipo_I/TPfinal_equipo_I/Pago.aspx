<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="TPfinal_equipo_I.Pago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Pago</h1>
    <h2>Seleccione el método de pago</h2>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem Value="1">Tarjeta de crédito</asp:ListItem>
        <asp:ListItem Value="2">Transferencia bancaria</asp:ListItem>
        <asp:ListItem Value="3">Efectivo</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Pagar" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    

</asp:Content>
