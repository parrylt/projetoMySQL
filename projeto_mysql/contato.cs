using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_mysql
{
    //classe Cl_contato
    public class Cl_contato
    {
        // variáveis
        private int codcontato;
        private string nome;
        private string telefone;
        private string celular;
        private string email;

        //metodos
        public int Codcontato { get => codcontato; set => codcontato = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Email { get => email; set => email = value; }
    }

}
