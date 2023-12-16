using MySql.Data.MySqlClient;

namespace projeto_mysql
{
    //classe cl_login
    public class cl_login
    {
        //instanciando objeto c da classe cl_conexao sem parametros
        private cl_Conexao c = new cl_Conexao();

        //metodo Logar com parametros string l, string s
        public bool Logar(string l, string s)
        {
            //O try catch é usado para gerar uma exceção
            try
            {
                //variavel sql onde faz a consulta e seleciona os dados da tabela tbllogin no banco de dados
                string sql = "SELECT login, senha FROM tbllogin WHERE login = @login AND senha = @senha";

                //instanciando um objeto cmd da classe e inicializando com uma consulta sql (sql) e uma conexao ao banco de dados (c.con)
                using (MySqlCommand cmd = new MySqlCommand(sql, c.con))
                {
                    //Adiciona um parametro chamado @login com o valor de 1
                    cmd.Parameters.AddWithValue("@login", l);
                    //Adiciona um parametro chamado @senha com o valor de s
                    cmd.Parameters.AddWithValue("@senha", s);

                    //Abrindo conexao
                    c.conectar();

                    using (MySqlDataReader objDados = cmd.ExecuteReader())
                    {
                        //Retorna se houver uma ou mais linhas
                        return objDados.HasRows;
                    }
                }
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                // Trate a exceção adequadamente, por exemplo, registre-a
                throw (e); // Relançando a exceção sem modificá-la
            }
            //O bloco finally sempre sera executado, independente se ocorrer excecao ou nao no bloco try
            finally
            {
                //Fechando conexao
                c.desconectar();
            }
        }
    }
}
