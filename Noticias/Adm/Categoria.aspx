<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/Site.Adm.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Noticias.Adm.Categoria" %>

<%@ Register Src="~/Adm/BarraEdicao.ascx" TagPrefix="uc1" TagName="BarraEdicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanelCategoria" runat="server">
        <ContentTemplate>
            <p>
                <asp:Button ID="btnListagem" runat="server" Text="Listagem"
                    OnClick="btnListagem_Click" />
                <asp:Button ID="btnCadastro" runat="server" Text="Cadastro"
                    OnClick="btnCadastro_Click" />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Noticias.App.DsGeralTableAdapters.TbCategoriaTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_cat_id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="cat_nome" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="cat_nome" Type="String" />
                        <asp:Parameter Name="Original_cat_id" Type="Int32" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </p>
           
            <asp:MultiView ID="MultiViewCategoria" runat="server">
                <asp:View ID="tabListagem" runat="server">
                    <p>Listagem de Categorias</p>
                   
                    <asp:GridView ID="grdCategoria" runat="server" AutoGenerateColumns="False" 
                        AllowSorting="true" DataKeyNames="cat_id" DataSourceID="ObjectDataSource1"
                        OnSelectedIndexChanged="grdCategoria_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="cat_id" HeaderText="Código"
                                InsertVisible="False" ReadOnly="True" SortExpression="cat_id" />
                    
                            <asp:BoundField DataField="cat_nome" HeaderText="Nome"
                                SortExpression="cat_nome" />

                            <asp:CommandField HeaderText="Selecionar" SelectText="Selecionar"
                                ButtonType="Button" ShowSelectButton="true" />
                        </Columns>
                    </asp:GridView>
    
                    <asp:ObjectDataSource ID="dsCategoria" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
                        TypeName="DsGeralTableAdapters.TbCategoriaTableAdapter">

                    </asp:ObjectDataSource>

                </asp:View>

                <asp:View ID="tabCadastro" runat="server">
                    <asp:TextBox ID="edtCatId" runat="server" Visible="false" />
            
                    <p><uc1:BarraEdicao runat="server" ID="BarraEdicao" /></p>

                    Nome:<br />
                    <asp:TextBox ID="edtCatNome" runat="server"></asp:TextBox>
                </asp:View>

            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
