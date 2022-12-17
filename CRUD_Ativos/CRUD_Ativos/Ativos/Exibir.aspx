<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exibir.aspx.cs" Inherits="CRUD_Ativos.Ativos.Exibir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-2">
                <asp:Button runat="server" ID="btnCadastrar" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>
            <div class="col-sm-8">
                <asp:TextBox runat="server" ID="txtDescricao" placeholder="Digite o nome:"></asp:TextBox>
                <asp:Button runat="server" ID="btnPesquisar" Text="Pesquisar" OnClick="btnPesquisar_Click" />

                <div style="margin-top:15px;">
                    <asp:GridView runat="server" ID="grdAtivos" Width="80%" AutoGenerateColumns="false" 
                        CssClass="table table-condensed" OnRowCommand="grdAtivos_RowCommand" 
                        AllowPaging="false" OnRowDataBound="grdAtivos_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="descricao" HeaderText="DESCRIÇÃO" />
                            <asp:BoundField DataField="valor" HeaderText="VALOR" />
                            <asp:BoundField DataField="quantidade" HeaderText="QUANTIDADE" />
                            <asp:ButtonField ButtonType="Link" CommandName="editar" ControlStyle-CssClass="btn btn-warning" Text="Editar" ItemStyle-HorizontalAlign="Center" />
                            <asp:ButtonField ButtonType="Link" CommandName="excluir" ControlStyle-CssClass="btn btn-danger" Text="Excluir" ItemStyle-HorizontalAlign="Center" />
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
