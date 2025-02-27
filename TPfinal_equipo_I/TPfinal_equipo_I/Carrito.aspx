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
            <asp:UpdatePanel runat="server" ID="panelArticulos">
                <ContentTemplate>
                    <asp:Repeater runat="server" ID="repArticulos" OnItemCommand="repArticulos_ItemCommand" OnItemDataBound="repArticulos_ItemDataBound">
                        <ItemTemplate>
                            <div class="cart-item containerArticulo d-flex align-items-center mb-3">
                                <div class="carrito-img-container">
                                    <img src="<%# Eval("ImagenUrl") %>" alt="<%# Eval("Nombre") %>" class="product-img">
                                </div>
                                <div class="cart-info">
                                    <h5><%# Eval("Nombre") %></h5>
                                    <p class="price">$<%# formatoPrecio(Convert.ToDecimal(Eval("Precio"))) %></p>
                                    <div class="quantity">
                                        <asp:Button ID="btnMenos" Text="-" runat="server" CssClass="btn btn-outline-dark" CommandName="Menos" CommandArgument='<%# Eval("IdArticulo") + "," + Eval("IdCarrito") %>' />
                                        <asp:Label ID="lblCantidad" Text='<%# Eval("Cantidad") %>' runat="server" CssClass="qty" />
                                        <asp:Button ID="btnMas" Text="+" runat="server" CssClass="btn btn-outline-dark" CommandName="Mas" CommandArgument='<%# Eval("IdArticulo") + "," + Eval("IdCarrito") %>' />
                                    </div>
                                </div>

                                <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-link text-danger" htmlEncode="false" Text='<i class="fa-solid fa-trash"></i>' CommandName='Eliminar' CommandArgument='<%# Eval("Id") + "," + Eval("IdCarrito") %>'>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="text-end">
                        <h2 class="mt-2 mb-2">Total</h2>
                        <asp:Label ID="montoTotal" runat="server" Text="A definir" CssClass="d-block mb-4"></asp:Label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="text-center mb-4">
                <asp:Button ID="btnVaciar" runat="server" Text='Vaciar carrito' CssClass="btn btn-danger btn-lg w-60  me-2" OnClick="btnVaciar_Click" />
                <asp:Button ID="btnComprar" runat="server" Text='Comprar' CssClass=" btn btn-success btn-lg w-60 ms-2" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
