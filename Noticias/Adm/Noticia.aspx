<%@ Page Title="" Language="C#" MasterPageFile="~/Adm/Site.Adm.Master" AutoEventWireup="true" CodeBehind="Noticia.aspx.cs" Inherits="Noticias.Adm.Noticia" %>

<%@ Register Src="~/Adm/BarraEdicao.ascx" TagPrefix="uc1" TagName="BarraEdicao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="updatePanelNoticia" runat="server">
        <ContentTemplate>
            <h1>Noticias</h1>
            <p>
                <asp:Button ID="btListagem" runat="server" OnClick="btListagem_Click" CssClass="btn-default btn" Text="Listagem" />
                <asp:Button ID="btCadastro" runat="server" OnClick="btCadastro_Click" CssClass="btn-default btn" Text="Cadastro" />
            </p>
         
            <asp:MultiView ID="MultiViewNoticia" runat="server">
                <asp:View ID="tabListagem" runat="server">
                    <h2>Listagem</h2>
                    <div class="row">

                        <asp:GridView CssClass="table-bordered table table-striped" ID="grdNoticia" runat="server"
                                AutoGenerateColumns="False" DataKeyNames="not_id" DataSourceID="dsNoticia"
                            OnSelectedIndexChanged="grdNoticia_SelectedIndexChanged" 
                            AllowSorting="True">
                            <Columns>
                                <asp:BoundField DataField="not_id" HeaderText="Id" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="not_id" />
                                <asp:BoundField DataField="not_titulo" HeaderText="Título" 
                                    SortExpression="not_titulo" />
                                <asp:BoundField DataField="not_data" HeaderText="Data" 
                                    SortExpression="not_data" />
                                <asp:BoundField DataField="cat_nome" HeaderText="Categoria" 
                                    SortExpression="cat_nome" />
                                            <asp:CommandField HeaderText="Selecionar" SelectText="Selecionar" ButtonType="Button" ControlStyle-CssClass="btn btn-info" ShowSelectButton="true"/>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="dsNoticia" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData"
                            TypeName="DsGeralTableAdapters.TbNoticiaTableAdapter" 
                            />

                    </div>
                </asp:View>
                <asp:View ID="tabCadastro" runat="server">
                    <h2>Cadastro</h2>
                    <div>
                        <uc1:BarraEdicao runat="server" ID="BarraEdicao" />
                    </div>
                    <br />
                    <div>
                        <asp:TextBox ID="edtNotId" runat="server" Visible="false" />
                        <div>
                            <asp:Label ID="Label1" Text="Título:" runat="server" />
                            <asp:TextBox ID="edtNotTit" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>                        
                   </div>
                   <div>
                        <div>
                            <asp:Label ID="Label2" Text="Texto:" runat="server" />
                            <asp:TextBox Rows="5" ID="edtNotTex" runat="server" 
                            CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div>
                            <asp:Label ID="Label3" Text="Data:" runat="server" />
                            <asp:TextBox Rows="5" ID="edtNotData" runat="server" 
                            CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div>
                            <asp:Label ID="Label4" Text="Imagem:" runat="server" />
                            <asp:TextBox Rows="5" ID="edtImagem" runat="server" 
                            CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <div>
                            <asp:Label ID="Label5" Text="Cat id:" runat="server" />
                            <asp:TextBox Rows="5" ID="edtCatId" runat="server" 
                            CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>