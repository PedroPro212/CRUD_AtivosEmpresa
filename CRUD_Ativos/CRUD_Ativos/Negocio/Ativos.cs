using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Ativos.Negocio
{
    public class Ativos
    {
        private MySqlConnection connection;

        public Ativos()
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);
        }

        public Classes.Ativos Read(string id)
        {
            return this.Read(id, "", "", "").FirstOrDefault();
        }

        public List<Classes.Ativos> Read(string id, string descricao, string valor, string quantidade) 
        { 
            var ativos = new List<Classes.Ativos>();
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"SELECT id, descricao, valor, quantidade, setor FROM ativos WHERE (1=1)", connection);
                if(descricao.Equals("") == false)
                {
                    comando.CommandText += $" AND descricao like @descricao";
                    comando.Parameters.Add(new MySqlParameter("descricao", $"%{descricao}%"));
                }
                if(valor.Equals("") == false)
                {
                    comando.CommandText += $" AND valor = @valor";
                    comando.Parameters.Add(new MySqlParameter("valor", valor));
                }
                if (quantidade.Equals("") == false)
                {
                    comando.CommandText += $" AND quantidade = @quantidade";
                    comando.Parameters.Add(new MySqlParameter("quantidade", quantidade));
                }
                if (id.Equals("") == false)
                {
                    comando.CommandText += $" AND id = @id";
                    comando.Parameters.Add(new MySqlParameter("id", id));
                }
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ativos.Add(new Classes.Ativos
                    {
                        Descricao = reader.GetString("descricao"),
                        Id = reader.GetInt32("id"),
                        Valor = reader.GetDouble("valor"),
                        Quantidade = reader.GetInt32("quantidade")
                    });
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return ativos;
        }


        public bool Create(Classes.Ativos ativos)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand($@"INSERT INTO ativos (descricao, valor, quantidade, cidade, setor) VALUES (@descricao, @valor, @quantidade, @cidade, @setor)", connection);
                comando.Parameters.Add(new MySqlParameter("descricao", ativos.Descricao));
                comando.Parameters.Add(new MySqlParameter("valor", ativos.Valor));
                comando.Parameters.Add(new MySqlParameter("quantidade", ativos.Quantidade));
                comando.Parameters.Add(new MySqlParameter("cidade", ativos.Cidade));
                comando.Parameters.Add(new MySqlParameter("setor", ativos.Setor));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Update(Classes.Ativos ativos)
        {
            
            try
            {
                connection.Open();
                var comando = new MySqlCommand($"UPDATE ativos SET descricao = @descricao, valor = @valor, quantidade = @quantidade, setor = @setor, cidade = @cidade WHERE id = @id", connection);
                comando.Parameters.Add(new MySqlParameter("descricao", ativos.Descricao));
                comando.Parameters.Add(new MySqlParameter("valor", ativos.Valor));
                comando.Parameters.Add(new MySqlParameter("quantidade", ativos.Quantidade));
                comando.Parameters.Add(new MySqlParameter("setor", ativos.Setor));
                comando.Parameters.Add(new MySqlParameter("cidade", ativos.Cidade));
                comando.Parameters.Add(new MySqlParameter("id", ativos.Id));
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                connection.Open();
                var comando = new MySqlCommand("DELETE FROM ativos WHERE id=" + id, connection);
                comando.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}