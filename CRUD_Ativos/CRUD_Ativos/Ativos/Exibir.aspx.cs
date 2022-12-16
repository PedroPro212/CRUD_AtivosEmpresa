using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Ativos.Ativos
{
    public partial class Exibir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Criar.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var ativos = new Negocio.Ativos().Read("", txtDescricao.Text, "", "");
            Session["dados"] = ativos;
            grdAtivos.DataSource = ativos;
            grdAtivos.DataBind();

            
        }

        protected void grdAtivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var ativos = (List<Classes.Ativos>)Session["dados"];

            if(e.CommandName == "excluir")
            {
                if(new Negocio.Ativos().Delete(ativos[index].Id))
                {
                    SiteMaster.AlertPersonalizado(this, "Ativo excluido com sucesso");
                }
                else
                {
                    SiteMaster.AlertPersonalizado(this, "Algo saiu errado");
                }
                btnCadastrar_Click(null, null);
            }
            if(e.CommandName == "editar")
            {
                Response.Redirect("Editar.aspx?id=" + ativos[index].Id);
            }
        }

        protected void grdAtivos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#171f25'; this.style.cursor='hand';");
            //    e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#212529'");
            //}
        }
    }
}