<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="rDestinatario.aspx.cs" Inherits="CartaWeb.UI.Registro.rDestinatario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr>
        <h2 style="color: #3366FF">Registro de Destinatario</h2>
        <hr>
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group row">
                <label class="control-label col-sm-2" for="DestinatarioidTextBox">Deposito ID:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="DestinatarioidTextBox" Text="0" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary btn-sm" OnClick="BuscarButton_Click" />
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="FechaTextBox">Fecha:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox ID="FechaTextBox" class="form-control input-group" TextMode="Date" runat="server" Enabled="true" ReadOnly="True" />
                </div>
            </div>
            <br>
            <div class="form-group row">
                <label class="control-label col-sm-2" for="NombreTextBox">Nombre:</label>
                <div class="col-sm-1 col-md-5">
                    <asp:TextBox type="text" class="form-control" ID="NombreTextBox" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label class="control-label col-sm-2" for="CETextBox">Cartas Enviadas:</label>
                <div class="col-sm-1 col-md-4 col-xs6">
                    <asp:TextBox type="Number" class="form-control" ID="CETextBox" Text="0" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <hr>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" class="btn btn-warning btn-sm" OnClick="BtnNuevo_Click" />
                        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" class="btn btn-success btn-sm" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" class="btn btn-danger btn-sm" OnClick="BtnEliminar_Click" />
                    </div>
                </div>
            </div>
            <hr>
        </div>
    </div>
</asp:Content>
