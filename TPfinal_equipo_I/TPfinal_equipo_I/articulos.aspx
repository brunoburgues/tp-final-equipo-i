<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="articulos.aspx.cs" Inherits="TPfinal_equipo_I.articulos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <columns>
    <asp:gridview id="GridView1" runat="server" onSelectedIndexChanged="GridView1_SelectedIndexChanged" autogeneratecolumns="False" datakeynames="id" datasourceid="SqlDataSource1" cssClass=" table table-success table-striped table-responsive" width="100%">
        <Columns>
            <asp:Boundfield datafield="nombre" headertext="nombre" sortexpression="nombre" />
            <asp:Boundfield datafield="precio" headertext="precio" sortexpression="precio" />
            <asp:Boundfield datafield="stock" headertext="stock" sortexpression="stock" />
            <asp:Boundfield datafield="imagen" headertext="imagen" sortexpression="imagen" />
            <asp:Boundfield datafield="categoria" headertext="categoria" sortexpression="categoria" />
            <asp:CommandField AccessibleHeaderText="Comandos" ShowSelectButton="True" SelectText="Seleccionar" />
        </columns>
          </asp:gridview>
</asp:Content>
