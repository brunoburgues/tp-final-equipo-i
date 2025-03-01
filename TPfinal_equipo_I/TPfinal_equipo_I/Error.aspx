<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPfinal_equipo_I.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <
        <div class="logIn row d-flex justify-content-center align-items-center">
        <div class="col">
            <h2 class="text-center mb-4 titulo">Hubo un problema.</h2>
            <asp:Label ID="lblMensaje" Text="Text" class="form-text" runat="server" />
           
            </div>
        </div>
</asp:Content>
