using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Ativos.Classes
{
    public class Ativos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Double Valor { get; set; }
        public int Quantidade { get; set; }
        public string Setor { get; set; }
        public string Cidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}