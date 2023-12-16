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
    public partial class pdf : Form
    {
        //metodo pdf sem parametro e sem retorno
        public pdf()
        {
            //configura as propriedades dos controles que adicionamos no modo Design
            InitializeComponent();
        }

        //metodo pdf_Load com parametros e sem retorno
        private void pdf_Load(object sender, EventArgs e)
        {
            //codigo para adicionar o arquivo pdf 
            axAcroPDF1.LoadFile("manual.pdf");
        }
    }
}