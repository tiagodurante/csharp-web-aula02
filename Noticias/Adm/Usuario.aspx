<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/Site.Adm.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Noticias.Adm.Usuario" %>

<%@ Register Src="~/Adm/BarraEdicao.ascx" TagPrefix="uc1" TagName="BarraEdicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <p>
                <asp:Button ID="btnListagem" runat="server" Text="Listagem"
                    OnClick="btnListagem_Click" />
                <asp:Button ID="btnCadastro" runat="server" Text="Cadastro"
                    OnClick="btnCadastro_Click" />
            </p>

            <asp:MultiView ID="MultiViewUsuario" runat="server">
               
                 <asp:View ID="tabListagem" runat="server">
                     
                    <asp:Panel ID="pnBuscar" runat="server" DefaultButton="btnBuscar">
                        Buscar: <asp:TextBox ID="edtBuscar" runat="server" Width="160px" />
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />

                    </asp:Panel>
                                                              
                    <p>Listagem de Usuários</p>
                    
                    <asp:GridView ID="grdUsuario" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="usu_id" DataSourceID="dsUsuario" AllowSorting="True" 
                        OnSelectedIndexChanged="grdUsuario_SelectedIndexChanged">
                       
                        <Columns>
                            <asp:BoundField DataField="usu_id" HeaderText="usu_id" InsertVisible="False" ReadOnly="True" SortExpression="usu_id" />
                            <asp:BoundField DataField="usu_nome" HeaderText="usu_nome" SortExpression="usu_nome" />
                            <asp:BoundField DataField="usu_login" HeaderText="usu_login" SortExpression="usu_login" />
                            <asp:BoundField DataField="usu_senha" HeaderText="usu_senha" SortExpression="usu_senha" />
                            <asp:CheckBoxField DataField="usu_ativo" HeaderText="usu_ativo" SortExpression="usu_ativo" />

                            <asp:CommandField ButtonType="Button" HeaderText="Selecionar" SelectText="Selecionar" ShowSelectButton="True" />

                        </Columns>
                       
                    </asp:GridView>

                    <asp:ObjectDataSource ID="dsUsuario" runat="server" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetData" TypeName="Noticias.App.DsGeralTableAdapters.TbUsuarioTableAdapter" 
                        DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update" >
                        <DeleteParameters>
                            <asp:Parameter Name="Original_usu_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="usu_nome" Type="String" />
                            <asp:Parameter Name="usu_login" Type="String" />
                            <asp:Parameter Name="usu_senha" Type="String" />
                            <asp:Parameter Name="usu_ativo" Type="Boolean" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="usu_nome" Type="String" />
                            <asp:Parameter Name="usu_login" Type="String" />
                            <asp:Parameter Name="usu_senha" Type="String" />
                            <asp:Parameter Name="usu_ativo" Type="Boolean" />
                            <asp:Parameter Name="Original_usu_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>

                </asp:View>

                <asp:View ID="tabCadastro" runat="server">
                
                    <asp:TextBox ID="edtUsuId" runat="server" Visible="false" />

                    <p><uc1:BarraEdicao runat="server" ID="BarraEdicao" /></p>

                    <p>
                        Nome:<br />
                        <asp:TextBox ID="edtUsuNome" runat="server"></asp:TextBox>
                    <p>
                    <p>
                        Login:<br />
                        <asp:TextBox ID="edtUsuLogin" runat="server"></asp:TextBox>
                    <p>
                    <p>
                        Senha:<br />
                        <asp:TextBox ID="edtUsuSenha" runat="server" TextMode="Password" ></asp:TextBox>                      
                    <p>
                    <p>
                        Ativo:<br />
                        <asp:CheckBox ID="ckUsuAtivo" runat="server" Text="Ativo"></asp:CheckBox>
                    <p>

                </asp:View>

            </asp:MultiView>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
