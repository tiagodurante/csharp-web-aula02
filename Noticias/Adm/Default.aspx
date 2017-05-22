<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Noticias.Adm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <script>
        $(function () {
            $("#edtLogin").focus();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">
            <p>
                Login: <br />    
                <asp:TextBox ID="edtLogin" runat="server" ClientIDMode="Static"></asp:TextBox>
            </p>
            <p>
                Senha: <br />    
                <asp:TextBox ID="edtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </p>
        </asp:Panel>
    </div>
    </form>
</body>
</html>