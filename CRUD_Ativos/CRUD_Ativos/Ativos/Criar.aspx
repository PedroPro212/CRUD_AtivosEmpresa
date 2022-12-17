<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Criar.aspx.cs" Inherits="CRUD_Ativos.Ativos.Criar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <p>Descrição:</p>
                <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
                <p>Valor:</p>
                <asp:TextBox runat="server" ID="txtValor"></asp:TextBox>
                <p>Quantidade:</p>
                <asp:TextBox runat="server" ID="txtQts" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-sm-6">
                <p>Setor:</p>
                <asp:DropDownList runat="server" ID="ddlSetor"></asp:DropDownList>
                <p>Cidade:</p>
                <asp:DropDownList runat="server" ID="ddlCidade"></asp:DropDownList>
            </div>
            <div class="col-sm-12 text-center"><asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" /></div>
        </div>
    </div>
</asp:Content>
