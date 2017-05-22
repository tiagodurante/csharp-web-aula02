using System;

namespace Noticias.Adm
{
    public partial class Site_Adm : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica se tem usuario logado na sessão
            if (!App.Funcoes.verUsuarioLogado(Session["Usuario"] as App.Usuario))
                Response.Redirect("~/Adm");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            // Limpar todas as sessoes do site do usuario para encerrar 
            Session.Abandon();
            Response.Redirect("~/Adm");
        }
    }
}