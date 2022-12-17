using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Ativos.Ativos
{
    public partial class Editar : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                var ativo = new Negocio.Ativos().Read(id);

                connection.Open();
                ddlSetor.Items.Clear();
                var reader = new MySqlCommand($"SELECT id, descricao FROM setor WHERE id!=0", connection).ExecuteReader();
                while (reader.Read())
                {
                    var setor = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());
                    ddlSetor.Items.Add(setor);
                }
                connection.Close();

                connection.Open();
                ddlCidade.Items.Clear();
                var rdr = new MySqlCommand("SELECT id, nome FROM cidades WHERE id!=0", connection).ExecuteReader();
                while (rdr.Read())
                {
                    var cidade = new ListItem(rdr.GetString("nome"), rdr.GetInt32("id").ToString());
                    ddlCidade.Items.Add(cidade);
                };
                connection.Close();

                txtDescricao.Text = ativo.Descricao;
                txtQts.Text = Convert.ToString(ativo.Quantidade);
                txtValor.Text = Convert.ToString(ativo.Valor);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"].ToString();
            try
            {
                if((txtDescricao.Text == "")||(txtValor.Text == "")||(txtQts.Text == ""))
                {
                    SiteMaster.AlertPersonalizado(this, "É necessário todos os campoes estarem preenchidos!");
                }
                else
                {
                    var ativo = new Classes.Ativos
                    {
                        Descricao = txtDescricao.Text,
                        Valor = Convert.ToDouble(txtValor.Text),
                        Quantidade = Convert.ToInt32(txtQts.Text),
                        Setor = ddlSetor.SelectedValue,
                        Cidade = ddlCidade.SelectedValue
                    };
                    new Negocio.Ativos().Update(ativo);

                    SiteMaster.AlertPersonalizado(this, "Alterado com sucesso");
                    
                }
            }
            catch
            {

            }
        }
    }
}