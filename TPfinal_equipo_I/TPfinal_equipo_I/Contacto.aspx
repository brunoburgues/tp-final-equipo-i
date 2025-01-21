<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPfinal_equipo_I.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center titulo">Tu consulta es bienvenida.</h1>


    <br />
    <div class="contacto row d-flex justify-content-center align-items-center">
        <div class="col">
            <div class="row g-3">
                <asp:Label runat="server" class="form-label" ID="lblPrueba" />

                <div class="col-md-12">
                    <label for="txtEmail" class="form-label">Correo Electrónico</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                </div>
                <div class="col-md-6">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" />
                </div>
                <div class="col-md-6">
                    <label for="txtAsunto" class="form-label">Motivo de Consulta</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtAsunto" />
                </div>
                <div class="col-12">
                    <label for="txtMensaje" class="form-label">Mensaje</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtMensaje" Height="60px" />
                </div>

                <div class="col-12 text-center mt-5 mb-3">
                    <asp:Button Text="Enviar Consulta!" CssClass="btn btn-success mb-4 text-center" ID="btnConsulta" OnClick="btnConsulta_Click" runat="server" Width="134px" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
