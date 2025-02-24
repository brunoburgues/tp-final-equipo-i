<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPfinal_equipo_I.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1>Lista de categorías</h1>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
    </div>
    </div>
    <columns>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="id" CssClass=" table table-success table-striped table-responsive" Width="100%">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="nombre" SortExpression="Descripcion" />
                <asp:CommandField AccessibleHeaderText="Comandos" ShowSelectButton="True" SelectText="Seleccionar" />
            </Columns>
        </asp:GridView>
        <a href="AgregarCategoria.aspx" class="btn btn-outline-primary">Agregar</a>
        <a href="Default.aspx" class="btn btn-outline-cancel" > Volver</a>
        
    </columns>

</asp:Content>
