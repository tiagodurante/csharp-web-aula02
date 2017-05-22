using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Noticias.App
{
    public class Usuario
    {

        #region Atributos

        private DsGeralTableAdapters.TbUsuarioTableAdapter dsUsuario = new DsGeralTableAdapters.TbUsuarioTableAdapter();
        private int usu_id;
        private string usu_nome;
        private string usu_login;
        private string usu_senha;
        private bool usu_ativo;
        private string p;

        public int Usu_id
        {
            get { return usu_id; }
        }
        public string Usu_nome
        {
            get { return usu_nome; }
            set { usu_nome = value; }
        }
        public string Usu_login
        {
            get { return usu_login; }
            set { usu_login = value; }
        }
        public string Usu_senha
        {
            get { return usu_senha; }
            set { usu_senha = value; }
        }
        public bool Usu_ativo
        {
            get { return usu_ativo; }
            set { usu_ativo = value; }
        }

        #endregion

        #region Contrutores

        public Usuario()
        {
        }

        public Usuario(int usu_id)
        {
            DsGeral.TbUsuarioDataTable tbUsuario = new DsGeral.TbUsuarioDataTable();
            dsUsuario.FillByUsuId(tbUsuario, usu_id);
            popularUsuario(tbUsuario);
        }

        public Usuario(string usu_login)
        {
            //dsUsuario.FillByUsuLogin(tbUsuario, usu_login);
            DsGeral.TbUsuarioDataTable tbUsuario = new DsGeral.TbUsuarioDataTable();
            dsUsuario.FillByUsuId(tbUsuario, usu_id);
            popularUsuario(tbUsuario);
        }

        private void popularUsuario(DsGeral.TbUsuarioDataTable tbUsuario)
        {
            if (tbUsuario.Rows.Count > 0)
            {
                DsGeral.TbUsuarioRow regUsuario = (DsGeral.TbUsuarioRow)tbUsuario.Rows[0];
                this.usu_id = regUsuario.usu_id;
                this.usu_nome = regUsuario.usu_nome;
                this.usu_login = regUsuario.usu_login;
                this.usu_senha = regUsuario.usu_senha;
                this.usu_ativo = regUsuario.usu_ativo;
            }
        }

        public string salvar(int usu_id, string usu_nome, string usu_login, string usu_senha, bool usu_ativo)
        {
            if (string.IsNullOrEmpty(usu_nome))
                return "O nome do usuário deve ser informado!";

            if (string.IsNullOrEmpty(usu_login))
                return "O login do usuário deve ser informado!";

            if (string.IsNullOrEmpty(usu_senha))
                return "A senha do usuário deve ser informada!";

            try
            {
                if (usu_id > 0)
                {
                    if (usu_senha.Equals("123"))
                        dsUsuario.UpdateQuery(usu_nome, usu_login, usu_ativo, usu_id);
                    else
                        dsUsuario.Update(usu_nome, usu_login, usu_senha, usu_ativo, usu_id);
                }
                else
                {
                    dsUsuario.Insert(usu_nome, usu_login, usu_senha, usu_ativo);
                }
                return "";
            }
            catch (Exception e)
            {
                return "Erro ao + o usuário: " + e.Message;
            }
        }

        public string excluir(int usu_id)
        {
            try
            {
                dsUsuario.Delete(usu_id);
                return "";
            }
            catch (Exception e)
            {
                return "Erro ao excluir o usuário: " + e.Message;
            }
        }
        #endregion
    }
}
