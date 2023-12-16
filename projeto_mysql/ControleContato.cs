using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace projeto_mysql
{
    //classe controleContato
    public class ControleContato
    {
        //instanciando objeto da classe cl_conexao
        cl_Conexao c = new cl_Conexao();

        //metodo cadastrar com parametro cl_contato cont e com retorno de uma string
        public string cadastrar (Cl_contato cont)
        {
            //O try catch é usado para gerar uma exceção
            try
            {
                //variavel sql onde insere os dados no banco de dados
                string sql = "INSERT INTO tbcontato (nome, telefone, celular, email)" + "VALUES ('" + cont.Nome + "', '" + cont.Telefone + "', '" + cont.Celular + "', '" + cont.Email + "');";
                //instanciando objeto da classe MySqlCommand com parametros sql, c.con
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //abrindo a conexao​
                c.conectar();
                //Executa uma instrucao sql em relacao a um obejto de conexao
                cmd.ExecuteNonQuery();
                //fechando conexao
                c.desconectar();
                //retorno de uma mensangem
                return ("Cadastro realizado com sucesso.");
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                //Retorna uma mensagem de erro
                return (e.ToString());
            }
            
        }

        //metodo alterar com paramtro cl_contato cont e com retorno de uma string
        public string alterar (Cl_contato cont)
        {
            //O try catch é usado para gerar uma exceção
            try
            {
                //variavel sql onde atualiza os dados no banco de dados
                string sql = "UPDATE tbcontato set nome = '" + cont.Nome + "', telefone='" + cont.Telefone + "', celular='" + cont.Celular + "', email='" + cont.Email + "' WHERE codcontato =" + cont.Codcontato  + ";";
                //instanciando objeto da classe MySqlCommand com parametros sql, c.con
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //abrindo a conexao​
                c.conectar();
                //Executa uma instrucao sql em relacao a um obejto de conexao
                cmd.ExecuteNonQuery();
                //fechando conexao
                c.desconectar();
                //retorna uma mensangem
                return ("Alteração realizada com sucesso.");
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                //Retorna uma mensagem de erro
                return (e.ToString());
            }
        }
        //metodo excluir com parametro cl_contato cont e com retorno de uma string
        public string excluir (Cl_contato cont)
        {
            //O try catch é usado para gerar uma exceção
            try
            {
                //variavel sql onde deleta os dados no banco de dados
                string sql = "DELETE FROM tbcontato WHERE codcontato =" + cont.Codcontato + ";";
                //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
                MySqlCommand cmd = new MySqlCommand(sql, c.con);

                //abrindo a conexao​
                c.conectar();
                //Executa uma instrucao sql em relacao a um obejto de conexao
                cmd.ExecuteNonQuery();
                //fechando conexao
                c.desconectar();
                //retorno de uma mensangem
                return ("Exclusão realizada com sucesso.");
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                //Retorna uma mensagem de erro
                return (e.ToString());
            }
        }

        //metodo buscar com parametro codigo e com retorno da variavel cont (Cl_contato)
        public Cl_contato buscar (int codigo)
        {
            //instanciando objeto cont da classe Cl_contato sem parametros e retorna cont
            Cl_contato cont = new Cl_contato();

            //O try catch é usado para gerar uma exceção
            try
            {
                //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
                string sql = "SELECT * FROM tbcontato WHERE codcontato = " + cont.Codcontato + ";";

                //instanciando obejto cmd da classe MySqlCommand com parametros sql, c.con
                MySqlCommand cmd = new MySqlCommand(sql, c.con);
                //Abrindo conexao
                c.conectar();

                //variavel objDados receber e armazena a variavel cmd
                MySqlDataReader objDados = cmd.ExecuteReader();

                //condicao if // leitura no banco​
                if (!objDados.HasRows)
                {
                    //retorna nulo
                    return null;
                }
                else
                {
                    //avança o leitor para o proximo registro em um conjunto de resultados
                    objDados.Read();
                    //converte o conteudo de objDados para inteiro e armazena em Codcontato
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    //converte o conteudo de objDados para inteiro e armazena em nome
                    cont.Nome = objDados["nome"].ToString();
                    //converte o conteudo de objDados para inteiro e armazena em Telefone
                    cont.Telefone = objDados["telefone"].ToString();
                    //converte o conteudo de objDados para inteiro e armazena em Celular
                    cont.Celular = objDados["celular"].ToString();
                    //converte o conteudo de objDados para inteiro e armazena em Email
                    cont.Email = objDados["email"].ToString();

                    //fecha o objeto
                    objDados.Close();
                    //retorna variavel cont
                    return cont;
                }
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                // Trate a exceção adequadamente, por exemplo, registre-a
                throw (e);
            }
            //O bloco finally sempre sera executado, independente se ocorrer excecao ou nao no bloco try
            finally
            {
                //fechando conexao
                c.desconectar();
            }
        }

        //metodo PreencherTodos sem parametros e retorna contato 
        public DataTable PreencherTodos()
        {
            //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato;";

            //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            //Abrindo conexao
            c.conectar();

            //instanciando objeto "da" da classe MySqlAdapter com parametro cmd
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //instanciando objeto contato da classe DataTable
            DataTable contato = new DataTable();
            //Adiciona ou atualiza linhas 
            da.Fill(contato);
            //fechando conexao
            c.desconectar();
            return contato;
        }

        public DataTable pesquisaCodigo (int codigo)
        {
            //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where codcontato = " + codigo + ";";
            //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            //abrindo conexao
            c.conectar();

            //instanciando objeto "da" da classe MySqlDataAdapter com parametro cmd
            MySqlDataAdapter da = new MySqlDataAdapter (cmd);
            //instanciando objeto contato da classe DataTable
            DataTable contato = new DataTable();
            //Adiciona ou atualiza linhas 
            da.Fill(contato);
            //fechando conexao
            c.desconectar();
            //retorna contato
            return contato;
        }

        public DataTable pesquisaNome (string nomecontato)
        {
            //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where nome like '%" + nomecontato + "%';";
            //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            //abrindo conexao
            c.conectar();

            //instanciando objeto "da" da classe MySqlDataAdapter com parametro cmd
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //instanciando objeto contato da classe DataTable
            DataTable contato = new DataTable();
            //Adiciona ou atualiza linhas 
            da.Fill(contato);
            //fechando conexao
            c.desconectar();
            //retorna contato
            return contato;
        }

        public DataTable pesquisaEmail(string email)
        {
            //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where email like '%" + email + "%';";
            //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            //abrindo conexao
            c.conectar();

            //instanciando objeto "da" da classe MySqlDataAdapter com parametro cmd
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //instanciando objeto contato da classe DataTable
            DataTable contato = new DataTable();
            //Adiciona ou atualiza linhas 
            da.Fill(contato);
            //fechando conexao
            c.desconectar();
            //retorna contato
            return contato;
        }

        //metodo pesquisaTelefone com parametro telefone e com retorno de contato
        public DataTable pesquisaTelefone(string telefone)
        {
            //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where telefone ='" + telefone + "';";
            //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            //abrindo conexao
            c.conectar();

            //instanciando objeto "da" da classe MySqlDataAdapter com parametro da variavel cmd
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //instanciando objeto contato da classe DataTable
            DataTable contato = new DataTable();
            //Adiciona ou atualiza linhas 
            da.Fill(contato);
            //fechando conexao
            c.desconectar();
            //retorna contato
            return contato;
        }

        //metodo pesquisarCelular com parametro celular e com retorno de contato (DataTable)
        public DataTable pesquisaCelular(string celular)
        {
            //variavel sql onde faz a consulta e seleciona os dados da tabela codcontato no banco de dados
            string sql = "select codcontato as 'Código', nome as Nome, telefone as Telefone, celular as Celular, email as Email from tbcontato where celular ='" + celular + "';";
            //instanciando objeto cmd da classe MySqlCommand com parametro sql, c.con
            MySqlCommand cmd = new MySqlCommand(sql, c.con);
            //abrindo conexao
            c.conectar();

            //instanciando objeto "da" da classe MySqlDataAdapter com parametro da variavel cmd
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //instanciando objeto contato da classe DataTable
            DataTable contato = new DataTable();
            //Adiciona ou atualiza linhas 
            da.Fill(contato);
            //Fechando conexao
            c.desconectar();
            //retorna contato
            return contato;
        }

        //metodo Backup com parametro Caminho e com retorno de uma string
        public string Backup (string Caminho)
        {
            //variavel dataAtual armazena string
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            //variavel CaminhoBackup armazena string
            string CaminhoBackup = Caminho + "\\backupContatos_" + dataAtual + ".sql";

            //O try catch é usado para gerar uma exceção
            try
            {
                //instancianco objeto cmd da classe MySqlCommand com parametros CaminhoBackup, c.con
                MySqlCommand cmd = new MySqlCommand(CaminhoBackup, c.con);
                //instanciando objeto mb da classe MySqlBackup com parametro cmd
                MySqlBackup mb = new MySqlBackup(cmd);
                //abre conexao
                c.conectar();
                mb.ExportToFile(CaminhoBackup);
                //fecha conexao
                c.desconectar();
                //retorna uma mensagem
                return ("Backup do banco de dados realizado com sucesso!");
            }
            //Se houver alguma excecao sera capturada no catch
            catch (MySqlException e)
            {
                //Retorna uma mensagem de erro
                return (e.ToString());
            }
        }

        public string Restore (string caminho) // Backup a mysql database
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(caminho, c.con);
                MySqlBackup mb = new MySqlBackup(cmd);
                c.conectar();
                mb.ImportFromFile(caminho);
                c.desconectar();
                return ("Banco de dados restaurado com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }
        
    }    
}