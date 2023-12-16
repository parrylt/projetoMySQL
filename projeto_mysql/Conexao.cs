using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_mysql
{
    //classe cl_conexao
    class cl_Conexao
    {
        // string de conexão​
        public MySqlConnection con = new MySqlConnection(@"Server=localhost;Port=3306;Database=agenda;User=root; Pwd=");
        
        // metodo conectar sem parâmetros e com retorno de uma string
        public string conectar()
        {
            //O try catch é usado para gerar uma exceção
            try
            {
                //Abrindo conexão com o banco de dados chamando a instância da conexão
                con.Open();
            //O try catch é usado para gerar uma exceção    //Retorna uma string caso verdadeiro
                return
                    ("Conexão realizada com sucesso!");
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                //Retorna uma string caso falso
                return (e.ToString());
            }
        }

        //metodo desconctar sem parâmetros e com retorno de uma string
        public string desconectar()
        {
            //O try catch é usado para gerar uma exceção
            try
            {
                //Abrindo conexão com o banco de dados chamando a instância da conexão
                con.Close();
                //Retorna uma mensagem de conexao encerrada 
                return ("Conexão Encerrada!");
            }
            //Se houver alguma excessao sera capturada no catch
            catch (MySqlException e)
            {
                //Retorna uma mensagem de erro
                return (e.ToString());
            }
        }
    }
}
