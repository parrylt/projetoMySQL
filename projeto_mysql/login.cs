using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_mysql
{
    public partial class login : Form
    {
        //instâncias dos objetos
        ControleContato controle = new ControleContato();
        cl_login lgn = new cl_login();
        Form1 Form1 = new Form1();

        public login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtSenha.Text == "")
            {
                // uma caixa que mostra um erro se não tiver nada digitado nas text box e mesmo assim o usuário apertar no botão entrar
                MessageBox.Show("Digite o Login e a senha para acessar o sistema!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // puxando o método logar
                    bool logar = lgn.Logar(txtLogin.Text, txtSenha.Text);

                    if (logar == true)
                    {
                        //se o login der certo, este form de login some e aparece o form principal
                        this.Hide();
                        Form1.Show();
                    }
                    else
                    {
                        // se o login falhar, a mensagem de erro abaixo aparece, os textos das text boxes são apagados e dá um foco para já começar a escrever na text box de login
                        MessageBox.Show("Login e/ou senha inválidos!!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Clear();
                        txtSenha.Clear();
                        txtLogin.Focus();
                    }
                }
                catch (Exception ex)
                {
                    //mensagem de erro se tudo der errado
                    MessageBox.Show(ex.Message);
                }
            }
        }    
    }
}
