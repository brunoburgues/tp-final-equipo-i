<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPfinal_equipo_I.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default-buscador d-flex justify-content-end ">
        <div class="d-flex mb-4" style="width: 530px" role="search">
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control me-2" aria-label="Search" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged1" />
            <asp:CheckBox ID="chkAdvanceFilter" runat="server" CssClass="=form-control" Text="Busqueda avanzada" OnCheckedChanged="chkAdvanceFilter_CheckedChanged" />
        </div>
    </div>
    <%if (chkAdvanceFilter.Checked)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="Campo" runat="server" Text="Campo"></asp:Label>
                <asp:DropDownList runat="server" CssClass="form-select" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" Value="Nombre"></asp:ListItem>
                    <asp:ListItem Text="Precio" Value="Precio"></asp:ListItem>
                    <asp:ListItem Text="Categoria" Value="Categoria"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Igual" Value="Igual"></asp:ListItem>
                    <asp:ListItem Text="Mayor" Value="Mayor"></asp:ListItem>
                    <asp:ListItem Text="Menor" Value="Menor"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <%} %>
    <h2 class="titulo text-center">¡Ofertas de la Semana!</h2>
    <div class="container mb-4">
        <div class="d-flex justify-content-center align-items-center flex-wrap gap-3 default-cards-container">
            <asp:Repeater runat="server" ID="idRepeater">
                <ItemTemplate>
                    <div class="card" style="width: 18rem; height: 25rem">
                        <div class="d-flex justify-content-center align-items-center">
                            <div class="img-container">
                                <img src='<%# ObtenerUrlImagen(Eval("Imagenes")) %>' class="card-img-top" alt="Imagen no disponible">
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
    <h2 class="titulo text-center">Productos más vendidos</h2>
    <div class="container mb-4">
        <div class="d-flex justify-content-center align-items-center flex-wrap gap-3 default-cards-container">
            <asp:Repeater runat="server" ID="repeaterMasVendidos">
                <ItemTemplate>
                    <div class="card" style="width: 18rem; height: 25rem">
                        <div class="d-flex justify-content-center align-items-center">
                            <div class="img-container">
                                <img src='<%# ObtenerUrlImagen(Eval("Imagenes")) %>' class="card-img-top" alt="Imagen no disponible">
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
    <h2 class="titulo text-center">Todos los productos</h2>
    <div class="container mb-4">
        <div class="d-flex justify-content-center align-items-center flex-wrap gap-3 default-cards-container">
            <asp:Repeater runat="server" ID="repeaterProductos">
                <ItemTemplate>
                    <div class="card" style="width: 18rem; height: 25rem">
                        <div class="d-flex justify-content-center align-items-center">
                            <div class="img-container">
                                <img src='<%# ObtenerUrlImagen(Eval("Imagenes")) %>' class="card-img-top" alt="Imagen no disponible">
                                
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
