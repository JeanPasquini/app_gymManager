using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public partial class frmSelecionaEmail : Form
    {
        public int id { get; set; }
        public string email { get; set; }

        public frmSelecionaEmail()
        {
            InitializeComponent();
            AtualizaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string email = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                email = (selectedRow.Cells["EMAIL"].Value).ToString();
            }
            else
            {
            }
            this.email = email;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtualizaGrid()
        {
            string sql = $"SELECT NOME, EMAIL FROM LUSUARIO";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string email = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                email = (selectedRow.Cells["EMAIL"].Value).ToString();
            }
            else
            {
            }
            this.email = email;
            this.Close();
        }
    }
}
