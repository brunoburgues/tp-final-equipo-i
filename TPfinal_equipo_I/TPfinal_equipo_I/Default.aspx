<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPfinal_equipo_I.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default-buscador d-flex justify-content-end">
        <div class="d-flex" style="width: 530px" role="search">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2" aria-label="Search" />
            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-success" />
        </div>
    </div>

    <h2>¡Bienvenido a nuestra tienda!</h2>
    <h2>¡Aprovecha nuestras ofertas!</h2>
    <h2>¡Registrate para recibir novedades!</h2>
    <h2>¡Compra ahora!</h2>
    <div class="container mb-4">
        <div class="d-flex justify-content-center align-items-center flex-wrap gap-3 default-cards-container">
            <asp:Repeater runat="server" ID="idRepeater">
                <ItemTemplate>
                    <div class="card" style="width: 18rem; height: 25rem">
                        <div class="d-flex justify-content-center align-items-center">
                            <div class="img-container">
                                <img src='<%# Eval("Imagenes[0].Url") %>' class="card-img-top" alt="...">
                            </div>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <p class="card-text"><%# Eval("Precio")%></p>
                            <asp:Button ID="btnVerProducto" Text="Ver Producto" runat="server" class="btn btn-primary" OnClick="btnVerProducto_Click" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>


</asp:Content>
