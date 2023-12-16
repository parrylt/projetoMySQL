using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_mysql
{
    public partial class Consulta : Form

    {// string de conexão​
        ControleContato cc = new ControleContato();

        //metodo consulta sem parâmetros e sem retorno
        public Consulta()
        {
            //Abre a pagina de consulta
            InitializeComponent();
        }

        //metodo btnBuscar_Click com parâmetros e 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcoes.SelectedIndex == 0)
            {
                try
                {
                    int codigo = Convert.ToInt32(txtbBusca.Text);
                    dataGridView1.DataSource = cc.pesquisaCodigo(codigo);
                }
                catch
                {
                    MessageBox.Show("Digite um valor inteiro para o código!");
                    txtbBusca.Clear();
                    txtbBusca.Focus();
                }
            }
            else if (cbOpcoes.SelectedIndex == 1)
            {
                string nomecontato = (txtbBusca.Text);

                dataGridView1.DataSource = cc.pesquisaNome(nomecontato);
            }
            else if (cbOpcoes.SelectedIndex == 2)
            {
                string email = (txtbBusca.Text);

                dataGridView1.DataSource = cc.pesquisaEmail(email);
            }
            else if (cbOpcoes.SelectedIndex == 3)
            {
                string telefone = (txtbBusca.Text);

                dataGridView1.DataSource = cc.pesquisaTelefone(telefone);
            }
            else if (cbOpcoes.SelectedIndex == 4)
            {
                string celular = (txtbBusca.Text);

                dataGridView1.DataSource = cc.pesquisaCelular(celular);
            }


        }

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cc.PreencherTodos();
        }

        private void cbOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOpcoes.SelectedIndex <0)
            {
                txtbBusca.Enabled = false;
                btnBuscar.Enabled = false;
                lblOpcoes.Text = "";
            }
            else
            {
                txtbBusca.Enabled = true;
                lblOpcoes.Text = "Digite o " + cbOpcoes.Text;
                txtbBusca.Clear();
                txtbBusca.Focus();
            }
        }
    }
}
