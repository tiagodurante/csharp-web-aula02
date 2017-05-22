using System;

namespace Noticias.App
{
    public class Noticia
    {
        private DsGeralTableAdapters.TbNoticiaTableAdapter dsNoticia = new DsGeralTableAdapters.TbNoticiaTableAdapter();
        private int not_id;
        private string not_texto;
        private DateTime not_data;
        private string not_imagem;
        private Categoria categoria;

        public Noticia()
        {
        }

        public Noticia(int notid)
        {
            DsGeral.TbNoticiaDataTable tbNoticia = new DsGeral.TbNoticiaDataTable();
            this.dsNoticia.FillByNotId(tbNoticia, notid);
            if (tbNoticia.Rows.Count > 0)
            {
                DsGeral.TbNoticiaRow regNoticia = (DsGeral.TbNoticiaRow)tbNoticia.Rows[0];
                this.not_id = regNoticia.not_id;
                this.Not_titulo = regNoticia.not_titulo;
                this.not_texto = regNoticia.not_texto;
                this.not_imagem = regNoticia.not_imagem;
                this.not_data = regNoticia.not_data;
                Categoria c = new Categoria(regNoticia.cat_id);
                this.categoria = c;
            }
        }

        public int Not_id
        {
            get { return not_id; }
        }

        public string Not_titulo
        {
            get { return Not_titulo; }
            set { Not_titulo = value; }
        }

        public string Not_texto
        {
            get { return not_texto; }
            set { not_texto = value; }
        }

        public DateTime Not_data
        {
            get { return not_data; }
            set { not_data = value; }
        }

        public string Not_imagem
        {
            get { return not_imagem; }
            set { not_imagem = value; }
        }

        public Categoria Categoria_
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string inserir(string not_titulo, string not_texto, DateTime not_data, string not_imagem,
            int cat_id)
        {
            string retorno = validar(not_titulo);
            if (!String.IsNullOrEmpty(retorno))
                return retorno;
            try
            {
                this.dsNoticia.Insert1(not_titulo, not_texto, not_data, not_imagem, cat_id);
            }
            catch (Exception e)
            {
                return "Erro ao inserir a categoria: " + e.Message;
            }
            return "";
        }

        public string editar(int notid, string notTit, string notText, DateTime notDate, string notImage,
            int catid)
        {
            string retorno = validar(notTit);
            if (!String.IsNullOrEmpty(retorno))
                return retorno;
            try
            {
                this.dsNoticia.Update1(notTit, notText, notDate, notImage, catid, notid);
            }
            catch (Exception e)
            {
                return "Erro ao atualizar a categoria: " + e.Message;
            }
            return "";
        }

        public string excluir(int notid)
        {
            try
            {
                this.dsNoticia.Delete1(notid);
            }
            catch (Exception e)
            {
                return "Erro ao atualizar a categoria: " + e.Message;
            }
            return "";
        }

        private string validar(string not_titulo)
        {
            if (String.IsNullOrEmpty(not_titulo))
                return "O o titulo deve ser informado!";
            return "";
        }

    }
}
