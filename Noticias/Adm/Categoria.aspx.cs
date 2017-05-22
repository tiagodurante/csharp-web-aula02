using System;

namespace Noticias.Adm
{
    public partial class Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                btnListagem_Click(null, null);

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
            if (grdCategoria.SelectedDataKey != null)
                return int.Parse(grdCategoria.SelectedDataKey[0].ToString());
            else
                return 0;
        }

        protected void btnListagem_Click(object sender, EventArgs e)
        {
            MultiViewCategoria.ActiveViewIndex = 0;
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            MultiViewCategoria.ActiveViewIndex = 1;
        }

        private void atualizarCampos(int cat_id)
        {
            if (cat_id <= 0)
            {
                edtCatId.Text = "";
                edtCatNome.Text = "";
            }
            else
            {
                App.Categoria cat = new App.Categoria(cat_id);
                edtCatId.Text = cat.Cat_id.ToString();
                edtCatNome.Text = cat.Cat_nome;
            }
        }

        private void habilitarCampos(bool habilitar)
        {
            edtCatNome.Enabled = habilitar;
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
            habilitarCampos(!string.IsNullOrEmpty(edtCatId.Text));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            atualizarCampos(retornaIdSelecionado());
            habilitarCampos(false);
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            string retorno;
            App.Categoria cat = new App.Categoria();

            if (string.IsNullOrEmpty(edtCatId.Text))
                retorno = cat.inserir(edtCatNome.Text);
            else
                retorno = cat.editar(int.Parse(edtCatId.Text), edtCatNome.Text);

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
            dsCategoria.DataBind();
            grdCategoria.DataBind();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtCatId.Text))
                return;

            App.Categoria cat = new App.Categoria();
            string retorno = cat.excluir(int.Parse(edtCatId.Text));
            
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

        protected void grdCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarCampos(retornaIdSelecionado());
            btnCadastro_Click(null, null);
        }
    }
}