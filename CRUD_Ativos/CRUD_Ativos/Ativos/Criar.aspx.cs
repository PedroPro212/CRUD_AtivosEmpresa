using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Ativos.Ativos
{
    public partial class Criar : System.Web.UI.Page
    {
        private MySqlConnection connection = new MySqlConnection(SiteMaster.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                connection.Open();
                ddlSetor.Items.Clear();
                var reader = new MySqlCommand("SELECT id, descricao FROM setor WHERE id!=0", connection).ExecuteReader();
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
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var ativos = new Classes.Ativos();
                ativos.Descricao = txtDescricao.Text;
                ativos.Valor = Convert.ToDouble(txtValor.Text);
                ativos.Quantidade = Convert.ToInt32(txtQts.Text);
                ativos.Setor = ddlSetor.SelectedValue;
                ativos.Cidade = ddlCidade.SelectedValue;
                new Negocio.Ativos().Create(ativos);

                SiteMaster.AlertPersonalizado(this, "Cadastrado com sucesso");
            }
            catch(Exception ex)
            {
                SiteMaster.AlertPersonalizado(this, "Aconteceu o seguinte erro: " + ex);
            }
        }
    }
}