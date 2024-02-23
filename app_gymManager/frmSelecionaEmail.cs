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
        public List<string> emails { get; set; }

        public frmSelecionaEmail()
        {
            InitializeComponent();
            AtualizaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            List<string> emails = new List<string>();
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                string email = selectedRow.Cells["EMAIL"].Value?.ToString();
                if (!string.IsNullOrEmpty(email))
                {
                    emails.Add(email);
                }
            }

            this.emails = emails;
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
            List<string> emails = new List<string>();
            foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
            {
                string email = selectedRow.Cells["EMAIL"].Value?.ToString();
                if (!string.IsNullOrEmpty(email))
                {
                    emails.Add(email);
                }
            }

            this.emails = emails;
            this.Close();
        }
    }
}
