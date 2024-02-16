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
    public partial class frmSelecionaBotao : Form
    {
        public int id { get; set; }
        public string botao { get; set; }

        public frmSelecionaBotao()
        {
            InitializeComponent();
            AtualizaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int id = 0;
            string botao = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                botao = (selectedRow.Cells["DESCRICAO"].Value).ToString();
            }
            else
            {
            }
            this.id = id;
            this.botao = botao;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtualizaGrid()
        {
            string sql = "SELECT * FROM DINAMICABOTOES";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            string botao = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                botao = (selectedRow.Cells["DESCRICAO"].Value).ToString();
            }
            else
            {
            }
            this.id = id;
            this.botao = botao;
            this.Close();
        }
    }
}
