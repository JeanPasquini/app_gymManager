using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public partial class frmVisaoAvaliacaoAluno : Form
    {
        public frmVisaoAvaliacaoAluno()
        {
            InitializeComponent();
            AtualizaGrid();
        }

        private void txtVerGrid_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            else
            {
            }

            frmCadastroUsuario frm = new frmCadastroUsuario(false, id);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            string sql = $"SELECT * FROM AVALIACAOALUNO WHERE IDALUNO = '{conexaoBanco.idUser}'";
            dataGridView1.DataSource = conexaoBanco.GetDataTable(sql);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            else
            {
            }

            frmCadastroAvaliacaoIndividual frm = new frmCadastroAvaliacaoIndividual(true, id, conexaoBanco.idUser);
            frm.ShowDialog();
            AtualizaGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            }
            else
            {
            }

            frmCadastroAvaliacaoIndividual frm = new frmCadastroAvaliacaoIndividual(true, id, conexaoBanco.idUser);
            frm.ShowDialog();
            AtualizaGrid();
        }
    }
}
