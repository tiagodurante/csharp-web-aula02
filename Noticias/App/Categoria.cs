using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noticias.App
{
    public class Categoria
    {
        #region Atributos

        private DsGeralTableAdapters.TbCategoriaTableAdapter dsCategoria = new DsGeralTableAdapters.TbCategoriaTableAdapter();
        private int cat_id;
        private string cat_nome;

        public int Cat_id
        {
            get { return cat_id; }
        }

        public string Cat_nome
        {
            get { return cat_nome; }
            set { cat_nome = value; }
        }

        #endregion

        #region Contrutores

        public Categoria()
        {
        }

        public Categoria(int cat_id)
        {
            DsGeral.TbCategoriaDataTable tbCategoria = new DsGeral.TbCategoriaDataTable();
            dsCategoria.FillByCatId(tbCategoria, cat_id);

            if (tbCategoria.Rows.Count > 0)
            {
                DsGeral.TbCategoriaRow regCategoria = (DsGeral.TbCategoriaRow)tbCategoria.Rows[0];
                this.cat_id = regCategoria.cat_id;
                this.cat_nome = regCategoria.cat_nome;
                //this.cat_nome = tbCategoria.Rows[0]["cat_nome"].ToString();
            }
        }

        #endregion

        #region Manipulacao Dados

        private string validarCampos(string cat_nome)
        {
            if (string.IsNullOrEmpty(cat_nome))
                return "O nome da categoria deve ser informado!";
            return "";
        }

        public string inserir(string cat_nome)
        {
            string retorno = validarCampos(cat_nome);
            //if (string.IsNullOrEmpty(retorno) == false)
            if (!string.IsNullOrEmpty(retorno))
                return retorno;

            try
            {
                dsCategoria.Insert(cat_nome);
                return "";
            }
            catch (Exception e)
            {
                return "Erro ao inserir a categoria: " + e.Message;
            }
        }

        public string editar(int cat_id, string cat_nome)
        {
            string retorno = validarCampos(cat_nome);
            if (!string.IsNullOrEmpty(retorno))
                return retorno;

            try
            {
                dsCategoria.Update(cat_nome, cat_id);
                return "";
            }
            catch (Exception e)
            {
                return "Erro ao editar a categoria: " + e.Message;
            }
        }

        public string excluir(int cat_id)
        {
            try
            {
                dsCategoria.Delete(cat_id);
                return "";
            }
            catch (Exception e)
            {
                return "Erro ao excluir a categoria: " + e.Message;
            }
        }

        #endregion

    }
}