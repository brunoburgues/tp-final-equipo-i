<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TPfinal_equipo_I.articulos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Lista de artículos</h1>
    <div class="row">
    <div class="col-6">
        <div class="mb-3">
    <asp:Label Text="Filtrar" runat="server" />
    <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="Filtro_TextChanged"/>
    
   </div> </div></div>
    <columns>
    <asp:gridview id="GridView1" runat="server" onSelectedIndexChanged="GridView1_SelectedIndexChanged" autogeneratecolumns="False" datakeynames="Id"  cssClass=" table table-success table-striped table-responsive" width="100%">
        <Columns>
            <asp:Boundfield datafield="nombre" headertext="nombre" sortexpression="nombre" />
            <asp:Boundfield datafield="precio" headertext="precio" sortexpression="precio" />
            <asp:Boundfield datafield="stock" headertext="stock" sortexpression="stock" />
           
            <asp:Boundfield datafield="categoria" headertext="categoria" sortexpression="categoria" />
            <asp:CommandField AccessibleHeaderText="Comandos" ShowSelectButton="True" SelectText="Seleccionar" />
        </columns>
          </asp:gridview>
            <a href="Agregar.aspx" class="btn btn-outline-primary">Agregar</a>
</asp:Content>
