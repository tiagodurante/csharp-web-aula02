<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Noticias.Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource2" DataKeyNames="cat_id">
        <LayoutTemplate>
            <table class="table table-striped" runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                <th runat="server">Código</th>
                                <th runat="server">Descrição da Categoria</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF"></td>
                </tr>
            </table>
        </LayoutTemplate>
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF;color: #284775;">
                <td>
                    <asp:Label ID="cat_idLabel" runat="server" Text='<%# Eval("cat_id") %>' />
                </td>
                <td>
                    <asp:Label ID="cat_nomeLabel" runat="server" Text='<%# Eval("cat_nome") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #999999;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="cat_idLabel1" runat="server" Text='<%# Eval("cat_id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="cat_nomeTextBox" runat="server" Text='<%# Bind("cat_nome") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="cat_nomeTextBox" runat="server" Text='<%# Bind("cat_nome") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF;color: #333333;">
                <td>
                    <asp:Label ID="cat_idLabel" runat="server" Text='<%# Eval("cat_id") %>' />
                </td>
                <td>
                    <asp:Label ID="cat_nomeLabel" runat="server" Text='<%# Eval("cat_nome") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                <td>
                    <asp:Label ID="cat_idLabel" runat="server" Text='<%# Eval("cat_id") %>' />
                </td>
                <td>
                    <asp:Label ID="cat_nomeLabel" runat="server" Text='<%# Eval("cat_nome") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Noticias.App.DsGeralTableAdapters.TbCategoriaTableAdapter" UpdateMethod="Update">
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
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DsGeralTableAdapters.TbCategoriaTableAdapter"></asp:ObjectDataSource>
    <br />
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="4" QueryStringField="Pag">
        <Fields>
            <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="<<" ShowNextPageButton="true" NextPageText="<" ShowLastPageButton="false" ShowPreviousPageButton="false" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="false" ShowLastPageButton="true"  LastPageText=">>" ShowPreviousPageButton="true" PreviousPageText=">" />
        </Fields>
    </asp:DataPager>
</asp:Content>
