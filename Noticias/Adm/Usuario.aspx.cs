using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Noticias.Adm
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                btnListagem_Click(null, null);
            MultiViewUsuario.ActiveViewIndex = 0;
            BarraEdicao.BtnNovo.Click += btnNovo_Click;
            BarraEdicao.BtnAlterar.Click += btnAlterar_Click;
            BarraEdicao.BtnGravar.Click += btnGravar_Click;
            BarraEdicao.BtnCancelar.Click += btnCancelar_Click;
            BarraEdicao.BtnExcluir.Click += btnExcluir_Click;
        }


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
                habilitarCampos(false);
        }

        private int retornaIdSelecionado()
        {
            if (grdUsuario.SelectedDataKey != null)
                return int.Parse(grdUsuario.SelectedDataKey[0].ToString());
            else
                return 0;
        }

        private void atualizarCampos(int usu_id)
        {
            if (usu_id <= 0)
            {
                edtUsuId.Text = "";
                edtUsuNome.Text = "";
            }
            else
            {
                App.Usuario usu = new App.Usuario(usu_id);
                edtUsuId.Text = usu.Usu_id.ToString();
                edtUsuNome.Text = usu.Usu_nome;
            }
        }

        private void habilitarCampos(bool habilitar)
        {
            edtUsuNome.Enabled = habilitar;
            BarraEdicao.BtnGravar.Enabled = habilitar;
            BarraEdicao.BtnCancelar.Enabled = habilitar;

            habilitar = !habilitar;
            BarraEdicao.BtnNovo.Enabled = habilitar;
            BarraEdicao.BtnAlterar.Enabled = habilitar;
            BarraEdicao.BtnExcluir.Enabled = habilitar;
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            atualizarCampos(0);
            habilitarCampos(true);
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            habilitarCampos(!string.IsNullOrEmpty(edtUsuId.Text));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            atualizarCampos(retornaIdSelecionado());
            habilitarCampos(false);
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            string retorno;
            App.Usuario usu = new App.Usuario();

            if (string.IsNullOrEmpty(edtUsuId.Text))
            {
                retorno = usu.salvar(int.Parse(edtUsuId.Text),
                                     edtUsuNome.Text,
                                     edtUsuLogin.Text,
                                     edtUsuSenha.Text,  // Convert.ToString(123),
                                     ckUsuAtivo.Checked);
            }
            else
            {
                retorno = usu.salvar(int.Parse(edtUsuId.Text),
                                         edtUsuNome.Text,
                                         edtUsuLogin.Text,
                                         edtUsuSenha.Text,
                                         ckUsuAtivo.Checked);
            }


            if (!string.IsNullOrEmpty(retorno))
            {
                App.Funcoes.mostrarMensagem(this, retorno);
                return;
            }
            else
            {
                App.Funcoes.mostrarMensagem(this, "Registro salvo com sucesso!");
            }

            habilitarCampos(false);
            atualizarDados();
        }

        private void atualizarDados()
        {
            dsUsuario.DataBind();
            grdUsuario.DataBind();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtUsuId.Text))
                return;

            App.Usuario usu = new App.Usuario();
            string retorno = usu.excluir(int.Parse(edtUsuId.Text));

            if (!string.IsNullOrEmpty(retorno))
            {
                App.Funcoes.mostrarMensagem(this, retorno);
                return;
            }
            else
            {
                App.Funcoes.mostrarMensagem(this, "Registro excluído com sucesso!");
            }
            atualizarCampos(0);
            atualizarDados();
        }

        protected void grdUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarCampos(retornaIdSelecionado());
            btnCadastro_Click(null, null);
        }


        protected void btnListagem_Click(object sender, EventArgs e)
        {
            MultiViewUsuario.ActiveViewIndex = 0;
        }
        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            MultiViewUsuario.ActiveViewIndex = 1;
        }



    }
}
