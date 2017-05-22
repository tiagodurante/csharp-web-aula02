using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Noticias.Adm
{
    public partial class BarraEdicao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Button BtnNovo
        {
            get { return btnNovo; }
            set { btnNovo = value; }
        }
        public Button BtnAlterar
        {
            get { return btnAlterar; }
            set { btnAlterar = value; }
        }
        public Button BtnGravar
        {
            get { return btnGravar; }
            set { btnGravar = value; }
        }
        public Button BtnCancelar
        {
            get { return btnCancelar; }
            set { btnCancelar = value; }
        }
        public Button BtnExcluir
        {
            get { return btnExcluir; }
            set { btnExcluir = value; }
        }

    }
}