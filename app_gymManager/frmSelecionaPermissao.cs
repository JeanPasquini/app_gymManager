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
    public partial class frmSelecionaPermissao : Form
    {
        public int id { get; set; }
        public string permissao { get; set; }

        public frmSelecionaPermissao()
        {
            InitializeComponent();
            AtualizaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int id = 0;
            string permissao = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                permissao = (selectedRow.Cells["DESCRICAO"].Value).ToString();
            }
            else
            {
            }
            this.id = id;
            this.permissao = permissao;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtualizaGrid()
        {
            string sql = "SELECT * FROM DINAMICAPERMISSOES";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            string permissao = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                permissao = (selectedRow.Cells["DESCRICAO"].Value).ToString();
            }
            else
            {
            }
            this.id = id;
            this.permissao = permissao;
            this.Close();
        }
    }
}
