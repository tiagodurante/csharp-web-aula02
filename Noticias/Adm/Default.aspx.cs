using System;


namespace Noticias.Adm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Se o cara ja tiver logado entao ja manda ele para o dashboard
            if (!IsPostBack)
            {
                if (App.Funcoes.verUsuarioLogado(Session["Usuario"] as App.Usuario))
                    Response.Redirect("~/Adm/Inicio.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Varifica as permissoes do login no banco
            App.ControleLogin cl = new App.ControleLogin();

            if (cl.logar(edtLogin.Text, edtSenha.Text))
            {
                App.Usuario usuario = new App.Usuario(edtLogin.Text);
                // Add o usuario na session
                Session["Usuario"] = usuario;
                //var pathPagAtual = Request.CurrentExecutionFilePath;
                Response.Redirect("~/Adm/Inicio.aspx");
            }
            else
            {
                App.Funcoes.mostrarMensagem(this, "Usuário ou senha inválidos!");
            }

        }
    }

}
