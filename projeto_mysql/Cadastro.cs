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
    public partial class Cadastro : Form
    {
        Cl_contato cont = new Cl_contato();
        ControleContato controle = new ControleContato();

        public Cadastro()
        {
            InitializeComponent();
        }

        private void limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            mtxtTelefone.Clear();
            mtxtCelular.Clear();
            txtEmail.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show ("Não é permitido o cadastro sem um nome!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cont.Nome = txtNome.Text;
                cont.Telefone = mtxtTelefone.Text;
                cont.Celular = mtxtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));
                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);
            cont.Nome = txtNome.Text;
            cont.Telefone = mtxtTelefone.Text;
            cont.Celular = mtxtCelular.Text;
            cont.Email = txtEmail.Text;

            MessageBox.Show(controle.alterar(cont));
            limpar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);

            MessageBox.Show(controle.excluir(cont));
            limpar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cont = controle.buscar(int.Parse(txtCodigo.Text));

                if (cont is null)
                {
                    MessageBox.Show("Registro não encontrado!");
                }
                else
                {
                    txtCodigo.Text = cont.Codcontato.ToString();
                    txtNome.Text = cont.Nome.ToString();
                    mtxtTelefone.Text = cont.Telefone.ToString();
                    mtxtCelular.Text = cont.Celular.ToString();
                    txtEmail.Text = cont.Email.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
