<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPfinal_equipo_I.Compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <h2 class="mb-4">
                <i class="bi bi-arrow-left"></i>Carrito de Compras
            </h2>
            <asp:Repeater runat="server" ID="repArticulos">
                <ItemTemplate>
                    <div class="cart-item containerArticulo d-flex align-items-center mb-3">
                        <div class="carrito-img-container">
                            <img src="<%# Eval("Imagenes[0].Url") %>" alt="<%# Eval("Nombre") %>" class="product-img">
                        </div>
                        <div class="cart-info">
                            <h5><%# Eval("Nombre") %></h5>
                            <p class="price">$<%# Eval("Precio") %></p>
                            <div class="quantity">
                                <button class="btn btn-outline-dark">−</button>
                                <span class="qty">2</span>
                                <button class="btn btn-outline-dark">+</button>
                            </div>
                        </div>
                        <button class="btn btn-link text-danger">
                            <i class="fa-solid fa-trash"></i>
                        </button>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="text-end">
                <h2 class="mt-2 mb-2">Total</h2>
                <asp:Label ID="montoTotal" runat="server" Text="A definir" CssClass="d-block mb-4"></asp:Label>
            </div>

            <div class="text-center mb-4">
                <asp:Button ID="btnVaciar" runat="server" Text='Vaciar carrito' CssClass="btn btn-danger btn-lg w-60  me-2" OnClick="Button2_Click" />
                <asp:Button ID="btnComprar" runat="server" Text='Comprar' CssClass=" btn btn-success btn-lg w-60 ms-2" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
