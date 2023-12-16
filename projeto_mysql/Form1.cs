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
    public partial class Form1 : Form
    {

        ControleContato controle = new ControleContato();

        public Form1()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro cad = new Cadastro();
            cad.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cl_Conexao con = new cl_Conexao();

            MessageBox.Show(con.conectar());
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta consul = new Consulta();
            consul.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(controle.Backup("C:\\Backup"), "Backup do Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manualDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdf manual = new pdf();
            manual.ShowDialog();
        }

        private void restauraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // instância do open file dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // filtro para ele aparecer a opção de aceitar principalmente arquivos sql e a opção de all file
            openFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";

            // se a operação der certo, a mensagem aparece
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string CaminhoBackup = openFileDialog1.FileName;
                MessageBox.Show (controle.Restore (CaminhoBackup), "Restauração do BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void sairDaAplicaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Não vá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //instância do about box e depois o show para mostrar ele
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorio relat = new Relatorio();
            relat.Show();
        }
    }
}
